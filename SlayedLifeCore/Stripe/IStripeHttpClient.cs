
using Stripe;
using System.Threading.Tasks;

namespace SlayedLifeCore.Stripe
{
    public interface IStripeHttpClient
    {
        Task<Account> CreateAccount();
        Task<string> CreateAccountLink(string accountId);

        Task<Account> GetAccount(string accountId);
    }
}
