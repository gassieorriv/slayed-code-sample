using SlayedLifeCore.Configuration;
using SlayedLifeCore.Social;
using SlayedLifeCore.Social.Google;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SlayedLifeServices.Social.Google
{
    public class GoogleHttpClient : IGoogleHttpClient
    {
        private readonly GoogleTokenRequest googleRequest;

        public GoogleHttpClient(ICoreConfiguration coreConfiguration)
        {
            googleRequest = coreConfiguration.GetGoogleRequest();
        }

        public async Task<object> ExchangeAuthoriztionCode(string authCode)
        {
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("code", authCode));
            data.Add(new KeyValuePair<string, string>("client_id", googleRequest.clientId));
            data.Add(new KeyValuePair<string, string>("client_secret", googleRequest.clientSecret));
            data.Add(new KeyValuePair<string, string>("redirect_uri",""));
            data.Add(new KeyValuePair<string, string>("code_verifier", "fafjadlkfju49r3uirfjafjdflaj"));

            data.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            HttpClient client = new HttpClient();
            HttpContent content = new FormUrlEncodedContent(data);
            var response = await client.PostAsync(GoogleQueries.GetAccessToken, content);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string t = await response.Content.ReadAsStringAsync();
            }

            return response.StatusCode;
        }

        public Task<object> GetYoutubeProfileData(ConnectedSocialAccount socialAccount)
        {
            throw new System.NotImplementedException();
        }
    }
}
