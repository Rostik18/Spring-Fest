using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.Services.Models.Admins;
using SF.WebAPI.Models;
using SF.WebAPI.Models.Admins;
using SF.WebAPI.Models.CustomValidations;
using System.Threading.Tasks;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;

        public AdminController(IMapper mapper, IAdminService adminService)
        {
            _mapper = mapper;
            _adminService = adminService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel loginViewModel)
        {
            var authorizedAdminDTO = await _adminService.AuthorizeAsync(loginViewModel.Login, loginViewModel.Password);
            var authorizedUserViewModel = _mapper.Map<AuthorizedAdminViewModel>(authorizedAdminDTO);

            return Ok(authorizedUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminAsync([FromBody] CreateAdminViewModel createAdminViewModel)
        {
            var isAdminCreated = await _adminService.CreateAdminAsync(createAdminViewModel.Login, createAdminViewModel.Password);

            return Ok(isAdminCreated);
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminsPageAsync([FromQuery] [GreaterThanZero] int page,
                                                            [FromQuery] [GreaterThanZero] int pageSize)
        {
            var pagedResultDTO = await _adminService.GetAdminsPageAsync(page, pageSize);
            var pagedResultViewModel = _mapper.Map<PagedResultViewModel<AdminViewModel>>(pagedResultDTO);

            return Ok(pagedResultViewModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdminAsync([FromQuery] [GreaterThanZero] int id)
        {
            await _adminService.DeleteAdminAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdminAsync([FromBody] UpdateAdminViewModel updateAdminViewModel)
        {
            var updateAdminDTO = _mapper.Map<UpdateAdminDTO>(updateAdminViewModel);
            var updatedAdminDTO = await _adminService.UpdateAdminAsync(updateAdminDTO);
            var updatedAdminViewModel = _mapper.Map<AdminViewModel>(updatedAdminDTO);

            return Ok(updatedAdminViewModel);
        }
    }
}