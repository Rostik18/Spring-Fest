using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Infrastructure;
using SF.Services.Helpers;
using SF.Services.Interfaces;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models;
using SF.Services.Models.Genres;

namespace SF.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;

        public GenreService(IMapper mapper, SFDbContext dbContext)
        {
            _mapper = mapper;
            _DBContext = dbContext;
        }

        public async Task<GenreDTO> CreateGenreAsync(CreateGenreDTO createGenreDTO)
        {
            var genre = new GenreEntity
            {
                Name = createGenreDTO.Name
            };

            await _DBContext.Genres.AddAsync(genre);
            await _DBContext.SaveChangesAsync();

            var genreDTO = _mapper.Map<GenreDTO>(genre);

            return genreDTO;
        }

        public async Task DeleteGenreAsync(int genreId)
        {
            var genre = await _DBContext.Genres.FirstOrDefaultAsync(g => g.Id == genreId);

            if (genre == null)
            {
                throw new ItemNotFoundException($"Genre with id {genreId} not found.");
            }

            _DBContext.Genres.Remove(genre);
            await _DBContext.SaveChangesAsync();
        }

        public async Task<List<GenreDTO>> GetAllGenresAsync()
        {
            var genres = await _DBContext.Genres.AsNoTracking().ToListAsync();

            var genresDTO = _mapper.Map<List<GenreDTO>>(genres);

            return genresDTO;
        }

        public async Task<GenreDTO> GetGenreByIdAsync(int genreId)
        {
            var genre = await _DBContext.Genres.AsNoTracking().FirstOrDefaultAsync(g => g.Id == genreId);

            if (genre == null)
            {
                throw new ItemNotFoundException($"Genre with id {genreId} not found.");
            }

            var genreDTO = _mapper.Map<GenreDTO>(genre);

            return genreDTO;
        }

        public async Task<PagedResultDTO<GenreDTO>> GetGenresPageAsync(int page, int pageSize)
        {
            var query = _DBContext.Genres.AsNoTracking();

            var pagedResult = await _DBContext.GetPage<GenreEntity, GenreDTO>(_mapper, query, page, pageSize);

            return pagedResult;
        }

        public async Task<GenreDTO> UpdateGenreAsync(UpdateGenreDTO updateGenreDTO)
        {
            var genre = await _DBContext.Genres.FirstOrDefaultAsync(g => g.Id == updateGenreDTO.Id);

            if (genre == null)
            {
                throw new ItemNotFoundException($"Genre with id {updateGenreDTO.Id} not found.");
            }

            genre.Name = updateGenreDTO.Name;

            _DBContext.Genres.Update(genre);
            await _DBContext.SaveChangesAsync();

            var genreDTO = _mapper.Map<GenreDTO>(genre);

            return genreDTO;
        }
    }
}
