using SF.Services.Models;
using SF.Services.Models.Bands;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IBandService
    {
        Task<PagedResultDTO<BandDTO>> GetBandsPageAsync(int page, int pageSize, BandFilterDTO bandFilterDTO);
        Task<BandDTO> GetBandByIdAsync(int bandId);
        Task<BandDTO> CreateBandAsync(CreateBandDTO createBandDTO);
        Task<BandDTO> UpdateBandAsync(UpdateBandDTO updateBandDTO);
        Task DeleteBandAsync(int bandId);
    }
}
