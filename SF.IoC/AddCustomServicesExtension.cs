﻿using Microsoft.Extensions.DependencyInjection;
using SF.Services;
using SF.Services.Interfaces;

namespace SF.IoC
{
    public static class AddCustomServicesExtension
    {
        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAdminService, AdminService>();
            serviceCollection.AddTransient<IBandService, BandService>();
            serviceCollection.AddTransient<IGenreService, GenreService>();
            serviceCollection.AddTransient<IStageService, StageService>();
            serviceCollection.AddTransient<IPartnerService, PartnerService>();
            serviceCollection.AddTransient<IFestivalService, FestivalService>();
            serviceCollection.AddTransient<IPerformanceService, PerformanceService>();
            serviceCollection.AddTransient<ITicketService, TicketService>();
            serviceCollection.AddTransient<ICustomerService, CustomerService>();
            serviceCollection.AddTransient<IPurchaseService, PurchaseService>();
            serviceCollection.AddTransient<IStatisticService, StatisticService>();
            serviceCollection.AddTransient<IEmailSenderService, EmailSenderService>();
        }
    }
}
