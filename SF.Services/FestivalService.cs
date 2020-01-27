using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Infrastructure;
using SF.Services.Interfaces;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models.Festivals;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SF.Services
{
    public class FestivalService : IFestivalService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;

        public FestivalService(IMapper mapper, SFDbContext dbContext)
        {
            _mapper = mapper;
            _DBContext = dbContext;
        }

        public async Task<List<FestivalDTO>> GetAllFestivalsAsync()
        {
            var festivals = await _DBContext.Festivals
                .Include(f => f.PartnerFestivals)
                .ThenInclude(pf => pf.Partner)
                .AsNoTracking().ToListAsync();

            var festivalsDTO = _mapper.Map<List<FestivalDTO>>(festivals);

            return festivalsDTO;
        }


        public async Task<FestivalDTO> GetFestivalByIdAsync(int festivalId)
        {
            var festival = await _DBContext.Festivals.AsNoTracking()
                .Include(f => f.PartnerFestivals)
                .ThenInclude(pf => pf.Partner).FirstOrDefaultAsync(f => f.Id == festivalId);

            if (festival == null)
            {
                throw new ItemNotFoundException($"Festival with id {festivalId} not found.");
            }

            var festivalDTO = _mapper.Map<FestivalDTO>(festival);

            return festivalDTO;
        }

        public async Task<FestivalDTO> CreateFestivalAsync(CreateFestivalDTO createFestivalDTO)
        {
            var festival = new FestivalEntity
            {
                Year = createFestivalDTO.Year,
                Location = createFestivalDTO.Location
            };

            if (createFestivalDTO.PartnerIds != null)
            {
                var partners = await _DBContext.Partners.Where(p => createFestivalDTO.PartnerIds.Contains(p.Id)).ToListAsync();

                if (partners.Count > 0)
                {
                    festival.PartnerFestivals = partners.Select(partner => new PartnerFestivalEntity { PartnerId = partner.Id }).ToList();
                }
            }

            await _DBContext.Festivals.AddAsync(festival);
            await _DBContext.SaveChangesAsync();

            var festivalDTO = _mapper.Map<FestivalDTO>(festival);

            return festivalDTO;
        }

        public async Task<FestivalDTO> UpdateFestivalAsync(UpdateFestivalDTO updateFestivalDTO)
        {
            var festival = await _DBContext.Festivals
                .Include(f => f.PartnerFestivals)
                .ThenInclude(pf => pf.Partner)
                .FirstOrDefaultAsync(f => f.Id == updateFestivalDTO.Id);

            if (festival == null)
            {
                throw new ItemNotFoundException($"Festival with id {updateFestivalDTO.Id} not found.");
            }

            if (!string.IsNullOrWhiteSpace(updateFestivalDTO.Year))
            {
                festival.Year = updateFestivalDTO.Year;
            }
            if (!string.IsNullOrWhiteSpace(updateFestivalDTO.Location))
            {
                festival.Location = updateFestivalDTO.Location;
            }
            if (updateFestivalDTO.PartnerIdsToAdd.Count > 0)
            {
                //Можна краще?
                var partnersToAdd = await _DBContext.Partners.Where(p => updateFestivalDTO.PartnerIdsToAdd.Contains(p.Id)).ToListAsync();

                partnersToAdd = partnersToAdd.Where(p => !festival.PartnerFestivals.Any(pf => pf.PartnerId == p.Id)).ToList();

                festival.PartnerFestivals.AddRange(partnersToAdd.Select(partner => new PartnerFestivalEntity { PartnerId = partner.Id }));
            }
            if (updateFestivalDTO.PartnerIdsToRemove.Count > 0)
            {
                festival.PartnerFestivals.RemoveAll(pf => updateFestivalDTO.PartnerIdsToRemove.Any(id => id == pf.PartnerId));
            }

            _DBContext.Festivals.Update(festival);
            await _DBContext.SaveChangesAsync();

            var festivalDTO = _mapper.Map<FestivalDTO>(festival);

            return festivalDTO;
        }

        public async Task DeleteFestivalAsync(int festivalId)
        {
            var festival = await _DBContext.Festivals.FirstOrDefaultAsync(f => f.Id == festivalId);

            if (festival == null)
            {
                throw new ItemNotFoundException($"Festival with id {festivalId} not found.");
            }

            _DBContext.Festivals.Remove(festival);
            await _DBContext.SaveChangesAsync();
        }
    }
}
