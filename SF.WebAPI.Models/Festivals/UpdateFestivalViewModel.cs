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

        [MaxLength(4)]
        [RegularExpression(@"[2]{1}[0-9]{3}")]
        public string Year { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        [ItemsGreaterThanZero]
        public IList<int> PartnerIdsToAdd { get; set; }

        [ItemsGreaterThanZero]
        public IList<int> PartnerIdsToRemove { get; set; }
    }
}
