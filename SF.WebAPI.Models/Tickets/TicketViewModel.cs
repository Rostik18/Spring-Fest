using SF.WebAPI.Models.Enumerations;
using SF.WebAPI.Models.Festivals;
using SF.WebAPI.Models.Purchases;
using System;
using System.Collections.Generic;

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
        public List<PurchaseViewModel> Purchases { get; set; }
    }
}
