using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Infrastructure;
using SF.Services.Helpers;
using SF.Services.Interfaces;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models;
using SF.Services.Models.Bands;

namespace SF.Services
{
    public class BandService : IBandService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;

        public BandService(IMapper mapper, SFDbContext dbContext)
        {
            _mapper = mapper;
            _DBContext = dbContext;
        }

        public async Task<PagedResultDTO<BandDTO>> GetBandsPageAsync(int page, int pageSize)
        {
            var query = _DBContext.Bands
                .Include(band => band.BandGenres)
                .ThenInclude(bg => bg.Genre)
                .AsNoTracking();

            var pagedResult = await _DBContext.GetPage<BandEntity, BandDTO>(_mapper, query, page, pageSize);
            return pagedResult;
        }

        public async Task<BandDTO> GetBandByIdAsync(int bandId)
        {
            var band = await _DBContext.Bands.AsNoTracking().FirstOrDefaultAsync(b => b.Id == bandId);

            if (band == null)
            {
                throw new ItemNotFoundException($"Band with id {bandId} not found.");
            }

            var bandDTO = _mapper.Map<BandDTO>(band);

            return bandDTO;
        }

        public async Task<BandDTO> CreateBandAsync(CreateBandDTO createBandDTO)
        {
            var genres = await _DBContext.Genres.Where(g => createBandDTO.GenreIds.Contains(g.Id)).ToListAsync();

            if (genres.Count < 1)
            {
                throw new BadArgumentException("No genres found. Band can not exist without a genre.");
            }

            var band = new BandEntity
            {
                Name = createBandDTO.Name,
                Description = createBandDTO.Description,
                BandGenres = genres.Select(genre => new BandGenreEntity { GenreId = genre.Id }).ToList()
            };

            await _DBContext.Bands.AddAsync(band);
            await _DBContext.SaveChangesAsync();

            var bandDTO = _mapper.Map<BandDTO>(band);

            return bandDTO;
        }

        public async Task<BandDTO> UpdateBandAsync(UpdateBandDTO updateBandDTO)
        {
            var band = await _DBContext.Bands
                .Include(b => b.BandGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(b => b.Id == updateBandDTO.Id);

            if (band == null)
            {
                throw new ItemNotFoundException($"Band with id {updateBandDTO.Id} not found.");
            }

            if (!string.IsNullOrWhiteSpace(updateBandDTO.Name))
            {
                band.Name = updateBandDTO.Name;
            }
            if (!string.IsNullOrWhiteSpace(updateBandDTO.Description))
            {
                band.Description = updateBandDTO.Description;
            }
            if (updateBandDTO.GenreIdsToAdd.Count > 0)
            {
                //Можна краще?
                var genresToAdd = await _DBContext.Genres.Where(g => updateBandDTO.GenreIdsToAdd.Contains(g.Id)).ToListAsync();

                genresToAdd = genresToAdd.Where(g => !band.BandGenres.Any(bg => bg.GenreId == g.Id)).ToList();

                if (genresToAdd.Count < 1)
                {
                    throw new BadArgumentException("Band already belongs to these genres.");
                }

                band.BandGenres.AddRange(genresToAdd.Select(genre => new BandGenreEntity { GenreId = genre.Id }));
            }
            if (updateBandDTO.GenreIdsToRemove.Count > 0)
            {
                band.BandGenres.RemoveAll(bg => updateBandDTO.GenreIdsToRemove.Any(id => id == bg.GenreId));
            }

            _DBContext.Bands.Update(band);
            await _DBContext.SaveChangesAsync();

            var bandDTO = _mapper.Map<BandDTO>(band);

            return bandDTO;
        }

        public async Task DeleteBandAsync(int bandId)
        {
            var band = await _DBContext.Bands.FirstOrDefaultAsync(b => b.Id == bandId);

            if (band == null)
            {
                throw new ItemNotFoundException($"Band with id {bandId} not found.");
            }

            _DBContext.Bands.Remove(band);
            await _DBContext.SaveChangesAsync();
        }
    }
}
