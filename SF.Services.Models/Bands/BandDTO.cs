using SF.Services.Models.Genres;
using System.Collections.Generic;

namespace SF.Services.Models.Bands
{
    public class BandDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<GenreDTO> BandGenres { get; set; }
    }
}
