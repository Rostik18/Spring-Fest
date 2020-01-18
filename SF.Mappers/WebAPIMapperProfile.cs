using AutoMapper;
using SF.Services.Models;
using SF.Services.Models.Admins;
using SF.Services.Models.Bands;
using SF.WebAPI.Models;
using SF.WebAPI.Models.Admins;
using SF.WebAPI.Models.Bands;

namespace SF.Mappers
{
    public class WebAPIMapperProfile : Profile
    {
        public WebAPIMapperProfile()
        {
            CreateMap<AuthorizedAdminDTO, AuthorizedAdminViewModel>();
            CreateMap<PagedResultDTO<BandDTO>, PagedResultViewModel<BandViewModel>>();
            CreateMap<PagedResultDTO<AdminDTO>, PagedResultViewModel<AdminViewModel>>();
            CreateMap<UpdateAdminViewModel, UpdateAdminDTO>();
            CreateMap<AdminDTO, AdminViewModel>();
        }
    }
}
