using Microsoft.AspNetCore.Mvc;
using SlayedLifeCore.Social;
using SlayedLifeCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using SlayedLifeModels.Social;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace SlayedLifeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        private readonly ISocailMediaService socialMediaService;
        private readonly IMapper mapper;
        public SocialController(ISocailMediaService socialMediaService, IMapper mapper)
        {
            this.socialMediaService = socialMediaService;
            this.mapper = mapper;
        }
       
        [HttpPost("twitter/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<bool>))]
        public async Task<IActionResult> Twitter([FromBody] TwitterAccessDto twitterAccessDto, [FromRoute] int userId)
        {
            try
            {
                var connectedSocialAccount = mapper.Map<ConnectedSocialAccount>(twitterAccessDto);
                await socialMediaService.SaveUserTwitterInformation(connectedSocialAccount);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("instagram/connect")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InstagramAccountConnectResponse))]
        public async Task<IActionResult> ConnectInstagram()
        {
            var response = await socialMediaService.ConnectInstagramAccount();
            return Ok(response);
        }

        [HttpPost("update/connected/accounts")]
        public async Task<IActionResult> UpdateConnectedAccount(List<ConnectedSocialAccountDto> connectedAccountsDto)
        {
            var connectedAccounts = mapper.Map<List<ConnectedSocialAccount>>(connectedAccountsDto);
            var response = await socialMediaService.UpdateConncetedAccountActiveStatus(connectedAccounts);
            return Ok(response);
        }

        [HttpPost("youtube/connect/{userId}")]
        public async Task<IActionResult> ConnectYoutube([FromBody] GoogleAuthDto googleAuth, [FromRoute] int userId)
        {
            var socialAccount = new ConnectedSocialAccount();
            socialAccount.UserId = userId;
            socialAccount.Expires = float.Parse(googleAuth.expires_in) / 60;
            socialAccount.Token = googleAuth.access_token;
            socialAccount.RefreshToken = googleAuth.refresh_token;
            var response = await socialMediaService.ConnectYoutubeAccount(socialAccount);
            return Ok(true);
        }

        [HttpPost("facebook/posts")]
        public async Task<IActionResult> FacebookPost()
        {
            var response = await socialMediaService.GetFacebookPost();
            return Ok(response);
        }
    }
}
