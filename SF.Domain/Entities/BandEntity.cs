using SF.Domain.Entities.Base;
using System.Collections.Generic;

namespace SF.Domain.Entities
{
    public class BandEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }

        public List<BandGenreEntity> BandGenres { get; set; }
        public List<PerformanceEntity> Performances { get; set; }
    }
}
