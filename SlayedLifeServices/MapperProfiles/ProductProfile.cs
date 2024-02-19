using AutoMapper;
using SlayedLifeCore.Shop;
using SlayedLifeModels.Shop;

namespace SlayedLifeAPI.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            MapDtoToEntity(this);
            MapEntityToDto(this);
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<Product, ProductDto>()
                 .ForMember(dest => dest.ProductSize, src => src.MapFrom(model => model.ProductSize));
        }

        static void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<ProductDto, Product>()
                     .ForMember(dest => dest.ProductSize, src => src.MapFrom(model => model.ProductSize));
        }
    }
}
