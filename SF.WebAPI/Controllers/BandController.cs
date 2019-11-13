using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        public BandController()
        {

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllBendsAsync()
        {
            return Ok();
        }
    }
}