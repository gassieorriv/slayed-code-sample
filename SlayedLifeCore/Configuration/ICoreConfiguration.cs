using SlayedLifeCore.Global;
using SlayedLifeCore.Social.Google;
using SlayedLifeCore.Stripe;
using System.Net;
using System.Threading.Tasks;

namespace SlayedLifeCore.Configuration
{
    public interface ICoreConfiguration
    {
        string GetConnectionString();
        
        AuthorizationClient GetAuthorizedClient();

        GoogleTokenRequest GetGoogleRequest();

        Task<HttpStatusCode> ValidateApiAuthorizationAsync(string token);


        EngageStripeRequest GetStripeConfiguration();
    }
}