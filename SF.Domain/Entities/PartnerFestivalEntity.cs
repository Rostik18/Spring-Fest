
namespace SF.Domain.Entities
{
    public class PartnerFestivalEntity
    {
        public int PartnerId { get; set; }
        public int FestivalId { get; set; }

        public PartnerEntity Partner { get; set; }
        public FestivalEntity Festival { get; set; }
    }
}
