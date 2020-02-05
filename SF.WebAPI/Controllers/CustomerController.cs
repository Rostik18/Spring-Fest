using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.WebAPI.Models;
using SF.WebAPI.Models.Customers;
using SF.WebAPI.Models.CustomValidations;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersPageAsync([FromQuery] [GreaterThanZero] int page,
                                                               [FromQuery] [GreaterThanZero] int pageSize)
        {
            var pagedResultDTO = await _customerService.GetCustomersPageAsync(page, pageSize);
            var pagedResultViewModel = _mapper.Map<PagedResultViewModel<CustomerViewModel>>(pagedResultDTO);

            return Ok(pagedResultViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync([GreaterThanZero] int id)
        {
            var customerDTO = await _customerService.GetCustomerByIdAsync(id);

            var customerViewModel = _mapper.Map<CustomerViewModel>(customerDTO);

            return Ok(customerViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync([GreaterThanZero] int id)
        {
            await _customerService.DeleteCustomerAsync(id);

            return NoContent();
        }
    }
}
