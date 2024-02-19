using SlayedLifeCore.Configuration;
using SlayedLifeCore.Stripe;
using Stripe;
using System.Threading.Tasks;

namespace SlayedLifeServices.Stripe
{
    public class StripeHttpClient : IStripeHttpClient
    {
        private readonly EngageStripeRequest stripeRequest;
      
        public StripeHttpClient(ICoreConfiguration coreConfiguration)
        {
            stripeRequest = coreConfiguration.GetStripeConfiguration();
            StripeConfiguration.ApiKey = stripeRequest.SecretKey;
        }

        public async Task<Account> CreateAccount()
        {
            var options = new AccountCreateOptions 
            {
                Type = "standard",
            };
            var service = new AccountService();
            var account = await service.CreateAsync(options);
            return account;
        }

        public async Task<string> CreateAccountLink(string accountId)
        {
            var options = new AccountLinkCreateOptions
            {
                Account = accountId,
                RefreshUrl = "https://www.slayed.life",
                ReturnUrl = "https://www.slayed.life",
                Type = "account_onboarding",
            };
            var service = new AccountLinkService();
            var accountLink = await service.CreateAsync(options);
            return accountLink.Url;
        }

        public async Task<Account> GetAccount(string accountId)
        {
            var service = new AccountService();
            var response =  await service.GetAsync(accountId);
            return response;
        }
    }
}
