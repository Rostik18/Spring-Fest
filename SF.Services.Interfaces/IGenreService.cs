using SF.Services.Models;
using SF.Services.Models.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO> GetGenreByIdAsync(int genreId);
        Task<PagedResultDTO<GenreDTO>> GetGenresPageAsync(int page, int pageSize);
        Task<GenreDTO> CreateGenreAsync(CreateGenreDTO createGenreDTO);
        Task<GenreDTO> UpdateGenreAsync(UpdateGenreDTO updateGenreDTO);
        Task DeleteGenreAsync(int genreId);
    }
}
