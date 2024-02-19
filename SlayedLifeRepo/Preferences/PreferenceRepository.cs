using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Preferences;
using SlayedLifeRepo.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeRepo.Preferences
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private readonly SlayedAPIContext context;
        public PreferenceRepository(SlayedAPIContext context)
        {
            this.context = context;
        }
        public async Task<Preference> Create(Preference preference)
        {
            await context.AddAsync(preference);
            await context.SaveChangesAsync();
            return preference;
        }

        public IQueryable<Preference> Get()
        {
            return context.Preference.AsNoTracking();
        }

        public async Task<Preference> Update(Preference preference)
        {
            var existingPreference = Get().Where(x => x.Id == preference.Id).FirstOrDefault();
            context.Entry(existingPreference).State = EntityState.Modified;
            existingPreference.levelId = preference.levelId;
            context.Update(existingPreference);
            await context.SaveChangesAsync();
            return existingPreference;
        }
    }
}
