using SlayedLifeCore.Support;
using SlayedLifeRepo.Context;
using System;
using System.Threading.Tasks;

namespace SlayedLifeRepo.Support
{
    public class SupportNoteRepository : ISupportNoteRepository
    {
        private readonly SlayedAPIContext context;
        public SupportNoteRepository(SlayedAPIContext context)
        {
            this.context = context;
        }

        public async Task<SupportNote> Create(SupportNote note)
        {
            note.CreatedDate = DateTime.Now;
            await context.AddAsync(note);
            await context.SaveChangesAsync();
            return note;
        }
    }
}
