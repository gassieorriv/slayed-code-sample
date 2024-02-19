using Stripe;
using System.Threading.Tasks;

namespace SlayedLifeCore.Stripe
{
    public interface IStripeService
    {
        Task<string> ConnectAccountLink(int userId);

        Task<Account> GetAccount(int userId);
    }
}
