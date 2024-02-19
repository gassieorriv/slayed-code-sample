using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Users;
using SlayedLifeRepo.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeRepo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SlayedAPIContext context;

        public UserRepository(SlayedAPIContext context)
        {
            this.context = context;
        }

        public async Task<User> Create(User user)
        {
            user.createdBy = user.email;
            user.userName = user.email;
            user.createdDate = DateTime.UtcNow;
            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            var existingUser = Get().Where(x => x.id == user.id).FirstOrDefault();
            context.Entry(existingUser).State = EntityState.Modified;
            existingUser.firstName = user.firstName == null ? existingUser.firstName : user.firstName;
            existingUser.lastName = user.lastName == null ? existingUser.lastName : user.lastName;
            existingUser.phone = user.phone == null ? existingUser.phone : user.phone;
            existingUser.photo = user.photo == null ? existingUser.photo : user.photo;
            existingUser.dob = user.dob == null ? existingUser.dob : user.dob;
            existingUser.userName = user.userName == null ? existingUser.userName : user.userName;
            existingUser.modifiedBy = user.email;
            existingUser.modifiedDate = DateTime.UtcNow;
            context.Update(existingUser);
            await context.SaveChangesAsync();
            return existingUser;
        }

        public IQueryable<User> Get()
        {
           return context.User.AsNoTracking();
        }
    }
}
