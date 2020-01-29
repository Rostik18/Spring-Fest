using SF.WebAPI.Models.CustomValidations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Bands
{
    public class CreateBandViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(1000)]
        public string PhotoURL { get; set; }

        [Required]
        [ItemsGreaterThanZero]
        public IList<int> GenreIds { get; set; }
    }
}
