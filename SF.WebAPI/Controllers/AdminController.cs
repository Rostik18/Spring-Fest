using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.WebAPI.Models.Admins;
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
    }
}