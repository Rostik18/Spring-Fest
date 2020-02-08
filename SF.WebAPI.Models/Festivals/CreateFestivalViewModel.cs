using SF.WebAPI.Models.CustomValidations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Festivals
{
    public class CreateFestivalViewModel
    {
        [Required]
        [Range(2000, 3000, ErrorMessage = "Year must be between 2000 and 3000.")]
        public int Year { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [ItemsGreaterThanZero]
        public IList<int> PartnerIds { get; set; }
    }
}
