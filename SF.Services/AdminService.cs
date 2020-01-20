using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SF.Domain.Entities;
using SF.Infrastructure;
using SF.Services.Helpers;
using SF.Services.Interfaces;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models;
using SF.Services.Models.Admins;

namespace SF.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly SFDbContext _DBContext;

        public AdminService(IMapper mapper, IOptions<AppSettings> appSettings, SFDbContext dbContext)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _DBContext = dbContext;
        }

        public async Task<AuthorizedAdminDTO> AuthorizeAsync(string login, string password)
        {
            var admin = await _DBContext.Admins.FirstOrDefaultAsync(x => x.Login == login);

            if (admin == null)
            {
                throw new AccessForbiddenException("Invalid login or password.");
            }

            if (!PasswordHashHelper.VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt))
            {
                throw new AccessForbiddenException("Invalid login or password.");
            }

            var claims = new List<Claim> {
                new Claim( "login", login )
            };

            var authorizedAdmin = new AuthorizedAdminDTO() { Login = login };

            authorizedAdmin.Token = GetToken(claims, TimeSpan.Parse(_appSettings.JwtSettings.Expires),
                                        Encoding.ASCII.GetBytes(_appSettings.JwtSettings.SecretKey));

            return authorizedAdmin;
        }

        public async Task<bool> CreateAdminAsync(string login, string password)
        {
            var isLoginUnavailable = _DBContext.Admins.Any(admin => admin.Login == login);

            if (isLoginUnavailable)
            {
                throw new BadArgumentException("This login is unavailable.");
            }

            PasswordHashHelper.CreatePasswordHash(password, out byte[] hash, out byte[] salt);

            AdminEntity createAdminEntity = new AdminEntity()
            {
                Login = login,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            await _DBContext.Admins.AddAsync(createAdminEntity);
            await _DBContext.SaveChangesAsync();

            bool isAdminCreated = await _DBContext.Admins.AnyAsync(admin => admin.Login == login);

            return isAdminCreated;
        }

        public async Task<PagedResultDTO<AdminDTO>> GetAdminsPageAsync(int page, int pageSize)
        {
            var query = _DBContext.Admins.AsNoTracking();

            var pagedResult = await _DBContext.GetPage<AdminEntity, AdminDTO>(_mapper, query, page, pageSize);
            return pagedResult;
        }

        public async Task DeleteAdminAsync(int adminId)
        {
            AdminEntity adminEntity = await _DBContext.Admins.FirstOrDefaultAsync(a => a.Id == adminId);

            if (adminEntity == null)
            {
                throw new ItemNotFoundException($"Admin with id {adminId} not found.");
            }

            _DBContext.Admins.Remove(adminEntity);
            await _DBContext.SaveChangesAsync();
        }

        public async Task<AdminDTO> UpdateAdminAsync(UpdateAdminDTO updateAdminDTO)
        {
            if (string.IsNullOrWhiteSpace(updateAdminDTO.NewLogin) &&
                string.IsNullOrWhiteSpace(updateAdminDTO.NewPassword))
            {
                throw new BadArgumentException("The new login and password cannot be blank at the same time. There is nothing to update.");
            }

            AdminEntity admin = await _DBContext.Admins.FirstOrDefaultAsync(a => a.Id == updateAdminDTO.Id);

            if (admin == null)
            {
                throw new BadArgumentException($"Admin with id {updateAdminDTO.Id} not found.");
            }

            //Подумати!!!
            if (!string.IsNullOrWhiteSpace(updateAdminDTO.NewLogin))
            {
                admin.Login = updateAdminDTO.NewLogin;
            }
            if (!string.IsNullOrWhiteSpace(updateAdminDTO.NewPassword))
            {
                PasswordHashHelper.CreatePasswordHash(updateAdminDTO.NewPassword, out var hash, out var sail);

                admin.PasswordHash = hash;
                admin.PasswordSalt = sail;
            }

            _DBContext.Admins.Update(admin);
            await _DBContext.SaveChangesAsync();

            var updatedAdminDTO = _mapper.Map<AdminDTO>(admin);

            return updatedAdminDTO;
        }

        private string GetToken(List<Claim> claims, TimeSpan duration, byte[] securityKey)
        {

            var token = new JwtSecurityToken(
                issuer: _appSettings.JwtSettings.Issuer,
                notBefore: DateTime.Now,
                claims: claims,
                expires: DateTime.Now.Add(duration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256));

            string tokenS = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenS;
        }
    }
}
