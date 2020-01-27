using SF.WebAPI.Models.Bands;
using SF.WebAPI.Models.Festivals;
using SF.WebAPI.Models.Stages;
using System;

namespace SF.WebAPI.Models.Performances
{
    public class PerformanceViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset BeginingTime { get; set; }
        public TimeSpan Duration { get; set; }

        public BandViewModel Band { get; set; }
        public StageViewModel Stage { get; set; }
        public FestivalViewModel Festival { get; set; }
    }
}
