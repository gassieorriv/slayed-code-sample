using Microsoft.AspNetCore.Mvc;
using SlayedLifeCore.Configuration;

namespace SlayedLifeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly ICoreConfiguration configuration;
        public BaseController(ICoreConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
