using SF.Domain.Entities.Base;

namespace SF.Domain.Entities
{
    public class BandEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
