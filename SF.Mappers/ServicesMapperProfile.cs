using AutoMapper;
using SF.Domain.Entities;
using SF.Services.Models.Bands;
using SF.Services.Models.Genres;

namespace SF.Mappers
{
    public class ServicesMapperProfile : Profile
    {
        public ServicesMapperProfile()
        {
            CreateMap<GenreEntity, GenreDTO>();
            CreateMap<BandEntity, BandDTO>();
        }
    }
}
