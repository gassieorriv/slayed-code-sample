using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeCore.Users
{
    public interface IUserPaymentAccountRepository
    {
        Task<UserPaymentAccount> Create(UserPaymentAccount user);

        Task<UserPaymentAccount> Update(UserPaymentAccount userAccount);

        IQueryable<UserPaymentAccount> Get();
    }
}
