using AutoMapper;
using SF.Domain.Entities;
using SF.Services.Models.Admins;
using SF.Services.Models.Bands;
using SF.Services.Models.Genres;

namespace SF.Mappers
{
    public class ServicesMapperProfile : Profile
    {
        public ServicesMapperProfile()
        {
            //Admins
            CreateMap<AdminDTO, AdminEntity>();
            CreateMap<AdminEntity, AdminDTO>();

            //Genres
            CreateMap<GenreEntity, GenreDTO>();

            //Bands
            CreateMap<BandEntity, BandDTO>();
        }
    }
}
