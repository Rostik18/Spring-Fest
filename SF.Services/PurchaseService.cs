using System;
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
using SF.Services.Models.Purchases;

namespace SF.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IMapper _mapper;
        private readonly SFDbContext _DBContext;
        private readonly ICustomerService _customerService;

        public PurchaseService(IMapper mapper, SFDbContext dbContext, ICustomerService customerService)
        {
            _mapper = mapper;
            _DBContext = dbContext;
            _customerService = customerService;
        }

        public async Task<PurchaseDTO> CreatePurchaseAsync(CreatePurchaseDTO createPurchaseDTO)
        {
            var ticket = await _DBContext.Tickets.FirstOrDefaultAsync(t => t.Id == createPurchaseDTO.TicketId); //1 звернення до БД

            if (ticket == null)
            {
                throw new ItemNotFoundException($"Ticket with id {createPurchaseDTO.TicketId} not found.");
            }

            var customer = await _customerService.CreateCustomerOrUpdateIfExistAsync(createPurchaseDTO.Customer); //2 звернення до БД

            var purchase = new PurchaseEntity
            {
                IsAvailable = true,
                BarCode = Guid.NewGuid(),
                CustomerId = customer.Id,
                TicketId = ticket.Id
            };

            await _DBContext.Purchases.AddAsync(purchase); //1 звернення до БД
            await _DBContext.SaveChangesAsync();

            /*
                Додати розсилку квитка на email. 
            */

            var purchaseDTO = _mapper.Map<PurchaseDTO>(purchase);

            return purchaseDTO;
        }

        public async Task DeletePurchaseAsync(int purchaseId)
        {
            var purchase = await _DBContext.Purchases.FirstOrDefaultAsync(p => p.Id == purchaseId);

            if (purchase == null)
            {
                throw new ItemNotFoundException($"Purchase with id {purchaseId} not found.");
            }

            _DBContext.Purchases.Remove(purchase);
            await _DBContext.SaveChangesAsync();
        }

        public async Task<PurchaseDTO> GetPurchaseByIdAsync(int purchaseId)
        {
            var purchase = await _DBContext.Purchases.AsNoTracking()
                .Include(p => p.Ticket)
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(p => p.Id == purchaseId);

            if (purchase == null)
            {
                throw new ItemNotFoundException($"Purchase with id {purchaseId} not found.");
            }

            var purchaseDTO = _mapper.Map<PurchaseDTO>(purchase);

            return purchaseDTO;
        }

        public async Task<PagedResultDTO<PurchaseDTO>> GetPurchasesPageAsync(int page, int pageSize)
        {
            var query = _DBContext.Purchases
                .Include(p => p.Ticket)
                .Include(p => p.Customer);

            var pagedResult = await _DBContext.GetPage<PurchaseEntity, PurchaseDTO>(_mapper, query, page, pageSize);

            return pagedResult;
        }
    }
}
