using SF.WebAPI.Models.CustomValidations;
using System;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Performances
{
    public class CreatePerformanceViewModel
    {
        [Required]
        [GreaterThanCurrentDate]
        public DateTimeOffset BeginingTime { get; set; }

        [Required]
        [TimeSpan]
        public TimeSpan Duration { get; set; }

        [Required]
        [GreaterThanZero]
        public int BandId { get; set; }

        [Required]
        [GreaterThanZero]
        public int StageId { get; set; }

        [Required]
        [GreaterThanZero]
        public int FestivalId { get; set; }
    }
}
