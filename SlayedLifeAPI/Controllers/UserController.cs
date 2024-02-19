using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlayedLifeCore.Users;
using AutoMapper;
using System.Threading.Tasks;
using SlayedLifeModels.Users;
using System;
using SlayedLifeCore;
using SlayedLifeCore.Configuration;
using SlayedLifeCore.Social;
using SlayedLifeModels.Social;
using SlayedLifeCore.Global;
using System.Collections.Generic;
using SlayedLifeCore.Preferences;

namespace SlayedLifeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ICoreConfiguration coreConfiguration;
        private readonly AuthorizationClient client;
        public UserController(IUserService userService, ICoreConfiguration coreConfiguration, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.coreConfiguration = coreConfiguration;
            client = coreConfiguration.GetAuthorizedClient();
        }

        /// <summary>
        /// verifies and creates a user using facebook, or updatings existing user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost("google")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public async Task<IActionResult> Google(GoogleUserDTO user = null)
        {
            try
            {
                var googleUser = mapper.Map<GoogleUser>(user);
                Response<User> result;
                result = await userService.CreateUserWithGoogle(googleUser);
                if (!result.success)
                {
                    return BadRequest(result.message);
                }

                var response = mapper.Map<UserDto>(result.data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("fb")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public async Task<IActionResult> Facebook()
        {
            try
            {
                Response<User> result;
                result = await userService.CreateUserWithFacebook();
                if (!result.success)
                {
                    return BadRequest(result.message);
                }

                var response = mapper.Map<UserDto>(result.data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public async Task<IActionResult> Update(UserDto userDto)
        {
             var user = mapper.Map<User>(userDto);
            var result = await userService.UpdateExistingUser(user);
            var response = mapper.Map<UserDto>(result.data);
            return Ok(response);
        }

        [HttpPost("authorize")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StatusCodes))]
        public async Task<IActionResult> Authorize()
        {
            var response = await coreConfiguration.ValidateApiAuthorizationAsync(client.ApiToken);
            switch (response)
            {
                case System.Net.HttpStatusCode.OK:
                    return Ok("true");
                case System.Net.HttpStatusCode.Unauthorized:
                default:
                    return Unauthorized("false");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await userService.GetUserById(id);
            var response = mapper.Map<UserDto>(result.data);
            return Ok(response);
        }

        [HttpGet("preferences/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CurrentPreferences>))]
        public IActionResult GetUserPreferences([FromRoute] int userId)
        {
            var data = userService.GetUserPreferences(userId);
            return Ok(data);
        }

        [HttpPost("preferences/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CurrentPreferences>))]
        public async Task<IActionResult> UpdateUserPreferences([FromRoute]int userId, [FromBody]List<CurrentPreferences> preferences)
        {
            var data = await userService.UpdateCurrentPreferences(userId, preferences);
            if (data.success)
            {
                return Ok(data);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("schedule/{userId}")]
        public async Task<IActionResult> GetUserSchedule([FromRoute] int userId)
        {
            var response =  await userService.GetUserSchedules(userId);
            return Ok(response);
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> CreateUserSchedule([FromBody] List<UserScheduleDto> userScheduleDtos)
        {
            var userSchedule = mapper.Map<List<UserSchedule>>(userScheduleDtos);
            var response = await userService.CreateUserSchedule(userSchedule);
            return Ok(response);
        }

        [HttpPost("schedule/update")]
        public async Task<IActionResult> UpdateUserSchedule([FromBody] List<UserScheduleDto> userScheduleDtos)
        {
            var userSchedule = mapper.Map<List<UserSchedule>>(userScheduleDtos);
            var response = await userService.UpdateUserSchedule(userSchedule);
            return Ok(response);
        }

    }
}
