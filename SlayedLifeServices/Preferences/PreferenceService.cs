using SlayedLifeCore.Preferences;
using SlayedLifeCore.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeServices.Preferences
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IUserPreferenceRepository userPreferenceRepository;
        public PreferenceService(IUserPreferenceRepository userPreferenceRepository)
        {
            this.userPreferenceRepository = userPreferenceRepository;
        }
        public List<CurrentPreferences> GetUserPreferences(int userId, int levelId)
        {
            var preferenceQueryable = userPreferenceRepository.GetUsersPreferences(userId, levelId);
            return preferenceQueryable.ToList();
        }

        public async Task<List<CurrentPreferences>> UpdateCurrentPreferences(List<CurrentPreferences> currentPreferences, int userId)
        {
            foreach(CurrentPreferences preference in currentPreferences)
            {
                UserPreference userPreference = new UserPreference()
                {
                    active = preference.Active.Value,
                    userId = userId,
                    preferenceId = preference.PreferenceId.Value
                };

                if (preference.UserPreferenceId.HasValue && preference.UserPreferenceId.Value > 0)
                {
                    userPreference.Id = preference.UserPreferenceId.Value;
                    await userPreferenceRepository.Update(userPreference);
                }
                else
                {
                    await userPreferenceRepository.Create(userPreference);
                }
            }
            return currentPreferences;
        }
    }
}
