using SF.Services.Models.Statistics;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<FestivalStatisticDTO> GetFestivalStatisticAsync(int festivalId);
    }
}
