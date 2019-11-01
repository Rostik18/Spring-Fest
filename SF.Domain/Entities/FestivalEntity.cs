using SF.Domain.Entities.Base;

namespace SF.Domain.Entities
{
    public class FestivalEntity : BaseEntity
    {
        public string Year { get; set; }
        public string Location { get; set; }
    }
}
