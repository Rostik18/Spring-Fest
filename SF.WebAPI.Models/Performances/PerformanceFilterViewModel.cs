using SF.WebAPI.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Performances
{
    public class PerformanceFilterViewModel
    {
        [Required]
        [GreaterThanZero]
        public int FestivalId { get; set; }

        [GreaterThanZero]
        public int? StageId { get; set; }
    }
}
