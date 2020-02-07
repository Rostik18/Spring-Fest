using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.Services.Models.Tickets;
using SF.WebAPI.Models.CustomValidations;
using SF.WebAPI.Models.Tickets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITicketService _ticketService;

        public TicketController(IMapper mapper, ITicketService ticketService)
        {
            _mapper = mapper;
            _ticketService = ticketService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllTicketsAsync([FromQuery] TicketFilterViewModel ticketFilterViewModel)
        {
            var ticketFilterDTO = _mapper.Map<TicketFilterDTO>(ticketFilterViewModel);

            var ticketsDTO = await _ticketService.GetAllTicketsAsync(ticketFilterDTO);

            var ticketsViewModel = _mapper.Map<List<TicketViewModel>>(ticketsDTO);

            return Ok(ticketsViewModel);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTicketByIdAsync([GreaterThanZero] int id)
        {
            var ticketDTO = await _ticketService.GetTicketByIdAsync(id);

            var ticketViewModel = _mapper.Map<TicketViewModel>(ticketDTO);

            return Ok(ticketViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicketAsync([FromBody]CreateTicketViewModel createTicketViewModel)
        {
            var createTicketDTO = _mapper.Map<CreateTicketDTO>(createTicketViewModel);

            var ticketDTO = await _ticketService.CreateTicketAsync(createTicketDTO);

            var ticketViewModel = _mapper.Map<TicketViewModel>(ticketDTO);

            return Ok(ticketViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicketAsync([FromBody]UpdateTicketViewModel updateTicketViewModel)
        {
            var updateTicketDTO = _mapper.Map<UpdateTicketDTO>(updateTicketViewModel);

            var ticketDTO = await _ticketService.UpdateTicketAsync(updateTicketDTO);

            var ticketViewModel = _mapper.Map<TicketViewModel>(ticketDTO);

            return Ok(ticketViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketAsync([GreaterThanZero]int id)
        {
            await _ticketService.DeleteTicketAsync(id);

            return NoContent();
        }
    }
}
