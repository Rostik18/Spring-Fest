using AutoMapper;
using SF.Services.Models.Admins;
using SF.WebAPI.Models.Admins;

namespace SF.Mappers
{
    public class WebAPIMapperProfile : Profile
    {
        public WebAPIMapperProfile()
        {
            CreateMap<AuthorizedAdminDTO, AuthorizedAdminViewModel>();
        }
    }
}
