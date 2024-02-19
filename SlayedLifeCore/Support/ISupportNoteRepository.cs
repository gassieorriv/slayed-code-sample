using System.Threading.Tasks;

namespace SlayedLifeCore.Support
{
    public interface ISupportNoteRepository
    {
        Task<SupportNote> Create(SupportNote note);
    }
}
