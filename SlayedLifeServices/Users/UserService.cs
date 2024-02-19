using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SlayedLifeCore;
using SlayedLifeCore.Configuration;
using SlayedLifeCore.Global;
using SlayedLifeCore.Preferences;
using SlayedLifeCore.Social;
using SlayedLifeCore.Stripe;
using SlayedLifeCore.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeServices.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ISocailMediaService socialMediaService;
        private readonly IMapper mapper;
        private readonly AuthorizationClient client;
        private readonly IStripeService stripeService;
        private readonly IPreferenceService preferenceService;
        private readonly IUserScheduleService userScheduleService;
        public UserService(IUserRepository userRepository,
                           IMapper mapper,
                           ICoreConfiguration coreConfiguration,
                           IPreferenceService preferenceService,
                           IStripeService stripeService,
                           IUserScheduleService userScheduleService,
                           ISocailMediaService socialMediaService)
        {
            this.userRepository = userRepository;
            this.socialMediaService = socialMediaService;
            this.preferenceService = preferenceService;
            this.stripeService = stripeService;
            this.userScheduleService = userScheduleService;
            this.mapper = mapper;
            client = coreConfiguration.GetAuthorizedClient();
        }

        public async Task<Response<User>> CreateUserWithFacebook()
        {
            var response = new Response<User>();
            var facebokUser = await socialMediaService.GetFacebookBasicProfile();
            if(facebokUser == null)
            {
                throw new Exception("Invalid or unauthorized user");
            }    
            if(facebokUser.id != client.UserId)
            {
                throw new Exception("The Access Token provided is invalid for the requesting user");
            }
            var user = mapper.Map<User>(facebokUser);
            var connectedSocialAccount = await socialMediaService.GetFacebookUser(facebokUser.id);

            User existingUser = await userRepository.Get()
                       .Where(x => x.email == user.email)
                       .Include(x => x.userPreferences).FirstOrDefaultAsync();

            if (connectedSocialAccount == null)
            {
                if (existingUser == null)
                {
                    response.data = await userRepository.Create(user);
                }
                else
                {
                    response.data = existingUser;
                }
                connectedSocialAccount = new ConnectedSocialAccount
                {
                    UserId = response.data.id,
                    AccountId = facebokUser.id,
                    Token = Utilities.Encrypt(client.AccessToken),
                    SocialAccountId = (int)SocialAccontEnum.Facebook,
                    Active = true,
                };
                await socialMediaService.CreateConnectedSocialAccount(connectedSocialAccount);
            }
            else
            {
                connectedSocialAccount.AccountId = facebokUser.id;
                connectedSocialAccount.Token = Utilities.Encrypt(client.AccessToken);
                connectedSocialAccount = await socialMediaService.UpdateConnectedSocialAccount(connectedSocialAccount);
                user.id = connectedSocialAccount.UserId;
                if(existingUser != null && existingUser.userPreferences != null)
                {
                  UserPreference preference = existingUser.userPreferences.Where(x => x.preferenceId == (int)PreferencesEnum.UpdateInfoDuringLogin).FirstOrDefault();
                    if(preference != null && preference.active)
                    {
                        response.data = await userRepository.Update(user);
                    }
                    else
                    {
                        response.data = existingUser;
                    }
                }
            }

            response.data = await GetCompleteUser(response.data.id);
            response.success = true;
            try
            {
                var account = await stripeService.GetAccount(response.data.id);
                if (account != null)
                {
                    response.data.userPaymentAccount = new UserPaymentAccount()
                    {
                        ChargesEnabled = account.ChargesEnabled,
                    };
                }
            }
            catch(Exception ex)
            {
                // log this exception
            }

            return response;
        }

        public async Task<Response<User>> CreateUserWithGoogle(GoogleUser googleUser)
        {
            var response = new Response<User>();
            var user = mapper.Map<User>(googleUser);
            var connectedSocialAccount = await socialMediaService.GetGoogleUser(googleUser.id);

            User existingUser = await userRepository.Get()
                                .Where(x => x.email == user.email)
                                .Include(x => x.userPreferences).FirstOrDefaultAsync();

            if (connectedSocialAccount == null)
            {
                if (existingUser == null)
                {
                    response.data = await userRepository.Create(user);
                }
                else
                {
                    response.data = existingUser;
                }

                connectedSocialAccount = new ConnectedSocialAccount
                {
                    UserId = response.data.id,
                    AccountId = googleUser.id,
                    Token = Utilities.Encrypt(client.AccessToken),
                    SocialAccountId = (int)SocialAccontEnum.Google,
                    Active = true,
                };
                try
                {
                    await socialMediaService.CreateConnectedSocialAccount(connectedSocialAccount);
                }
                catch(Exception ex)
                {
                    string s = ex.Message;
                }
            }
            else
            {
                connectedSocialAccount.AccountId = googleUser.id;
                await socialMediaService.UpdateConnectedSocialAccount(connectedSocialAccount);
                user.id = connectedSocialAccount.UserId;
                if (existingUser != null && existingUser.userPreferences != null)
                {
                    UserPreference preference = existingUser.userPreferences.Where(x => x.preferenceId == (int)PreferencesEnum.UpdateInfoDuringLogin).FirstOrDefault();
                    if (preference != null && preference.active)
                    {
                        response.data = await userRepository.Update(user);
                    }
                    else
                    {
                        response.data = existingUser;
                    }
                }
            }

            response.data = await GetCompleteUser(response.data.id);
            response.success = true;
            try
            {
                var account = await stripeService.GetAccount(response.data.id);
                if (account != null)
                {
                    response.data.userPaymentAccount = new UserPaymentAccount()
                    {
                        ChargesEnabled = account.ChargesEnabled,
                    };
                }
            }
            catch(Exception ex)
            {
                //log exception
            }
            return response;
        }

        public async Task<Response<User>> UpdateExistingUser(User user)
        {
            var response = new Response<User>();
            await userRepository.Update(user);
            response.data = await GetCompleteUser(user.id);
            return response;
        }

        public async Task<Response<User>> GetUserById(int id)
        {
            var response = new Response<User>();
            response.data = await GetCompleteUser(id);
            response.success = true;

            try
            {
                var account = await stripeService.GetAccount(response.data.id);
                if (account != null)
                {
                    response.data.userPaymentAccount = new UserPaymentAccount()
                    {
                        ChargesEnabled = account.ChargesEnabled,
                    };
                }
            }
            catch(Exception ex)
            {
                //log exception
            }
            return response;
        }

        public List<CurrentPreferences> GetUserPreferences(int userId)
        {
           return preferenceService.GetUserPreferences(userId, 1); // TODO: get the users current level.
        }

        public async Task<Response<List<CurrentPreferences>>> UpdateCurrentPreferences(int userId, List<CurrentPreferences> currentPreferences)
        {
            Response<List<CurrentPreferences>> response = new Response<List<CurrentPreferences>>();
            response.data = await preferenceService.UpdateCurrentPreferences(currentPreferences, userId);
            response.success = true;
            return response;
        }

        private async Task<User> GetCompleteUser(int id)
        {
            return await userRepository.Get()
                        .Include(x => x.userPreferences)
                        .Include(x => x.ConnectedSocialAccounts)
                        .ThenInclude(x => x.SocialAccount)
                        .Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<UserSchedule>> GetUserSchedules(int userId)
        {
            return await userScheduleService.GetUserScheduleByUserId(userId);
        }

        public async Task<List<UserSchedule>> CreateUserSchedule(List<UserSchedule> userSchedule)
        {
            return await userScheduleService.CreateUserSchedule(userSchedule);
        }

        public async Task<List<UserSchedule>> UpdateUserSchedule(List<UserSchedule> userSchedule)
        {
            return await userScheduleService.UpdateSchedule(userSchedule);
        }
    }
}
