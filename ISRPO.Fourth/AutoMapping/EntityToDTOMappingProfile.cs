using AutoMapper;
using ISRPO.Fourth.Domain.Models;
using ISRPO.Fourth.DTO;

namespace ISRPO.Fourth.AutoMapping
{
    public class EntityToDTOMappingProfile : Profile
    {
        public EntityToDTOMappingProfile()
        {
            CreateMap<Instrument, InstrumentDTO>().ReverseMap();
        }
    }
}