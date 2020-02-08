using System.Collections.Generic;

namespace SF.Services.Models.Festivals
{
    public class CreateFestivalDTO
    {
        public int Year { get; set; }
        public string Location { get; set; }

        public IList<int> PartnerIds { get; set; }
    }
}
