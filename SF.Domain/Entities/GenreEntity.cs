using SF.Domain.Entities.Base;
using System.Collections.Generic;

namespace SF.Domain.Entities
{
    public class GenreEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<BandGenreEntity> BandGenres { get; set; }
    }
}
