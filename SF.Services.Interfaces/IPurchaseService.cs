using SF.Services.Models;
using SF.Services.Models.Purchases;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<PagedResultDTO<PurchaseDTO>> GetPurchasesPageAsync(int page, int pageSize);
        Task<PurchaseDTO> GetPurchaseByIdAsync(int purchaseId);
        Task<PurchaseDTO> CreatePurchaseAsync(CreatePurchaseDTO createPurchaseDTO);
        Task DeletePurchaseAsync(int purchaseId);
    }
}
