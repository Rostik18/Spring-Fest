using System.Collections.Generic;

namespace SF.Services.Models.Bands
{
    public class BandFilterDTO
    {
        public int? FestivalId { get; set; }

        public int? StageId { get; set; }

        public IList<int> GenreIds { get; set; }
    }
}
