﻿using SF.Domain.Entities.Base;
using System.Collections.Generic;

namespace SF.Domain.Entities
{
    public class FestivalEntity : BaseEntity
    {
        public int Year { get; set; }
        public string Location { get; set; }

        public List<PerformanceEntity> Performances { get; set; }
        public List<PartnerFestivalEntity> PartnerFestivals { get; set; }
        public List<TicketEntity> Tickets { get; set; }
    }
}
