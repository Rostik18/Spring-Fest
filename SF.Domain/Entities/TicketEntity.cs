using SF.Domain.Entities.Base;
using SF.Domain.Enumerations;
using System;

namespace SF.Domain.Entities
{
    public class TicketEntity : BaseEntity
    {
        public int Price { get; set; }
        public DateTimeOffset BeginingTime { get; set; }
        public TimeSpan Duration { get; set; }
        public TicketType Type { get; set; }
        public int FestivalId { get; set; }
    }
}
