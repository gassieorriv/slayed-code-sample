using System.Linq;
using System.Threading.Tasks;
using SlayedLifeCore.Preferences;

namespace SlayedLifeCore.Users
{
    public interface IUserPreferenceRepository
    {
        Task<UserPreference> Create(UserPreference user);

        Task<UserPreference> Update(UserPreference user);

        IQueryable<UserPreference> Get();

        IQueryable<CurrentPreferences> GetUsersPreferences(int userId, int levelId);
    }
}
