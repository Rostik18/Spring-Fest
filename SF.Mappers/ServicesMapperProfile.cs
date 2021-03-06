﻿using AutoMapper;
using SF.Domain.Entities;
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
using System.Linq;

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

            //Stages
            CreateMap<StageEntity, StageDTO>();

            //Bands
            CreateMap<BandEntity, BandDTO>()
            .ForMember(dto => dto.Genres,
                       opt => opt.MapFrom(ent => ent.BandGenres.Select(x => x.Genre).ToList()));

            //Partners
            CreateMap<PartnerEntity, PartnerDTO>();

            //Festivals
            CreateMap<FestivalEntity, FestivalDTO>()
            .ForMember(dto => dto.Partners,
                       opt => opt.MapFrom(ent => ent.PartnerFestivals.Select(x => x.Partner).ToList()));

            //Performances
            CreateMap<PerformanceEntity, PerformanceDTO>();

            //Tickets
            CreateMap<TicketEntity, TicketDTO>();

            //Purchases
            CreateMap<PurchaseEntity, PurchaseDTO>();

            //Customers
            CreateMap<CustomerEntity, CustomerDTO>();
        }
    }
}
