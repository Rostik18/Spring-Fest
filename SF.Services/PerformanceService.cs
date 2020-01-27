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
using SF.Services.Models.Performances;

namespace SF.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;

        public PerformanceService(IMapper mapper, SFDbContext dbContext)
        {
            _mapper = mapper;
            _DBContext = dbContext;
        }

        public async Task<PerformanceDTO> CreatePerformanceAsync(CreatePerformanceDTO createPerformanceDTO)
        {
            var isBandExist = await _DBContext.Bands.AnyAsync(b => b.Id == createPerformanceDTO.BandId);
            if (!isBandExist)
            {
                throw new ItemNotFoundException($"Band with id {createPerformanceDTO.BandId} not found.");
            }

            var isFestivalExist = await _DBContext.Festivals.AnyAsync(f => f.Id == createPerformanceDTO.FestivalId);
            if (!isFestivalExist)
            {
                throw new ItemNotFoundException($"Festival with id {createPerformanceDTO.FestivalId} not found.");
            }

            await CheckStageExisting(createPerformanceDTO.StageId);

            var performance = new PerformanceEntity
            {
                BeginingTime = createPerformanceDTO.BeginingTime,
                Duration = createPerformanceDTO.Duration,
                BandId = createPerformanceDTO.BandId,
                FestivalId = createPerformanceDTO.FestivalId,
                StageId = createPerformanceDTO.StageId
            };

            await _DBContext.Performances.AddAsync(performance);
            await _DBContext.SaveChangesAsync();

            performance = await _DBContext.Performances
                .Include(p => p.Band)
                    .ThenInclude(b => b.BandGenres)
                        .ThenInclude(db => db.Genre)
                .Include(p => p.Stage)
                .Include(p => p.Festival)
                .FirstOrDefaultAsync(p => p.Id == performance.Id);

            var performanceDTO = _mapper.Map<PerformanceDTO>(performance);

            return performanceDTO;
        }

        public async Task DeletePerformanceAsync(int performanceId)
        {
            var performance = await _DBContext.Performances.FirstOrDefaultAsync(p => p.Id == performanceId);

            if (performance == null)
            {
                throw new ItemNotFoundException($"Performance with id {performanceId} not found.");
            }

            _DBContext.Performances.Remove(performance);
            await _DBContext.SaveChangesAsync();
        }

        public async Task<PerformanceDTO> GetPerformanceByIdAsync(int performanceId)
        {
            var performance = await _DBContext.Performances
                .Include(p => p.Band)
                    .ThenInclude(b => b.BandGenres)
                        .ThenInclude(db => db.Genre)
                .Include(p => p.Stage)
                .Include(p => p.Festival)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == performanceId);

            if (performance == null)
            {
                throw new ItemNotFoundException($"Performance with id {performanceId} not found.");
            }

            var performanceDTO = _mapper.Map<PerformanceDTO>(performance);

            return performanceDTO;
        }

        public async Task<PagedResultDTO<PerformanceDTO>> GetPerformancesPageAsync(int page, int pageSize)
        {
            var query = _DBContext.Performances
                .Include(p => p.Band)
                    .ThenInclude(b => b.BandGenres)
                        .ThenInclude(db => db.Genre)
                .Include(p => p.Stage)
                .Include(p => p.Festival);

            var pagedResult = await _DBContext.GetPage<PerformanceEntity, PerformanceDTO>(_mapper, query, page, pageSize);

            return pagedResult;
        }

        public async Task<PerformanceDTO> UpdatePerformanceAsync(UpdatePerformanceDTO updatePerformanceDTO)
        {
            var performance = await _DBContext.Performances.FirstOrDefaultAsync(p => p.Id == updatePerformanceDTO.Id);

            if (performance == null)
            {
                throw new ItemNotFoundException($"Performance with id {updatePerformanceDTO.Id} not found.");
            }

            //Покращити?
            performance.BeginingTime = updatePerformanceDTO.BeginingTime ?? performance.BeginingTime;
            performance.Duration = updatePerformanceDTO.Duration ?? performance.Duration;

            if (updatePerformanceDTO.StageId.HasValue)
            {
                await CheckStageExisting(updatePerformanceDTO.StageId.Value);
                performance.StageId = updatePerformanceDTO.StageId.Value;
            }

            _DBContext.Performances.Update(performance);
            await _DBContext.SaveChangesAsync();

            performance = await _DBContext.Performances
                .Include(p => p.Band)
                    .ThenInclude(b => b.BandGenres)
                        .ThenInclude(db => db.Genre)
                .Include(p => p.Stage)
                .Include(p => p.Festival)
                .FirstOrDefaultAsync(p => p.Id == performance.Id);

            var performanceDTO = _mapper.Map<PerformanceDTO>(performance);

            return performanceDTO;
        }

        private async Task CheckStageExisting(int stageId)
        {
            var isStageExist = await _DBContext.Stages.AnyAsync(s => s.Id == stageId);

            if (!isStageExist)
            {
                throw new ItemNotFoundException($"Stage with id {stageId} not found.");
            }
        }
    }
}
