using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Domain.Enumerations;
using SF.Infrastructure;
using SF.Services.Interfaces;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models.Tickets;

namespace SF.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;

        public TicketService(IMapper mapper, SFDbContext dbContext)
        {
            _mapper = mapper;
            _DBContext = dbContext;
        }

        public async Task<TicketDTO> CreateTicketAsync(CreateTicketDTO createTicketDTO)
        {
            var isFestivalExist = await _DBContext.Festivals.AnyAsync(f => f.Id == createTicketDTO.FestivalId);

            if (!isFestivalExist)
            {
                throw new ItemNotFoundException($"Festival with id {createTicketDTO.FestivalId} not found.");
            }

            var ticket = new TicketEntity
            {
                Price = createTicketDTO.Price,
                BeginingTime = createTicketDTO.BeginingTime,
                Duration = createTicketDTO.Duration,
                Type = (TicketType)(int)createTicketDTO.Type,
                FestivalId = createTicketDTO.FestivalId
            };

            await _DBContext.Tickets.AddAsync(ticket);
            await _DBContext.SaveChangesAsync();

            ticket = await _DBContext.Tickets
                .Include(t => t.Festival)
                .AsNoTracking().FirstOrDefaultAsync(t => t.Id == ticket.Id);

            var ticketDTO = _mapper.Map<TicketDTO>(ticket);

            return ticketDTO;
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            var ticket = await _DBContext.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket == null)
            {
                throw new ItemNotFoundException($"Ticket with id {ticketId} not found.");
            }

            _DBContext.Tickets.Remove(ticket);
            await _DBContext.SaveChangesAsync();
        }

        public async Task<List<TicketDTO>> GetAllTicketsAsync()
        {
            var tickets = await _DBContext.Tickets
                .Include(t => t.Festival)
                .Include(t => t.Purchases)
                .AsNoTracking().ToListAsync();

            var ticketsDTO = _mapper.Map<List<TicketDTO>>(tickets);

            return ticketsDTO;
        }

        public async Task<TicketDTO> GetTicketByIdAsync(int ticketId)
        {
            var ticket = await _DBContext.Tickets
                 .Include(t => t.Festival)
                 .Include(t => t.Purchases)
                 .AsNoTracking().FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket == null)
            {
                throw new ItemNotFoundException($"Ticket with id {ticketId} not found.");
            }

            var ticketsDTO = _mapper.Map<TicketDTO>(ticket);

            return ticketsDTO;
        }

        public async Task<TicketDTO> UpdateTicketAsync(UpdateTicketDTO updateTicketDTO)
        {
            var ticket = await _DBContext.Tickets.FirstOrDefaultAsync(t => t.Id == updateTicketDTO.Id);

            if (ticket == null)
            {
                throw new ItemNotFoundException($"Ticket with id {updateTicketDTO.Id} not found.");
            }

            //Можна покращити?
            ticket.Price = updateTicketDTO.Price ?? ticket.Price;
            ticket.BeginingTime = updateTicketDTO.BeginingTime ?? ticket.BeginingTime;
            ticket.Duration = updateTicketDTO.Duration ?? ticket.Duration;
            if (updateTicketDTO.Type.HasValue)
            {
                ticket.Type = (TicketType)(int)updateTicketDTO.Type.Value;
            }
            if (updateTicketDTO.FestivalId.HasValue)
            {
                var isFestivalExist = await _DBContext.Festivals.AnyAsync(f => f.Id == updateTicketDTO.FestivalId);

                if (!isFestivalExist)
                {
                    throw new ItemNotFoundException($"Festival with id {updateTicketDTO.FestivalId} not found.");
                }

                ticket.FestivalId = updateTicketDTO.FestivalId.Value;
            }

            _DBContext.Tickets.Update(ticket);
            await _DBContext.SaveChangesAsync();

            ticket = await _DBContext.Tickets
                .Include(t => t.Festival)
                .AsNoTracking().FirstOrDefaultAsync(t => t.Id == ticket.Id);

            var ticketDTO = _mapper.Map<TicketDTO>(ticket);

            return ticketDTO;
        }
    }
}
