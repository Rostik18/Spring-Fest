using SF.WebAPI.Models.Genres;
using System.Collections.Generic;

namespace SF.WebAPI.Models.Bands
{
    public class BandViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<GenreViewModel> BandGenres { get; set; }
    }
}
