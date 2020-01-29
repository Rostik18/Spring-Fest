using SF.WebAPI.Models.CustomValidations;
using SF.WebAPI.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Tickets
{
    public class UpdateTicketViewModel
    {
        [Required]
        [GreaterThanZero]
        public int Id { get; set; }
        public int? Price { get; set; }
        public DateTimeOffset? BeginingTime { get; set; }

        [GreaterThanZero]
        public int Duration { get; set; }

        [Range(1, 3, ErrorMessage = "Ticket with this type does not exist.")]
        public TicketType? Type { get; set; }

        [GreaterThanZero]
        public int? FestivalId { get; set; }
    }
}
