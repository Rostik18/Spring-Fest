using SF.Domain.Entities.Base;
using System.Collections.Generic;

namespace SF.Domain.Entities
{
    public class FestivalEntity : BaseEntity
    {
        public string Year { get; set; }
        public string Location { get; set; }

        public List<PerformanceEntity> Performances { get; set; }
        public List<PartnerEntity> Partners { get; set; }
        public List<TicketEntity> Tickets { get; set; }
    }
}
