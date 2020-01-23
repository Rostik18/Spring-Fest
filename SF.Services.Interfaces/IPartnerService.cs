using SF.Services.Models;
using SF.Services.Models.Partners;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IPartnerService
    {
        Task<PagedResultDTO<PartnerDTO>> GetPartnersPageAsync(int page, int pageSize);
        Task<PartnerDTO> GetPartnerByIdAsync(int partnerId);
        Task<PartnerDTO> CreatePartnerAsync(CreatePartnerDTO createPartnerDTO);
        Task<PartnerDTO> UpdatePartnerAsync(UpdatePartnerDTO updatePartnerDTO);
        Task DeletePartnerAsync(int partnerId);
    }
}
