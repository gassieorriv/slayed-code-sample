using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlayedLifeCore.Users
{
    public interface IUserScheduleService
    {
        Task<List<UserSchedule>> CreateUserSchedule(List<UserSchedule> userSchedule);
        Task<List<UserSchedule>> GetUserScheduleByUserId(int UserId);
        Task<List<UserSchedule>> UpdateSchedule(List<UserSchedule> userSchedule);
    }
}
