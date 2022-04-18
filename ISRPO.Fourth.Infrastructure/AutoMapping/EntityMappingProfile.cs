using AutoMapper;
using ISRPO.Fourth.Domain.Models;

namespace ISRPO.Fourth.Infrastructure.AutoMapping
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<Entity, Entity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<Instrument, Instrument>()
                .IncludeBase<Entity, Entity>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
        }
    }
}