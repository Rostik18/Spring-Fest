using SF.Services.Models;
using SF.Services.Models.Customers;
using System.Threading.Tasks;

namespace SF.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<PagedResultDTO<CustomerDTO>> GetCustomersPageAsync(int page, int pageSize);
        Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
        Task<CustomerDTO> CreateCustomerOrUpdateIfExistAsync(CreateCustomerDTO createCustomerDTO);
        Task DeleteCustomerAsync(int customerId);
    }
}
