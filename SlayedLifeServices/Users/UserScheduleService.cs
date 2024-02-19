using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeServices.Users
{
    public class UserScheduleService : IUserScheduleService
    {
        private readonly IUserScheduleRepository userScheduleRepository;
        public UserScheduleService(IUserScheduleRepository userScheduleRepository)
        {
            this.userScheduleRepository = userScheduleRepository;
        }
        public async Task<List<UserSchedule>> CreateUserSchedule(List<UserSchedule> userSchedule)
        {
            var response = new List<UserSchedule>();
            foreach(UserSchedule schedule in userSchedule)
            {
               response.Add(await userScheduleRepository.Create(schedule));
            }

            return response;
        }

        public async Task<List<UserSchedule>> GetUserScheduleByUserId(int UserId)
        {
            var userScheduleQueryable = userScheduleRepository.Get().Where(x => x.UserId == UserId && !x.Deleted);
            return await userScheduleQueryable.ToListAsync();
        }

        public async Task<List<UserSchedule>> UpdateSchedule(List<UserSchedule> userSchedule)
        {
            var response = new List<UserSchedule>();
            foreach (UserSchedule schedule in userSchedule)
            {
                if(schedule.DayOfWeekId == 0)
                {
                    schedule.DayOfWeekId = null;
                }
                if (schedule.Id > 0)
                {
                    response.Add(await userScheduleRepository.Update(schedule));
                }
                else
                {
                    response.Add(await userScheduleRepository.Create(schedule));
                }
            }
            return response;
        }
    }
}
