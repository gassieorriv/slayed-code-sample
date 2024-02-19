using AutoMapper;
using SlayedLifeCore.Shop;
using SlayedLifeModels.Shop;

namespace SlayedLifeAPI.MapperProfiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            MapDtoToEntity(this);
            MapEntityToDto(this);
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<Service, ServiceDto>();
        }

        static void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<ServiceDto, Service>();
        }
    }
}
