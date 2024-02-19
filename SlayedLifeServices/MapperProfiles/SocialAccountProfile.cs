using AutoMapper;
using SlayedLifeCore.Social;
using SlayedLifeModels.Social;

namespace SlayedLifeAPI.MapperProfiles
{
    public class SocialAccountProfile : Profile
    {
        public SocialAccountProfile()
        {
            MapDtoToEntity(this);
            MapEntityToDto(this);
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<SocialAccount, SocialAccountDto>();
        }

        static void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<SocialAccountDto, SocialAccount>();
        }
    }
}
