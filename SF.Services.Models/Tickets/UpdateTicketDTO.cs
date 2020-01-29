using SF.Services.Models.Enumerations;
using System;

namespace SF.Services.Models.Tickets
{
    public class UpdateTicketDTO
    {
        public int Id { get; set; }
        public int? Price { get; set; }
        public DateTimeOffset? BeginingTime { get; set; }
        public int? Duration { get; set; }
        public TicketType? Type { get; set; }
        public int? FestivalId { get; set; }
    }
}
