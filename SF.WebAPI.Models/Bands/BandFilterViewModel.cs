using SF.WebAPI.Models.CustomValidations;
using System.Collections.Generic;

namespace SF.WebAPI.Models.Bands
{
    public class BandFilterViewModel
    {
        [GreaterThanZero]
        public int? StageId { get; set; }

        [ItemsGreaterThanZero]
        public IList<int> GenreIds { get; set; }
    }
}
