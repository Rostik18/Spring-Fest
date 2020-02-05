using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Customers
{
    public class CreateCustomerViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
    }
}
