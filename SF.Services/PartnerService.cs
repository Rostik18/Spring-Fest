using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Infrastructure;
using SF.Services.Helpers;
using SF.Services.Interfaces;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models;
using SF.Services.Models.Partners;
using System.Threading.Tasks;

namespace SF.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;

        public PartnerService(IMapper mapper, SFDbContext dbContext)
        {
            _mapper = mapper;
            _DBContext = dbContext;
        }

        public async Task<PartnerDTO> CreatePartnerAsync(CreatePartnerDTO createPartnerDTO)
        {
            var partner = new PartnerEntity
            {
                Name = createPartnerDTO.Name,
                Description = createPartnerDTO.Description
            };

            await _DBContext.Partners.AddAsync(partner);
            await _DBContext.SaveChangesAsync();

            var PartnerDTO = _mapper.Map<PartnerDTO>(partner);

            return PartnerDTO;
        }

        public async Task DeletePartnerAsync(int partnerId)
        {
            var partner = await _DBContext.Partners.FirstOrDefaultAsync(s => s.Id == partnerId);

            if (partner == null)
            {
                throw new ItemNotFoundException($"Partner with id {partnerId} not found.");
            }

            _DBContext.Partners.Remove(partner);
            await _DBContext.SaveChangesAsync();
        }

        public async Task<PagedResultDTO<PartnerDTO>> GetPartnersPageAsync(int page, int pageSize)
        {
            var query = _DBContext.Partners.AsNoTracking();

            var pagedResult = await _DBContext.GetPage<PartnerEntity, PartnerDTO>(_mapper, query, page, pageSize);

            return pagedResult;
        }

        public async Task<PartnerDTO> GetPartnerByIdAsync(int partnerId)
        {
            var partner = await _DBContext.Partners.AsNoTracking().FirstOrDefaultAsync(s => s.Id == partnerId);

            if (partner == null)
            {
                throw new ItemNotFoundException($"Partner with id {partnerId} not found.");
            }

            var partnerDTO = _mapper.Map<PartnerDTO>(partner);

            return partnerDTO;
        }

        public async Task<PartnerDTO> UpdatePartnerAsync(UpdatePartnerDTO updatePartnerDTO)
        {
            var partner = await _DBContext.Partners.FirstOrDefaultAsync(s => s.Id == updatePartnerDTO.Id);

            if (partner == null)
            {
                throw new ItemNotFoundException($"Partner with id {updatePartnerDTO.Id} not found.");
            }

            if (!string.IsNullOrWhiteSpace(updatePartnerDTO.Name))
            {
                partner.Name = updatePartnerDTO.Name;
            }
            if (!string.IsNullOrWhiteSpace(updatePartnerDTO.Description))
            {
                partner.Description = updatePartnerDTO.Description;
            }

            _DBContext.Partners.Update(partner);
            await _DBContext.SaveChangesAsync();

            var partnerDTO = _mapper.Map<PartnerDTO>(partner);

            return partnerDTO;
        }
    }
}
