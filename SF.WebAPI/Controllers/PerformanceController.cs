using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.Services.Models.Performances;
using SF.WebAPI.Models;
using SF.WebAPI.Models.CustomValidations;
using SF.WebAPI.Models.Performances;
using System.Threading.Tasks;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PerformanceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPerformanceService _performanceService;

        public PerformanceController(IMapper mapper, IPerformanceService performanceService)
        {
            _mapper = mapper;
            _performanceService = performanceService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPerformancesPageAsync([FromQuery] [GreaterThanZero] int page,
                                                                  [FromQuery] [GreaterThanZero] int pageSize,
                                                                  [FromQuery] PerformanceFilterViewModel performanceFilterViewModel)
        {
            var performanceFilterDTO = _mapper.Map<PerformanceFilterDTO>(performanceFilterViewModel);

            var pagedResultDTO = await _performanceService.GetPerformancesPageAsync(page, pageSize, performanceFilterDTO);
            var pagedResultViewModel = _mapper.Map<PagedResultViewModel<PerformanceViewModel>>(pagedResultDTO);

            return Ok(pagedResultViewModel);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPerformanceByIdAsync([GreaterThanZero] int id)
        {
            var PerformanceDTO = await _performanceService.GetPerformanceByIdAsync(id);

            var PerformanceViewModel = _mapper.Map<PerformanceViewModel>(PerformanceDTO);

            return Ok(PerformanceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerformanceAsync([FromBody] CreatePerformanceViewModel createPerformanceViewModel)
        {
            var createPerformanceDTO = _mapper.Map<CreatePerformanceDTO>(createPerformanceViewModel);

            var PerformanceDTO = await _performanceService.CreatePerformanceAsync(createPerformanceDTO);

            var PerformanceViewModel = _mapper.Map<PerformanceViewModel>(PerformanceDTO);

            return Ok(PerformanceViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerformanceAsync([FromBody] UpdatePerformanceViewModel updatePerformanceViewModel)
        {
            var updatePerformanceDTO = _mapper.Map<UpdatePerformanceDTO>(updatePerformanceViewModel);

            var PerformanceDTO = await _performanceService.UpdatePerformanceAsync(updatePerformanceDTO);

            var PerformanceViewModel = _mapper.Map<PerformanceViewModel>(PerformanceDTO);

            return Ok(PerformanceViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformanceAsync([GreaterThanZero] int id)
        {
            await _performanceService.DeletePerformanceAsync(id);

            return NoContent();
        }
    }
}
