using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Users;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeServices.Users
{
    public class UserPaymentAccountService : IUserPaymentAccountService
    {
        private readonly IUserPaymentAccountRepository userPaymentAccountRepository;

        public UserPaymentAccountService(IUserPaymentAccountRepository userPaymentAccountRepository)
        {
            this.userPaymentAccountRepository = userPaymentAccountRepository;
        }

        public async Task<UserPaymentAccount> CreateUserPaymentAccount(UserPaymentAccount userPaymentAccount)
        {
            var account = await userPaymentAccountRepository.Create(userPaymentAccount);
            return account;
        }

        public async Task<UserPaymentAccount> GetUserPaymentAccountByUserId(int userId)
        {
            var userPaymentAccountQueryable = userPaymentAccountRepository.Get().Where(x => x.UserId == userId);
            var account = await userPaymentAccountQueryable.FirstOrDefaultAsync();
            return account;
        }
    }
}
