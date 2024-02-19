using SlayedLifeCore.Social;
using Facebook;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SlayedLifeCore.Social.Instagram;

namespace SlayedLifeServices.Social
{
    public class FacebookHttpClient : IFacebookHttpClient
    {
        private readonly FacebookClient client;

        public FacebookHttpClient(IConfiguration configuration)
        {
            client = new FacebookClient
            {
                AppId = configuration.GetSection("Facebook:appId").Value
            };
        }

        public async Task<object> GetFacebookBasicProfile(string facebookId, string accessToken)
        {
            client.AccessToken = accessToken;
            return await client.GetTaskAsync(FacebookQueries.mybasicProfile);
        }

        public async Task<object> GetInstagramBusiness(string accessToken)
        {
            client.AccessToken = accessToken;
            return await client.GetTaskAsync(FacebookQueries.getOwnedInstagramAccount);
        }

        public async Task<object> GetInstagramAccount(string accessToken)
        {
            client.AccessToken = accessToken;
            return await client.GetTaskAsync(InstagramQueries.getInstagraAccountsWithFollowers);
        }

        public async Task<object> GetMyPost(string accessToken)
        {
            client.AccessToken = accessToken;
            return await client.GetTaskAsync(InstagramQueries.getInstagramAccountPost);
        }

    }
}
