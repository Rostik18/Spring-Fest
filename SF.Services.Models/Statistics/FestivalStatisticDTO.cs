
namespace SF.Services.Models.Statistics
{
    public class FestivalStatisticDTO
    {
        public int UniqueVisitorsCount { get; set; }

        public int FestivalTicketsSoldCount { get; set; }
        public int TentTicketsSoldCount { get; set; }
        public int ParkingTicketsSoldCount { get; set; }

        public int Benefit { get; set; }
    }
}
