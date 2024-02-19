using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Users;
using SlayedLifeRepo.Context;
using System.Linq;
using System.Threading.Tasks;
using SlayedLifeCore.Preferences;

namespace SlayedLifeRepo.Users
{
    public class UserPreferenceRepository : IUserPreferenceRepository
    {
        private readonly SlayedAPIContext context;

        public UserPreferenceRepository(SlayedAPIContext context)
        {
            this.context = context;
        }

        public async Task<UserPreference> Create(UserPreference user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public IQueryable<UserPreference> Get()
        {
            return context.UserPreference.AsNoTracking();
        }

        public async Task<UserPreference> Update(UserPreference user)
        {
            var existingUser = Get().Where(x => x.Id == user.Id).FirstOrDefault();
            context.Entry(existingUser).State = EntityState.Modified;
            existingUser.active = user.active;
            context.Update(existingUser);
            await context.SaveChangesAsync();
            return existingUser;
        }

        public IQueryable<CurrentPreferences> GetUsersPreferences(int userId, int levelId)
        {
            var data = from  pref in context.Preference
                       join  uPref in context.UserPreference on new { id = pref.Id, userId = userId } equals new { id = uPref.preferenceId, userId = uPref.userId } into currentPref
                       from  uPref in currentPref.DefaultIfEmpty()
                       where levelId >= pref.levelId
                       select new CurrentPreferences()
                       {
                           PreferenceId = pref.Id,
                           Name = pref.name,
                           UserPreferenceId = uPref.Id,
                           Active = uPref.active
                       };

            return data;
        }
    }
}
