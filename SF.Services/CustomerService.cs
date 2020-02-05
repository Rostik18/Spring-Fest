using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Infrastructure;
using SF.Services.Helpers;
using SF.Services.Interfaces;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models;
using SF.Services.Models.Customers;

namespace SF.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;

        public CustomerService(IMapper mapper, SFDbContext dbContext)
        {
            _mapper = mapper;
            _DBContext = dbContext;
        }

        public async Task<CustomerDTO> CreateCustomerOrUpdateIfExistAsync(CreateCustomerDTO createCustomerDTO)
        {
            var customer = await _DBContext.Customers.FirstOrDefaultAsync(c => c.Email == createCustomerDTO.Email);

            if (customer != null)
            {
                if (customer.FirstName != createCustomerDTO.FirstName ||
                    customer.LastName != createCustomerDTO.LastName)
                {
                    customer.FirstName = createCustomerDTO.FirstName;
                    customer.LastName = createCustomerDTO.LastName;

                    _DBContext.Customers.Update(customer);
                }
            }
            else
            {
                customer = new CustomerEntity
                {
                    Email = createCustomerDTO.Email,
                    FirstName = createCustomerDTO.FirstName,
                    LastName = createCustomerDTO.LastName
                };

                await _DBContext.AddAsync(customer);
            }

            await _DBContext.SaveChangesAsync();

            var customerDTO = _mapper.Map<CustomerDTO>(customer);

            return customerDTO;
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _DBContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                throw new ItemNotFoundException($"Customer with id {customerId} not found.");
            }

            _DBContext.Remove(customer);
            await _DBContext.SaveChangesAsync();
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _DBContext.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                throw new ItemNotFoundException($"Customer with id {customerId} not found.");
            }

            var customerDTO = _mapper.Map<CustomerDTO>(customer);

            return customerDTO;
        }

        public async Task<PagedResultDTO<CustomerDTO>> GetCustomersPageAsync(int page, int pageSize)
        {
            var query = _DBContext.Customers;

            var pagedResult = await _DBContext.GetPage<CustomerEntity, CustomerDTO>(_mapper, query, page, pageSize);

            return pagedResult;
        }
    }
}
