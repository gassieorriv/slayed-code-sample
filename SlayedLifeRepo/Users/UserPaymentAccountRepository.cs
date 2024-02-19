using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Users;
using SlayedLifeRepo.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeRepo.Users
{
    public class UserPaymentAccountRepository : IUserPaymentAccountRepository
    {
        private readonly SlayedAPIContext context;
        public UserPaymentAccountRepository(SlayedAPIContext context)
        {
            this.context = context;
        }
        public async Task<UserPaymentAccount> Create(UserPaymentAccount user)
        {
            user.Created = DateTime.UtcNow;
            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public IQueryable<UserPaymentAccount> Get()
        {
            return context.UserPaymentAccount.AsNoTracking();
        }

        public async Task<UserPaymentAccount> Update(UserPaymentAccount account)
        {
            var existingAccount = Get().Where(x => x.Id == account.Id).FirstOrDefault();
            context.Entry(account).State = EntityState.Modified;
            existingAccount.AccountId = account.AccountId == null ? existingAccount.AccountId : account.AccountId;
            existingAccount.ChargesEnabled = account.ChargesEnabled;
            existingAccount.Modified = DateTime.UtcNow;
            context.Update(existingAccount);
            await context.SaveChangesAsync();
            return existingAccount;
        }
    }
}
