using SF.WebAPI.Models.Genres;
using System.Collections.Generic;

namespace SF.WebAPI.Models.Bands
{
    public class BandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }

        public IList<GenreViewModel> Genres { get; set; }
    }
}
