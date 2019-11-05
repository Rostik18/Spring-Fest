﻿using SF.Domain.Entities.Base;
using System;

namespace SF.Domain.Entities
{
    public class PerformanceEntity : BaseEntity
    {
        public DateTimeOffset BeginingTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int BandId { get; set; }
        public int StageId { get; set; }
        public int FestivalId { get; set; }
    }
}