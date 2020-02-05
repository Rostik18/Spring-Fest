using SF.Services.Models.Customers;
using SF.Services.Models.Tickets;
using System;

namespace SF.Services.Models.Purchases
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public Guid BarCode { get; set; }

        public TicketDTO Ticket { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
