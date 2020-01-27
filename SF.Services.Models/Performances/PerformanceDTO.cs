using SF.Services.Models.Bands;
using SF.Services.Models.Festivals;
using SF.Services.Models.Stages;
using System;

namespace SF.Services.Models.Performances
{
    public class PerformanceDTO
    {
        public int Id { get; set; }
        public DateTimeOffset BeginingTime { get; set; }
        public TimeSpan Duration { get; set; }

        public BandDTO Band { get; set; }
        public StageDTO Stage { get; set; }
        public FestivalDTO Festival { get; set; }
    }
}
