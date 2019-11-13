using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

        public AdminService(IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthorizedAdminDTO> AuthorizeAsync(string login, string password)
        {
            if (_appSettings.Admin.Login != login ||
                _appSettings.Admin.Password != password)
            {
                throw new AccessForbiddenException("Invalid login or password.");
            }

            var claims = new List<Claim> {
                new Claim( ClaimTypes.Email, login )
            };

            var authorizedAdmin = new AuthorizedAdminDTO() { Login = login };

            authorizedAdmin.Token = GetToken(claims, TimeSpan.Parse(_appSettings.JwtSettings.Expires),
                                        Encoding.ASCII.GetBytes(_appSettings.JwtSettings.SecretKey));

            return authorizedAdmin;
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
