using MKS.WebAPI.Models.CustomValidations;
using SF.WebAPI.Models.CustomValidations;
using System;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Performances
{
    public class UpdatePerformanceViewModel
    {
        [Required]
        [GreaterThanZero]
        public int Id { get; set; }

        public DateTimeOffset? BeginingTime { get; set; }

        [TimeSpan]
        public TimeSpan? Duration { get; set; }

        [GreaterThanZero]
        public int? StageId { get; set; }
    }
}
