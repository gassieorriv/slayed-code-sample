using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Users;
using SlayedLifeRepo.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeRepo.Users
{
    public class UserScheduleRepository : IUserScheduleRepository
    {
        private readonly SlayedAPIContext context;

        public UserScheduleRepository(SlayedAPIContext context)
        {
            this.context = context;
        }
        public async Task<UserSchedule> Create(UserSchedule userSchedule)
        {
            if(userSchedule.SpecificDate.HasValue)
            {
                var existingSchedule = await Get().Where(x => x.SpecificDate == userSchedule.SpecificDate && x.UserId == userSchedule.UserId).FirstOrDefaultAsync();
                if(existingSchedule != null)
                {
                    userSchedule.Id = existingSchedule.Id;
                    userSchedule.Deleted = false;
                    return await Update(userSchedule);
                }
            }
            userSchedule.CreatedDate = DateTime.UtcNow;
            await context.AddAsync(userSchedule);
            await context.SaveChangesAsync();
            return userSchedule;
        }

        public IQueryable<UserSchedule> Get()
        {
           return context.UserSchedule.AsNoTracking();
        }

        public async Task<UserSchedule> Update(UserSchedule userSchedule)
        {
            var existingSchedule = Get().Where(x => x.Id == userSchedule.Id).FirstOrDefault();
            context.Entry(existingSchedule).State = EntityState.Modified;
            existingSchedule.Closed = userSchedule.Closed;
            existingSchedule.ClosedHour = userSchedule.ClosedHour;
            existingSchedule.ClosedMinute = userSchedule.ClosedMinute;
            existingSchedule.Deleted = userSchedule.Deleted;
            existingSchedule.StartHour = userSchedule.StartHour;
            existingSchedule.StartMinute = userSchedule.StartMinute;
            context.Update(existingSchedule);
            await context.SaveChangesAsync();
            return existingSchedule;
        }
    }
}
