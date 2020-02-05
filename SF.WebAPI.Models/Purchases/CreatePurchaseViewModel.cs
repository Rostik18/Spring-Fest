using SF.WebAPI.Models.Customers;
using SF.WebAPI.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Purchases
{
    public class CreatePurchaseViewModel
    {
        [Required]
        public CreateCustomerViewModel Customer { get; set; }

        [Required]
        [GreaterThanZero]
        public int TicketId { get; set; }
    }
}
