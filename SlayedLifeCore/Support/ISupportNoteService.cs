using System.Threading.Tasks;

namespace SlayedLifeCore.Support
{
    public interface ISupportNoteService
    {
        Task<Response<SupportNote>> CreateAppUserSupportNote(SupportNote supportNote);
    }
}
