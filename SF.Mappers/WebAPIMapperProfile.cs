using AutoMapper;
using SF.Services.Models;
using SF.Services.Models.Admins;
using SF.Services.Models.Bands;
using SF.Services.Models.Genres;
using SF.Services.Models.Stages;
using SF.WebAPI.Models;
using SF.WebAPI.Models.Admins;
using SF.WebAPI.Models.Bands;
using SF.WebAPI.Models.Genres;
using SF.WebAPI.Models.Stages;

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
        }
    }
}
