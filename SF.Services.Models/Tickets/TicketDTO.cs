using SF.Services.Models.Enumerations;
using SF.Services.Models.Festivals;
using SF.Services.Models.Purchases;
using System;
using System.Collections.Generic;

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
        public List<PurchaseDTO> Purchases { get; set; }
    }
}
