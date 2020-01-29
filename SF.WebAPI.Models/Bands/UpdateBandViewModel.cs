using SF.WebAPI.Models.CustomValidations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Bands
{
    public class UpdateBandViewModel
    {
        [Required]
        [GreaterThanZero]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string PhotoURL { get; set; }

        [ItemsGreaterThanZero]
        public IList<int> GenreIdsToAdd { get; set; }

        [ItemsGreaterThanZero]
        public IList<int> GenreIdsToRemove { get; set; }
    }
}
