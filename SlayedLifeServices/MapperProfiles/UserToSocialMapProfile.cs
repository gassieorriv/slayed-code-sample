using AutoMapper;
using SlayedLifeCore.Social;
using SlayedLifeCore.Users;

namespace SlayedLifeAPI.MapperProfiles
{
    public class UserToSocialMapProfile : Profile
    {
        public UserToSocialMapProfile()
        {
            MapFacebookEntityToUserEntity(this);
            MapGoogleEntityToUserEntity(this);
        }

        static void MapFacebookEntityToUserEntity(IProfileExpression profile)
        {
            profile.CreateMap<FacebookUser, User>()
                .ForMember(dest => dest.firstName, src => src.MapFrom(model => model.first_name))
                .ForMember(dest => dest.lastName, src => src.MapFrom(model => model.last_name))
                .ForMember(dest => dest.id, src => src.Ignore())
                .ForMember(dest => dest.photo, src => src.MapFrom(model => model.picture.Data.url))
                .ForMember(dest => dest.email, src => src.MapFrom(model => model.email));
        }

        static void MapGoogleEntityToUserEntity(IProfileExpression profile)
        {
            profile.CreateMap<GoogleUser, User>()
                .ForMember(dest => dest.firstName, src => src.MapFrom(model => model.givenName))
                .ForMember(dest => dest.lastName, src => src.MapFrom(model => model.familyName))
                .ForMember(dest => dest.id, src => src.Ignore())
                .ForMember(dest => dest.photo, src => src.MapFrom(model => model.photo))
                .ForMember(dest => dest.email, src => src.MapFrom(model => model.email));
        }
    }
}
