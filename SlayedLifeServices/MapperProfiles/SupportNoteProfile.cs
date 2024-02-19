using AutoMapper;
using SlayedLifeCore.Support;
using SlayedLifeModels.Support;

namespace SlayedLifeAPI.MapperProfiles
{
    public class SupportNoteProfile : Profile
    {
        public SupportNoteProfile()
        {
            MapDtoToEntity(this);
        }
        public void MapDtoToEntity(IProfileExpression profile)
        {
            profile.CreateMap<SupportNoteDto, SupportNote>();
        }
    }
}
