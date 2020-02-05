using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.WebAPI.Models;
using SF.WebAPI.Models.Purchases;
using SF.WebAPI.Models.CustomValidations;
using System.Threading.Tasks;
using SF.Services.Models.Purchases;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IMapper mapper, IPurchaseService purchaseService)
        {
            _mapper = mapper;
            _purchaseService = purchaseService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePurchaseAsync([FromBody]CreatePurchaseViewModel createPurchaseViewModel)
        {
            var createPurchaseDTO = _mapper.Map<CreatePurchaseDTO>(createPurchaseViewModel);

            var purchaseDTO = await _purchaseService.CreatePurchaseAsync(createPurchaseDTO);

            var purchase = _mapper.Map<PurchaseViewModel>(purchaseDTO);

            return Ok(purchase);
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchasesPageAsync([FromQuery] [GreaterThanZero] int page,
                                                               [FromQuery] [GreaterThanZero] int pageSize)
        {
            var pagedResultDTO = await _purchaseService.GetPurchasesPageAsync(page, pageSize);
            var pagedResultViewModel = _mapper.Map<PagedResultViewModel<PurchaseViewModel>>(pagedResultDTO);

            return Ok(pagedResultViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseByIdAsync([GreaterThanZero] int id)
        {
            var purchaseDTO = await _purchaseService.GetPurchaseByIdAsync(id);

            var purchaseViewModel = _mapper.Map<PurchaseViewModel>(purchaseDTO);

            return Ok(purchaseViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseAsync([GreaterThanZero] int id)
        {
            await _purchaseService.DeletePurchaseAsync(id);

            return NoContent();
        }
    }
}
