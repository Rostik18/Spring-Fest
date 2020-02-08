using SF.WebAPI.Models.CustomValidations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Festivals
{
    public class UpdateFestivalViewModel
    {
        [Required]
        [GreaterThanZero]
        public int Id { get; set; }


        [Range(2000, 3000, ErrorMessage = "Year must be between 2000 and 3000.")]
        public int? Year { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        [ItemsGreaterThanZero]
        public IList<int> PartnerIdsToAdd { get; set; }

        [ItemsGreaterThanZero]
        public IList<int> PartnerIdsToRemove { get; set; }
    }
}
