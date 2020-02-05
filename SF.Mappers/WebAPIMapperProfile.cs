using AutoMapper;
using SF.Services.Models;
using SF.Services.Models.Admins;
using SF.Services.Models.Bands;
using SF.Services.Models.Customers;
using SF.Services.Models.Festivals;
using SF.Services.Models.Genres;
using SF.Services.Models.Partners;
using SF.Services.Models.Performances;
using SF.Services.Models.Purchases;
using SF.Services.Models.Stages;
using SF.Services.Models.Tickets;
using SF.WebAPI.Models;
using SF.WebAPI.Models.Admins;
using SF.WebAPI.Models.Bands;
using SF.WebAPI.Models.Customers;
using SF.WebAPI.Models.Festivals;
using SF.WebAPI.Models.Genres;
using SF.WebAPI.Models.Partners;
using SF.WebAPI.Models.Performances;
using SF.WebAPI.Models.Purchases;
using SF.WebAPI.Models.Stages;
using SF.WebAPI.Models.Tickets;

namespace SF.Mappers
{
    public class WebAPIMapperProfile : Profile
    {
        public WebAPIMapperProfile()
        {
            //Admins
            CreateMap<AuthorizedAdminDTO, AuthorizedAdminViewModel>();
            CreateMap<PagedResultDTO<AdminDTO>, PagedResultViewModel<AdminViewModel>>();
            CreateMap<UpdateAdminViewModel, UpdateAdminDTO>();
            CreateMap<AdminDTO, AdminViewModel>();

            //Genres
            CreateMap<CreateGenreViewModel, CreateGenreDTO>();
            CreateMap<UpdateGenreViewModel, UpdateGenreDTO>();
            CreateMap<GenreDTO, GenreViewModel>();
            CreateMap<PagedResultDTO<GenreDTO>, PagedResultViewModel<GenreViewModel>>();

            //Stages
            CreateMap<CreateStageViewModel, CreateStageDTO>();
            CreateMap<UpdateStageViewModel, UpdateStageDTO>();
            CreateMap<StageDTO, StageViewModel>();
            CreateMap<PagedResultDTO<StageDTO>, PagedResultViewModel<StageViewModel>>();

            //Bends
            CreateMap<PagedResultDTO<BandDTO>, PagedResultViewModel<BandViewModel>>();
            CreateMap<BandDTO, BandViewModel>();
            CreateMap<CreateBandViewModel, CreateBandDTO>();
            CreateMap<UpdateBandViewModel, UpdateBandDTO>();

            //Partners
            CreateMap<PagedResultDTO<PartnerDTO>, PagedResultViewModel<PartnerViewModel>>();
            CreateMap<PartnerDTO, PartnerViewModel>();
            CreateMap<CreatePartnerViewModel, CreatePartnerDTO>();
            CreateMap<UpdatePartnerViewModel, UpdatePartnerDTO>();

            //Festivals
            CreateMap<FestivalDTO, FestivalViewModel>();
            CreateMap<CreateFestivalViewModel, CreateFestivalDTO>();
            CreateMap<UpdateFestivalViewModel, UpdateFestivalDTO>();

            //Performances
            CreateMap<PagedResultDTO<PerformanceDTO>, PagedResultViewModel<PerformanceViewModel>>();
            CreateMap<PerformanceDTO, PerformanceViewModel>();
            CreateMap<CreatePerformanceViewModel, CreatePerformanceDTO>();
            CreateMap<UpdatePerformanceViewModel, UpdatePerformanceDTO>();

            //Purchases
            CreateMap<PurchaseDTO, PurchaseViewModel>();

            //Customers
            CreateMap<PagedResultDTO<CustomerDTO>, PagedResultViewModel<CustomerViewModel>>();
            CreateMap<CustomerDTO, CustomerViewModel>();
            CreateMap<CreateCustomerViewModel, CreateCustomerDTO>();

            //Tickets
            CreateMap<TicketDTO, TicketViewModel>();
            CreateMap<CreateTicketViewModel, CreateTicketDTO>();
            CreateMap<UpdateTicketViewModel, UpdateTicketDTO>();
        }
    }
}
