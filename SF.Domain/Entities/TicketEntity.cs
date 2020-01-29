using SF.Domain.Entities.Base;
using SF.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace SF.Domain.Entities
{
    public class TicketEntity : BaseEntity
    {
        public int Price { get; set; }
        public DateTimeOffset BeginingTime { get; set; }
        public int Duration { get; set; }
        public TicketType Type { get; set; }
        public int FestivalId { get; set; }

        public FestivalEntity Festival { get; set; }
        public List<PurchaseEntity> Purchases { get; set; }
    }
}
