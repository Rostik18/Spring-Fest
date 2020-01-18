using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.WebAPI.Models;
using SF.WebAPI.Models.Bands;
using SF.WebAPI.Models.CustomValidations;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BandController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBandService _bandService;

        public BandController(IMapper mapper, IBandService bandService)
        {
            _mapper = mapper;
            _bandService = bandService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetBendsPageAsync([FromQuery] [GreaterThanZero] int page,
                                                           [FromQuery] [GreaterThanZero] int pageSize)
        {
            var pagedResultDTO = await _bandService.GetBandsPageAsync(page, pageSize);
            var pagedResultViewModel = _mapper.Map<PagedResultViewModel<BandViewModel>>(pagedResultDTO);

            return Ok(pagedResultViewModel);
        }
    }
}