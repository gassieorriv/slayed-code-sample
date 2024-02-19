using AutoMapper;
using SlayedLifeCore.Shop;
using SlayedLifeModels.Shop;

namespace SlayedLifeAPI.MapperProfiles
{
    public class StateTaxProfile : Profile
    {
        public StateTaxProfile()
        {
            MapDtoToEntity(this);
            MapEntityToDto(this);
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<StateTax, StateTaxDto>();
        }

        static void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<StateTaxDto, StateTax>();
        }
    }
}
