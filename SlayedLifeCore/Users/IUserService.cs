using SlayedLifeCore.Social;
using System.Collections.Generic;
using System.Threading.Tasks;
using SlayedLifeCore.Preferences;
namespace SlayedLifeCore.Users
{
    public interface IUserService
    {
        Task<Response<User>> CreateUserWithFacebook();

        Task<Response<User>> CreateUserWithGoogle(GoogleUser googleUser);

        Task<Response<User>> UpdateExistingUser(User user);

        Task<Response<User>> GetUserById(int id);

        List<CurrentPreferences> GetUserPreferences(int userId);

        Task<Response<List<CurrentPreferences>>> UpdateCurrentPreferences(int userId, List<CurrentPreferences> currentPreferences);

        Task<List<UserSchedule>> GetUserSchedules(int userId);

        Task<List<UserSchedule>> UpdateUserSchedule(List<UserSchedule> userSchedule);

        Task<List<UserSchedule>> CreateUserSchedule(List<UserSchedule> userSchedule);
    }
}
