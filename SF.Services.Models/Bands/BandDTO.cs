using SF.Services.Models.Genres;
using System.Collections.Generic;

namespace SF.Services.Models.Bands
{
    public class BandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<GenreDTO> Genres { get; set; }
    }
}
