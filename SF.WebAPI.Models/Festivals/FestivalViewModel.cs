using SF.WebAPI.Models.Partners;
using System.Collections.Generic;

namespace SF.WebAPI.Models.Festivals
{
    public class FestivalViewModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }

        public IList<PartnerViewModel> Partners { get; set; }
    }
}
