using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.WebAPI.Models;
using SF.WebAPI.Models.Partners;
using SF.WebAPI.Models.CustomValidations;
using SF.Services.Models.Partners;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPartnerService _partnerService;

        public PartnerController(IMapper mapper, IPartnerService partnerService)
        {
            _mapper = mapper;
            _partnerService = partnerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPartnersPageAsync([FromQuery] [GreaterThanZero] int page,
                                                           [FromQuery] [GreaterThanZero] int pageSize)
        {
            var pagedResultDTO = await _partnerService.GetPartnersPageAsync(page, pageSize);
            var pagedResultViewModel = _mapper.Map<PagedResultViewModel<PartnerViewModel>>(pagedResultDTO);

            return Ok(pagedResultViewModel);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPartnerByIdAsync([GreaterThanZero] int id)
        {
            var partnerDTO = await _partnerService.GetPartnerByIdAsync(id);

            var partnerViewModel = _mapper.Map<PartnerViewModel>(partnerDTO);

            return Ok(partnerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartnerAsync([FromBody] CreatePartnerViewModel createPartnerViewModel)
        {
            var createPartnerDTO = _mapper.Map<CreatePartnerDTO>(createPartnerViewModel);

            var partnerDTO = await _partnerService.CreatePartnerAsync(createPartnerDTO);

            var partnerViewModel = _mapper.Map<PartnerViewModel>(partnerDTO);

            return Ok(partnerViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePartnerAsync([FromBody] UpdatePartnerViewModel updatePartnerViewModel)
        {
            var updatePartnerDTO = _mapper.Map<UpdatePartnerDTO>(updatePartnerViewModel);

            var partnerDTO = await _partnerService.UpdatePartnerAsync(updatePartnerDTO);

            var partnerViewModel = _mapper.Map<PartnerViewModel>(partnerDTO);

            return Ok(partnerViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartnerAsync([GreaterThanZero] int id)
        {
            await _partnerService.DeletePartnerAsync(id);

            return NoContent();
        }
    }
}