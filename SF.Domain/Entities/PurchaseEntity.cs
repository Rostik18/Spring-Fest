using SF.Domain.Entities.Base;
using System;

namespace SF.Domain.Entities
{
    public class PurchaseEntity : BaseEntity
    {
        public bool IsAvailable { get; set; }
        public Guid BarCode { get; set; }
        public int CustomerId { get; set; }
        public int TicketId { get; set; }

        public TicketEntity Ticket { get; set; }
        public CustomerEntity Customer { get; set; }
    }
}
