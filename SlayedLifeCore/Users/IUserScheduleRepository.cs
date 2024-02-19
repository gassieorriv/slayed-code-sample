using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeCore.Users
{
    public interface IUserScheduleRepository
    {
        Task<UserSchedule> Create(UserSchedule userSchedule);

        Task<UserSchedule> Update(UserSchedule userSchedule);

        IQueryable<UserSchedule> Get();
    }
}
