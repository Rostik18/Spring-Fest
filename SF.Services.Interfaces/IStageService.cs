using SF.Services.Models.Stages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IStageService
    {
        Task<List<StageDTO>> GetAllStagesAsync();
        Task<StageDTO> GetStageByIdAsync(int stageId);
        Task<StageDTO> CreateStageAsync(CreateStageDTO createStageDTO);
        Task<StageDTO> UpdateStageAsync(UpdateStageDTO updateStageDTO);
        Task DeleteStageAsync(int stageId);
    }
}
