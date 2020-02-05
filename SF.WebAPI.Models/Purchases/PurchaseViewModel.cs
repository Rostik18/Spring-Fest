using SF.WebAPI.Models.Customers;
using SF.WebAPI.Models.Tickets;
using System;

namespace SF.WebAPI.Models.Purchases
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public Guid BarCode { get; set; }

        public TicketViewModel Ticket { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}
