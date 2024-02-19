using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SlayedLifeCore.Stripe;
using SlayedLifeModels.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IStripeService stripeService;
        private readonly IMapper mapper;
        public StripeController(IStripeService stripeService, IMapper mapper)
        {
            this.stripeService = stripeService;
            this.mapper = mapper;
        }

        [HttpPost("connect/{userId}")]
        public async Task<IActionResult> GetAccountLink([FromRoute] int userId)
        {
            var response = await stripeService.ConnectAccountLink(userId);
            return Ok(response);
        }

        [HttpGet("status/{userId}")]
        public async Task<IActionResult> GetAccount([FromRoute] int userId)
        {
            var result = await stripeService.GetAccount(userId);
            var response = mapper.Map<UserPaymentAccountDto>(result);
            if (result != null && result.Requirements != null && result.Requirements.CurrentlyDue != null && result.Requirements.CurrentlyDue.Count > 0) 
            {
                foreach(string due in result.Requirements.CurrentlyDue)
                {
                    response.lastError += $"{due}|";
                }
            }
            return Ok(response);
        }
    }
}
