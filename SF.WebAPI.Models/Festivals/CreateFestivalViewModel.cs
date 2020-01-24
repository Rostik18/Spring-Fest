using SF.WebAPI.Models.CustomValidations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Festivals
{
    public class CreateFestivalViewModel
    {
        [Required]
        [MaxLength(4)]
        [RegularExpression(@"[2]{1}[0-9]{3}", ErrorMessage = "Year have to look like 2XXX.")]
        public string Year { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [ItemsGreaterThanZero]
        public IList<int> PartnerIds { get; set; }
    }
}
