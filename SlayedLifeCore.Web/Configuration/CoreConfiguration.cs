using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SlayedLifeCore.Configuration;
using SlayedLifeCore.Global;
using SlayedLifeCore.Social.Google;
using SlayedLifeCore.Stripe;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SlayedLifeCore.Web.Configuration
{
    public class CoreConfiguration : ICoreConfiguration
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AuthorizationClient authorizationClient;
        public CoreConfiguration(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            authorizationClient = GetAuthorizedClient();
        }

        public string GetConnectionString()
        {
            return configuration.GetSection("ConnectionString:SqlServerConnection").Value;
        }

        public AuthorizationClient GetAuthorizedClient()
        {
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                return null;
            }
            var header = int.Parse(httpContext.Request.Headers[HeaderKeys.AuthenticationType]);
            var token = httpContext.Request.Headers[HeaderKeys.accessToken];
            var uid = httpContext.Request.Headers[HeaderKeys.userId];
            var apiToken = httpContext.Request.Headers[HeaderKeys.apiAccessToken];
            authorizationClient = new AuthorizationClient()
            {
                AuthorizationType = header == 1 ? AuthorizeTypeEnum.Facebook : AuthorizeTypeEnum.Google,
                AccessToken = token,
                UserId = uid,
                ApiToken = apiToken
            };
            return authorizationClient;
        }

        public async Task<HttpStatusCode> ValidateApiAuthorizationAsync(string token)
        {
            string apiUrl = configuration.GetSection("API:Endpoint").Value;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add(HeaderKeys.apiAccessToken, token);
            var response  =  await client.GetAsync($"{apiUrl}/.auth/me");
            return response.StatusCode;
        }

        public GoogleTokenRequest GetGoogleRequest()
        {
            GoogleTokenRequest request = new GoogleTokenRequest();
            request.clientId = configuration.GetSection("Google:ClientId").Value;
            request.clientSecret = configuration.GetSection("Google:ClientSecret").Value;
            request.endpoint = configuration.GetSection("Google:Endpoint").Value;
            return request;
        }

        public EngageStripeRequest GetStripeConfiguration()
        {
            EngageStripeRequest request = new EngageStripeRequest();
            request.SecretKey = configuration.GetSection("Stripe:SecretKey").Value;
            request.PublishableKey = configuration.GetSection("Stripe:PublishableKey").Value;
            return request;
        } 
    }
}
