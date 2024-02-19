using AutoMapper;
using SlayedLifeCore.Social;
using SlayedLifeCore.Users;
using SlayedLifeModels.Social;
using SlayedLifeModels.Users;

namespace SlayedLifeAPI.MapperProfiles
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            MapDtoToEntity(this);
            MapEntityToDto(this);
            MapGoogleUserDtoToEntity(this);
            MapGoogleEntityToDto(this);
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<User, UserDto>()
                           .ForMember(dest => dest.userPaymentAccount, src => src.MapFrom(model => model.userPaymentAccount))
                           .ForMember(dest => dest.userProducts, src => src.MapFrom(model => model.userProducts))
                           .ForMember(dest => dest.userServices, src => src.MapFrom(model => model.userServices))
                           .ForMember(dest => dest.ConnectedSocialAccounts, src => src.MapFrom(model => model.ConnectedSocialAccounts));
        }

        static void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<UserDto, User>();

        }

        static void MapGoogleUserDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<GoogleUser, GoogleUserDTO>();
        }

        static void MapGoogleEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<GoogleUserDTO, GoogleUser>();
        }
    }
}
