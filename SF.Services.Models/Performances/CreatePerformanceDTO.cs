using System;

namespace SF.Services.Models.Performances
{
    public class CreatePerformanceDTO
    {
        public DateTimeOffset BeginingTime { get; set; }
        public TimeSpan Duration { get; set; }

        public int BandId { get; set; }
        public int StageId { get; set; }
        public int FestivalId { get; set; }
    }
}
