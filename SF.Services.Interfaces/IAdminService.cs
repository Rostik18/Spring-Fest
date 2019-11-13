using SF.Services.Models.Admins;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IAdminService
    {
        Task<AuthorizedAdminDTO> AuthorizeAsync(string login, string password);
    }
}
