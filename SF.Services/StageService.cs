using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Infrastructure;
using SF.Services.Interfaces;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models.Stages;

namespace SF.Services
{
    public class StageService : IStageService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;

        public StageService(IMapper mapper, SFDbContext dbContext)
        {
            _mapper = mapper;
            _DBContext = dbContext;
        }

        public async Task<StageDTO> CreateStageAsync(CreateStageDTO createStageDTO)
        {
            var stage = new StageEntity
            {
                Name = createStageDTO.Name
            };

            await _DBContext.Stages.AddAsync(stage);
            await _DBContext.SaveChangesAsync();

            var stageDTO = _mapper.Map<StageDTO>(stage);

            return stageDTO;
        }

        public async Task DeleteStageAsync(int stageId)
        {
            var stage = await _DBContext.Stages.FirstOrDefaultAsync(s => s.Id == stageId);

            if (stage == null)
            {
                throw new ItemNotFoundException($"Stage with id {stageId} not found.");
            }

            _DBContext.Stages.Remove(stage);
            await _DBContext.SaveChangesAsync();
        }

        public async Task<List<StageDTO>> GetAllStagesAsync()
        {
            var stages = await _DBContext.Stages.AsNoTracking().ToListAsync();

            var stagesDTO = _mapper.Map<List<StageDTO>>(stages);

            return stagesDTO;
        }

        public async Task<StageDTO> GetStageByIdAsync(int stageId)
        {
            var stage = await _DBContext.Stages.AsNoTracking().FirstOrDefaultAsync(s => s.Id == stageId);

            if (stage == null)
            {
                throw new ItemNotFoundException($"Stage with id {stageId} not found.");
            }

            var stageDTO = _mapper.Map<StageDTO>(stage);

            return stageDTO;
        }

        public async Task<StageDTO> UpdateStageAsync(UpdateStageDTO updateStageDTO)
        {
            var stage = await _DBContext.Stages.FirstOrDefaultAsync(s => s.Id == updateStageDTO.Id);

            if (stage == null)
            {
                throw new ItemNotFoundException($"Stage with id {updateStageDTO.Id} not found.");
            }

            stage.Name = updateStageDTO.Name;

            _DBContext.Stages.Update(stage);
            await _DBContext.SaveChangesAsync();

            var stageDTO = _mapper.Map<StageDTO>(stage);

            return stageDTO;
        }
    }
}
