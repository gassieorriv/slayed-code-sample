using AutoMapper;
using SlayedLifeCore.Users;
using SlayedLifeModels.Users;
using Stripe;

namespace SlayedLifeAPI.MapperProfiles
{
    public class UserPaymentAccountProfile : Profile
    {
        public UserPaymentAccountProfile()
        {
            MapAccountEntityToDto(this);
            MapEntityToDto(this);
        }

        static void MapAccountEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<Account, UserPaymentAccountDto>()
                           .ForMember(dest => dest.isAcceptingPayments, src => src.MapFrom(model => model.ChargesEnabled));
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<UserPaymentAccount, UserPaymentAccountDto>()
                           .ForMember(dest => dest.isAcceptingPayments, src => src.MapFrom(model => model.ChargesEnabled));
        }
    }
}
