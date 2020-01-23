using SF.Domain.Entities.Base;
using System.Collections.Generic;

namespace SF.Domain.Entities
{
    public class PartnerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<PartnerFestivalEntity> PartnerFestivals { get; set; }
    }
}
