using Microsoft.EntityFrameworkCore;
using SF.Domain.Enumerations;
using SF.Infrastructure;
using SF.Services.Interfaces;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models.Statistics;
using System.Linq;
using System.Threading.Tasks;

namespace SF.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly SFDbContext _DBContext;

        public StatisticService(SFDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        public async Task<FestivalStatisticDTO> GetFestivalStatisticAsync(int festivalId)
        {
            bool isFestivalExist = await _DBContext.Festivals.AnyAsync(f => f.Id == festivalId);

            if (!isFestivalExist)
            {
                throw new ItemNotFoundException($"Festival with id {festivalId} not found.");
            }

            int uniqueVisitorsCount = await _DBContext.Purchases.Where(p => p.Ticket.FestivalId == festivalId && p.Ticket.Type == TicketType.Festival).CountAsync();

            int tentTicketsSoldCount = await _DBContext.Purchases.Where(p => p.Ticket.FestivalId == festivalId && p.Ticket.Type == TicketType.Tent).CountAsync();
            int parkingTicketsSoldCount = await _DBContext.Purchases.Where(p => p.Ticket.FestivalId == festivalId && p.Ticket.Type == TicketType.Parking).CountAsync();

            int benefit = await _DBContext.Purchases.Where(p => p.Ticket.FestivalId == festivalId).SumAsync(p => p.Ticket.Price);

            var festivalStatisticDTO = new FestivalStatisticDTO
            {
                UniqueVisitorsCount = uniqueVisitorsCount,

                FestivalTicketsSoldCount = uniqueVisitorsCount,
                TentTicketsSoldCount = tentTicketsSoldCount,
                ParkingTicketsSoldCount = parkingTicketsSoldCount,

                Benefit = benefit
            };

            return festivalStatisticDTO;
        }
    }
}
