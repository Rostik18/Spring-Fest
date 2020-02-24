using System;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Domain.Enumerations;
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
        private readonly IEmailSenderService _emailSenderService;

        public PurchaseService(IMapper mapper, SFDbContext dbContext, ICustomerService customerService, IEmailSenderService emailSenderService)
        {
            _mapper = mapper;
            _DBContext = dbContext;
            _customerService = customerService;
            _emailSenderService = emailSenderService;
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

            //Email розсилка
            string type = "";
            switch (ticket.Type)
            {
                case TicketType.Festival: { type = "фестиваль"; break; }
                case TicketType.Parking: { type = "парковка"; break; }
                case TicketType.Tent: { type = "наметове містечко"; break; }
            }
            var date = ticket.BeginingTime.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);

            string message = string.Format(Constants.Email.tickert, $"{customer.FirstName} {customer.LastName}", type, date,
                                           ticket.Duration, ticket.Price, purchase.BarCode.ToString());
            _emailSenderService.SendEmailHtmlTextAsync(customer.Email, "Квиток на фестиваль", message);
            //

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
