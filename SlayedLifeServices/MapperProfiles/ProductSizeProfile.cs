using AutoMapper;
using SlayedLifeCore.Shop;
using SlayedLifeModels.Shop;

namespace SlayedLifeServices.MapperProfiles
{
    public class ProductSizeProfile : Profile
    {
        public ProductSizeProfile()
        {
            MapDtoToEntity(this);
            MapEntityToDto(this);
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<ProductSize, ProductSizeDto>();
        }

        static void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<ProductSizeDto, ProductSize>();
        }
    }
}
