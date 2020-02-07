using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.Services.Models.Bands;
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
        public async Task<IActionResult> GetBandsPageAsync([FromQuery] [GreaterThanZero] int page,
                                                           [FromQuery] [GreaterThanZero] int pageSize,
                                                           [FromQuery] BandFilterViewModel bandFilterViewModel)
        {
            var bandFilterDTO = _mapper.Map<BandFilterDTO>(bandFilterViewModel);

            var pagedResultDTO = await _bandService.GetBandsPageAsync(page, pageSize, bandFilterDTO);
            var pagedResultViewModel = _mapper.Map<PagedResultViewModel<BandViewModel>>(pagedResultDTO);

            return Ok(pagedResultViewModel);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBandByIdAsync([GreaterThanZero] int id)
        {
            var bandDTO = await _bandService.GetBandByIdAsync(id);

            var bandViewModel = _mapper.Map<BandViewModel>(bandDTO);

            return Ok(bandViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBandAsync([FromBody] CreateBandViewModel createBandViewModel)
        {
            var createBandDTO = _mapper.Map<CreateBandDTO>(createBandViewModel);

            var bandDTO = await _bandService.CreateBandAsync(createBandDTO);

            var bandViewModel = _mapper.Map<BandViewModel>(bandDTO);

            return Ok(bandViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBandAsync([FromBody] UpdateBandViewModel updateBandViewModel)
        {
            var updateBandDTO = _mapper.Map<UpdateBandDTO>(updateBandViewModel);

            var bandDTO = await _bandService.UpdateBandAsync(updateBandDTO);

            var bandViewModel = _mapper.Map<BandViewModel>(bandDTO);

            return Ok(bandViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBandAsync([GreaterThanZero] int id)
        {
            await _bandService.DeleteBandAsync(id);

            return NoContent();
        }
    }
}