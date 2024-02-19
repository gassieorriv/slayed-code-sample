using AutoMapper;
using SlayedLifeCore.Users;
using SlayedLifeModels.Users;

namespace SlayedLifeServices.MapperProfiles
{
    public class UserScheduleProfile : Profile
    {
        public UserScheduleProfile()
        {
            MapDtoToEntity(this);
            MapEntityToDto(this);
        }

        static void MapEntityToDto(IProfileExpression profile)
        {
            profile.CreateMap<UserSchedule, UserScheduleDto>();
        }

        static void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<UserScheduleDto, UserSchedule>();
        }
    }
}
