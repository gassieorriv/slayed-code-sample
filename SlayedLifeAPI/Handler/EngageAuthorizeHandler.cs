using Microsoft.AspNetCore.Authorization;
using SlayedLifeCore.Configuration;
using SlayedLifeCore.Global;
using System.Threading.Tasks;

namespace SlayedLifeAPI.Handler
{
    public class EngageAuthorizeHandler : AuthorizationHandler<EngageHandlerRequirement>
    {
        private readonly ICoreConfiguration coreConfiguration;
        private readonly AuthorizationClient client;
        public EngageAuthorizeHandler(ICoreConfiguration coreConfiguration)
        {
            this.coreConfiguration = coreConfiguration;
            client = coreConfiguration.GetAuthorizedClient();
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, EngageHandlerRequirement requirement)
        {
            var response = await coreConfiguration.ValidateApiAuthorizationAsync(client.ApiToken);
            if(response == System.Net.HttpStatusCode.OK)
            {
                context.Succeed(requirement);
                return;
            }
            else
            {
                context.Fail();
                return;
            }
        }
    }
}
