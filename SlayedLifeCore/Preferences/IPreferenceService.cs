using SlayedLifeCore.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlayedLifeCore.Preferences
{
    public interface IPreferenceService
    {
        List<CurrentPreferences> GetUserPreferences(int userId, int levelId);

        Task<List<CurrentPreferences>> UpdateCurrentPreferences(List<CurrentPreferences> currentPreferences, int userId);
    }
}
