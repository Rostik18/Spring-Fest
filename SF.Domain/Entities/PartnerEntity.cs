using SF.Domain.Entities.Base;

namespace SF.Domain.Entities
{
    public class PartnerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FestivalId { get; set; }

        public FestivalEntity Festival { get; set; }
    }
}
