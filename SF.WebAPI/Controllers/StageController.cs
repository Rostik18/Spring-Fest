using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.Services.Models.Stages;
using SF.WebAPI.Models.CustomValidations;
using SF.WebAPI.Models.Stages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStageService _stageService;

        public StageController(IMapper mapper, IStageService stageService)
        {
            _mapper = mapper;
            _stageService = stageService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllStagesAsync()
        {
            var stagesDTO = await _stageService.GetAllStagesAsync();

            var stagesViewModel = _mapper.Map<List<StageViewModel>>(stagesDTO);

            return Ok(stagesViewModel);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetStageByIdAsync([GreaterThanZero] int id)
        {
            var stageDTO = await _stageService.GetStageByIdAsync(id);

            var stageViewModel = _mapper.Map<StageViewModel>(stageDTO);

            return Ok(stageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStageAsync([FromBody]CreateStageViewModel createStageViewModel)
        {
            var createStageDTO = _mapper.Map<CreateStageDTO>(createStageViewModel);

            var stageDTO = await _stageService.CreateStageAsync(createStageDTO);

            var stageViewModel = _mapper.Map<StageViewModel>(stageDTO);

            return Ok(stageViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStageAsync([FromBody]UpdateStageViewModel updateStageViewModel)
        {
            var updateStageDTO = _mapper.Map<UpdateStageDTO>(updateStageViewModel);

            var stageDTO = await _stageService.UpdateStageAsync(updateStageDTO);

            var stageViewModel = _mapper.Map<StageViewModel>(stageDTO);

            return Ok(stageViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStageAsync([GreaterThanZero]int id)
        {
            await _stageService.DeleteStageAsync(id);

            return NoContent();
        }
    }
}
