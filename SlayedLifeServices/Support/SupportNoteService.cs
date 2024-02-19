using SlayedLifeCore;
using SlayedLifeCore.Support;
using System.Threading.Tasks;

namespace SlayedLifeServices.Support
{
    public class SupportNoteService : ISupportNoteService
    {

        private readonly ISupportNoteRepository supportNoteRepository;
        public SupportNoteService(ISupportNoteRepository supportNoteRepository)
        {
            this.supportNoteRepository = supportNoteRepository;
        }

        public async Task<Response<SupportNote>> CreateAppUserSupportNote(SupportNote supportNote)
        {
            Response<SupportNote> response = new Response<SupportNote>();
            response.data  = await supportNoteRepository.Create(supportNote);
            response.success = true;
            return response;
        }
    }
}
