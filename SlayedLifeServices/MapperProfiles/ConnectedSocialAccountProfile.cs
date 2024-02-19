using AutoMapper;
using SlayedLifeCore.Social;
using SlayedLifeModels.Social;

namespace SlayedLifeAPI.MapperProfiles
{
    public class ConnectedSocialAccountProfile : Profile
    {
        public ConnectedSocialAccountProfile()
        {
            MapDtoToEntity(this);
            MapEntityToDto(this);
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<ConnectedSocialAccount, ConnectedSocialAccountDto>()
                .ForMember(dest => dest.SocialAccount, src => src.MapFrom(model => model.SocialAccount));
        }

        static void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<ConnectedSocialAccountDto, ConnectedSocialAccount>();
        }
    }
}
