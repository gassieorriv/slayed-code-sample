using System.Threading.Tasks;

namespace SlayedLifeCore.Users
{
    public interface IUserPaymentAccountService
    {
        Task<UserPaymentAccount> CreateUserPaymentAccount(UserPaymentAccount userPaymentAccount);

        Task<UserPaymentAccount> GetUserPaymentAccountByUserId(int userId);

    }
}
