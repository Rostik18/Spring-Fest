using SF.WebAPI.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Tickets
{
    public class TicketFilterViewModel
    {
        [Required]
        [GreaterThanZero]
        public int FestivalId { get; set; }
    }
}
