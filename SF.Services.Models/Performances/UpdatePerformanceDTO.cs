using System;

namespace SF.Services.Models.Performances
{
    public class UpdatePerformanceDTO
    {
        public int Id { get; set; }
        public DateTimeOffset? BeginingTime { get; set; }
        public TimeSpan? Duration { get; set; }

        public int? StageId { get; set; }
    }
}
