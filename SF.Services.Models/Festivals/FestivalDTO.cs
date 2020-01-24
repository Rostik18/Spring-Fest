using SF.Services.Models.Partners;
using System.Collections.Generic;

namespace SF.Services.Models.Festivals
{
    public class FestivalDTO
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string Location { get; set; }

        public IList<PartnerDTO> Partners { get; set; }
    }
}
