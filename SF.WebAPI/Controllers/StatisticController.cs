using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.WebAPI.Models.CustomValidations;
using SF.WebAPI.Models.Statistics;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStatisticService _statisticService;

        public StatisticController(IMapper mapper, IStatisticService statisticService)
        {
            _mapper = mapper;
            _statisticService = statisticService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFestivalStatisticAsync([FromQuery] [GreaterThanZero] int festivalId)
        {
            var festivalStatisticDTO = await _statisticService.GetFestivalStatisticAsync(festivalId);
            var festivalStatisticViewModel = _mapper.Map<FestivalStatisticViewModel>(festivalStatisticDTO);

            return Ok(festivalStatisticViewModel);
        }
    }
}
