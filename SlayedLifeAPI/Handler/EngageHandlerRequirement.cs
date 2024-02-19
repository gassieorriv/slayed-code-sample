using Microsoft.AspNetCore.Authorization;

namespace SlayedLifeAPI.Handler
{
    public class EngageHandlerRequirement : IAuthorizationRequirement
    {
        public EngageHandlerRequirement()
        {
        }
    }
}
