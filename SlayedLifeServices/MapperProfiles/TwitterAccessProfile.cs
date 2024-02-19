using AutoMapper;
using SlayedLifeCore.Social;
using SlayedLifeModels.Social;

namespace SlayedLifeAPI.MapperProfiles
{
    public class TwitterAccessProfile : Profile
    {
        public TwitterAccessProfile()
        {
            MapDtoToEntity(this);
            MapEntityToDto(this);
            MapTwitterDtoToConnectedSocialAccount(this);
        }

        static void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<TwitterAccess, TwitterAccessDto>();
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<TwitterAccessDto, TwitterAccess>();
        }

        static void MapTwitterDtoToConnectedSocialAccount(IProfileExpression profile)
        {
            profile.CreateMap<TwitterAccessDto, ConnectedSocialAccount>()
                .ForMember(dest => dest.AccountId, src => src.MapFrom(model => model.Id))
                .ForMember(dest => dest.Token, src => src.MapFrom(model => model.token))
                .ForMember(dest => dest.Secret, src => src.MapFrom(model => model.secret));

        }
    }
}
