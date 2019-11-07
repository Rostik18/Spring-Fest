using SF.Domain.Entities.Base;
using System.Collections.Generic;

namespace SF.Domain.Entities
{
    public class StageEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<PerformanceEntity> Performances { get; set; }
    }
}
