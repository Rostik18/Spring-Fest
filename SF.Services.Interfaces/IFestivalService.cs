using SF.Services.Models.Festivals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IFestivalService
    {
        Task<List<FestivalDTO>> GetAllFestivalsAsync();
        Task<FestivalDTO> GetFestivalByIdAsync(int festivalId);
        Task<FestivalDTO> CreateFestivalAsync(CreateFestivalDTO createFestivalDTO);
        Task<FestivalDTO> UpdateFestivalAsync(UpdateFestivalDTO updateFestivalDTO);
        Task DeleteFestivalAsync(int festivalId);
    }
}
