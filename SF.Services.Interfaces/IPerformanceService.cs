using SF.Services.Models;
using SF.Services.Models.Performances;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IPerformanceService
    {
        Task<PagedResultDTO<PerformanceDTO>> GetPerformancesPageAsync(int page, int pageSize);
        Task<PerformanceDTO> GetPerformanceByIdAsync(int performanceId);
        Task<PerformanceDTO> CreatePerformanceAsync(CreatePerformanceDTO createPerformanceDTO);
        Task<PerformanceDTO> UpdatePerformanceAsync(UpdatePerformanceDTO updatePerformanceDTO);
        Task DeletePerformanceAsync(int performanceId);
    }
}
