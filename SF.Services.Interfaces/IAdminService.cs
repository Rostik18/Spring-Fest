using SF.Services.Models;
using SF.Services.Models.Admins;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IAdminService
    {
        Task<AuthorizedAdminDTO> AuthorizeAsync(string login, string password);
        Task<bool> CreateAdminAsync(string login, string password);
        Task<PagedResultDTO<AdminDTO>> GetAdminsPageAsync(int page, int pageSize);
        Task DeleteAdminAsync(int adminId);
        Task<AdminDTO> UpdateAdminAsync(UpdateAdminDTO updateAdminDTO);
    }
}
