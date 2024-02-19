using SlayedLifeCore.Stripe;
using SlayedLifeCore.Users;
using Stripe;
using System.Threading.Tasks;

namespace SlayedLifeServices.Stripe
{
    public class StripeService : IStripeService
    {
        private readonly IStripeHttpClient stripeHttpClient;
        private readonly IUserPaymentAccountService userPaymentAccountService;
        public StripeService(IStripeHttpClient stripeHttpClient, IUserPaymentAccountService userPaymentAccountService)
        {
            this.stripeHttpClient = stripeHttpClient;
            this.userPaymentAccountService = userPaymentAccountService;
        }
        public async Task<string> ConnectAccountLink(int userId)
        {
            var existingAccount = await userPaymentAccountService.GetUserPaymentAccountByUserId(userId);
            string accountId;
            if (existingAccount == null)
            {
                var account = await stripeHttpClient.CreateAccount();
                accountId = account.Id;
                UserPaymentAccount paymentAccount = new UserPaymentAccount()
                {
                    AccountId = accountId,
                    UserId = userId,
                    ChargesEnabled = account.ChargesEnabled,
                };
                await userPaymentAccountService.CreateUserPaymentAccount(paymentAccount);
            }
            else
            {
                accountId = existingAccount.AccountId;
            }

            var response = await stripeHttpClient.CreateAccountLink(accountId);
            return response;
        }
        public async Task<Account> GetAccount(int userId)
        {
            var userPaymentAccount = await userPaymentAccountService.GetUserPaymentAccountByUserId(userId);
            return await stripeHttpClient.GetAccount(userPaymentAccount.AccountId);
        }
    }
}
