
namespace SF.Domain.Entities
{
    public class BandGenreEntity
    {
        public int BandId { get; set; }
        public int GenreId { get; set; }

        public GenreEntity Genre { get; set; }
        public BandEntity Band { get; set; }
    }
}
