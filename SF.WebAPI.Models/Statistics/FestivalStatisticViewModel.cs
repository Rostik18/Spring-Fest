
namespace SF.WebAPI.Models.Statistics
{
    public class FestivalStatisticViewModel
    {
        public int UniqueVisitorsCount { get; set; }

        public int FestivalTicketsSoldCount { get; set; }
        public int TentTicketsSoldCount { get; set; }
        public int ParkingTicketsSoldCount { get; set; }

        public int Benefit { get; set; }
    }
}
