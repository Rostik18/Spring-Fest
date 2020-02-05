using SF.WebAPI.Models.Enumerations;
using SF.WebAPI.Models.Festivals;
using System;

namespace SF.WebAPI.Models.Tickets
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTimeOffset BeginingTime { get; set; }
        public int Duration { get; set; }
        public TicketType Type { get; set; }

        public FestivalViewModel Festival { get; set; }
    }
}
