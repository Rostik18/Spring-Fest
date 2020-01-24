using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.Services.Models.Festivals;
using SF.WebAPI.Models.CustomValidations;
using SF.WebAPI.Models.Festivals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FestivalController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFestivalService _festivalService;

        public FestivalController(IMapper mapper, IFestivalService festivalService)
        {
            _mapper = mapper;
            _festivalService = festivalService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFestivalsAsync()
        {
            var festivalsDTO = await _festivalService.GetAllFestivalsAsync();

            var festivalsViewModel = _mapper.Map<List<FestivalViewModel>>(festivalsDTO);

            return Ok(festivalsViewModel);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFestivalByIdAsync([GreaterThanZero] int id)
        {
            var festivalDTO = await _festivalService.GetFestivalByIdAsync(id);

            var festivalViewModel = _mapper.Map<FestivalViewModel>(festivalDTO);

            return Ok(festivalViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFestivalAsync([FromBody]CreateFestivalViewModel createFestivalViewModel)
        {
            var createFestivalDTO = _mapper.Map<CreateFestivalDTO>(createFestivalViewModel);

            var festivalDTO = await _festivalService.CreateFestivalAsync(createFestivalDTO);

            var festivalViewModel = _mapper.Map<FestivalViewModel>(festivalDTO);

            return Ok(festivalViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFestivalAsync([FromBody]UpdateFestivalViewModel updateFestivalViewModel)
        {
            var updateFestivalDTO = _mapper.Map<UpdateFestivalDTO>(updateFestivalViewModel);

            var festivalDTO = await _festivalService.UpdateFestivalAsync(updateFestivalDTO);

            var festivalViewModel = _mapper.Map<FestivalViewModel>(festivalDTO);

            return Ok(festivalViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFestivalAsync([GreaterThanZero]int id)
        {
            await _festivalService.DeleteFestivalAsync(id);

            return NoContent();
        }
    }
}
