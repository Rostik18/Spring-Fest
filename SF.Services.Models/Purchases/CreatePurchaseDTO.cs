using SF.Services.Models.Customers;

namespace SF.Services.Models.Purchases
{
    public class CreatePurchaseDTO
    {
        public CreateCustomerDTO Customer { get; set; }
        public int TicketId { get; set; }
    }
}
