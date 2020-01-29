using SF.WebAPI.Models.CustomValidations;
using SF.WebAPI.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Tickets
{
    public class CreateTicketViewModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [GreaterThanCurrentDate]
        public DateTimeOffset BeginingTime { get; set; }

        [Required]
        [GreaterThanZero]
        public int Duration { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Ticket with this type does not exist.")]
        public TicketType Type { get; set; }

        [Required]
        [GreaterThanZero]
        public int FestivalId { get; set; }
    }
}
