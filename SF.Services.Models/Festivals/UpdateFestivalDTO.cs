using System.Collections.Generic;

namespace SF.Services.Models.Festivals
{
    public class UpdateFestivalDTO
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string Location { get; set; }

        public IList<int> PartnerIdsToAdd { get; set; }

        public IList<int> PartnerIdsToRemove { get; set; }
    }
}
