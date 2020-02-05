using SF.Services.Models.Enumerations;
using SF.Services.Models.Festivals;
using System;

namespace SF.Services.Models.Tickets
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTimeOffset BeginingTime { get; set; }
        public int Duration { get; set; }
        public TicketType Type { get; set; }

        public FestivalDTO Festival { get; set; }
    }
}
