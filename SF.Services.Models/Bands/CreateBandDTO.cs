using System.Collections.Generic;

namespace SF.Services.Models.Bands
{
    public class CreateBandDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<int> GenreIds { get; set; }
    }
}
