using SF.Services.Models.Tickets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketDTO>> GetAllTicketsAsync(TicketFilterDTO ticketFilterDTO);
        Task<TicketDTO> GetTicketByIdAsync(int ticketId);
        Task<TicketDTO> CreateTicketAsync(CreateTicketDTO createTicketDTO);
        Task<TicketDTO> UpdateTicketAsync(UpdateTicketDTO updateTicketDTO);
        Task DeleteTicketAsync(int ticketId);
    }
}
