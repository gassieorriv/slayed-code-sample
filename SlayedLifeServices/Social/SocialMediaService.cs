using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SlayedLifeCore.Configuration;
using SlayedLifeCore.Global;
using SlayedLifeCore.Social;
using System.Linq;
using System.Threading.Tasks;
using SlayedLifeCore;
using System.Collections.Generic;
using System;
using SlayedLifeCore.Social.Google;

namespace SlayedLifeServices.Social
{
    public class SocialMediaService : ISocailMediaService
    {
        private readonly IFacebookHttpClient facebookHttpClient;
        private readonly IGoogleHttpClient googleHttpClient;
        private readonly AuthorizationClient authorizationClient;
        private readonly IConnectedSocialAccountRepository connectedSocialAccountRepository;

        public SocialMediaService(
            IFacebookHttpClient facebookHttpClient,
            IGoogleHttpClient googleHttpClient,
            ICoreConfiguration coreConfiguration,
            IConnectedSocialAccountRepository connectedSocialAccountRepository)
        {
            this.facebookHttpClient = facebookHttpClient;
            this.googleHttpClient = googleHttpClient;
            this.connectedSocialAccountRepository = connectedSocialAccountRepository;
            authorizationClient = coreConfiguration.GetAuthorizedClient();
        }

        public async Task<ConnectedSocialAccount> SaveUserTwitterInformation(ConnectedSocialAccount connectedSocialAccount)
        {
            connectedSocialAccount.Token = Utilities.Encrypt(connectedSocialAccount.Token);
            connectedSocialAccount.Secret = Utilities.Encrypt(connectedSocialAccount.Secret);
            await connectedSocialAccountRepository.Create(connectedSocialAccount);
            return connectedSocialAccount;
        }

        public async Task<FacebookUser> GetFacebookBasicProfile()
        {
            var facebookData = await facebookHttpClient.GetFacebookBasicProfile(authorizationClient.UserId, authorizationClient.AccessToken);
            var facebookUser = JsonConvert.DeserializeObject<FacebookUser>(facebookData.ToString());
            return facebookUser;
        }

        public async Task<ConnectedSocialAccount> CreateConnectedSocialAccount(ConnectedSocialAccount connectedSocialAccount)
        {
            return await connectedSocialAccountRepository.Create(connectedSocialAccount);
        }

        public async Task<ConnectedSocialAccount> UpdateConnectedSocialAccount(ConnectedSocialAccount connectedSocialAccount)
        {
            return await connectedSocialAccountRepository.Update(connectedSocialAccount);
        }

        public async Task<InstagramAccountConnectResponse> ConnectInstagramAccount() 
        {
            var response = InstagramAccountConnectResponse.AllAccounts;
            ConnectedSocialAccount currentUserAccount;
            if (authorizationClient.AuthorizationType == AuthorizeTypeEnum.Facebook)
            {
                currentUserAccount = await GetFacebookUser(authorizationClient.UserId);
            }
            else
            {
                currentUserAccount = await GetGoogleUser(authorizationClient.UserId);
            }
          
            var result = await facebookHttpClient.GetInstagramAccount(authorizationClient.AccessToken);
            var instagramData = JsonConvert.DeserializeObject<InstagramBusiness>(result.ToString());

            try
            {
                foreach(InstagramBusinessAccountData business in instagramData.businesses.data)
                {
                    foreach(instagram_account_values account in business.owned_instagram_accounts.Data)
                    {
                        try
                        {

                            ConnectedSocialAccount connectedSocialAccount = new ConnectedSocialAccount();
                            connectedSocialAccount.AccountId = account.id;
                            connectedSocialAccount.SocialAccountId = (int)SocialAccontEnum.Instagram;
                            connectedSocialAccount.UserId = currentUserAccount.UserId;
                            connectedSocialAccount.Active = true;
                            connectedSocialAccount.Followers = account.followed_by_count;
                            connectedSocialAccount.Following = account.follow_count;
                            connectedSocialAccount.Name = account.username;
                            connectedSocialAccount.Picture = account.profile_pic;
                            var existingAccount = await connectedSocialAccountRepository.Get()
                                            .Where(x => x.AccountId == account.id && 
                                                   x.UserId == currentUserAccount.UserId)
                                            .FirstOrDefaultAsync();
                            if (existingAccount == null)
                            {
                                await connectedSocialAccountRepository.Create(connectedSocialAccount);
                            }
                            else
                            {
                                connectedSocialAccount.Id = existingAccount.Id;
                                await connectedSocialAccountRepository.Update(connectedSocialAccount);
                            }
                        }
                        catch
                        {
                            response = InstagramAccountConnectResponse.AtLeastOneFailedAccount;
                        }
                    }                   
                }
            }
            catch 
            {
                response = InstagramAccountConnectResponse.NoInstagramAccount;
            }

            return response;
        }

        public async Task<ConnectedSocialAccount> GetFacebookUser(string fbid)
        {
            var socialQueryable = connectedSocialAccountRepository.Get();
            socialQueryable = socialQueryable
                                .Include(x => x.SocialAccount)
                                .Where(x => x.AccountId == fbid && x.SocialAccountId == (int)SocialAccontEnum.Facebook);
            return await socialQueryable.FirstOrDefaultAsync();
        }

        public async Task<ConnectedSocialAccount> GetGoogleUser(string googleId)
        {
            var socialQueryable = connectedSocialAccountRepository.Get();
            socialQueryable = socialQueryable
                                   .Include(x => x.SocialAccount)
                                   .Where(x => x.AccountId == googleId && x.SocialAccountId == (int)SocialAccontEnum.Google);
            return await socialQueryable.FirstOrDefaultAsync();
        }

        public async Task<List<ConnectedSocialAccount>> UpdateConncetedAccountActiveStatus(List<ConnectedSocialAccount> connectedAccounts)
        {
            var response = new List<ConnectedSocialAccount>();
            var currentUserAccount =  await connectedSocialAccountRepository.Get()
                                .Where(x => x.AccountId == authorizationClient.UserId)
                                .FirstOrDefaultAsync();
            var existingAccount = connectedAccounts.Where(x => x.UserId == currentUserAccount.UserId).FirstOrDefault();
             
            if (currentUserAccount == null)
            {
                throw new Exception("This user does not have access to this account");
            }
            
            foreach(ConnectedSocialAccount connectedAccount in connectedAccounts)
            {
               var account = await connectedSocialAccountRepository.Update(connectedAccount);
                response.Add(account);
            }
            return response;
        }

        public async Task<bool> ConnectYoutubeAccount(ConnectedSocialAccount socialAccount)
        {
          //var data = await googleHttpClient.ExchangeAuthoriztionCode(authCode);
           return true;
        }

        public async Task<object> GetFacebookPost()
        {
           var response = new List<InstagramMedia>();
           var results = await facebookHttpClient.GetMyPost(authorizationClient.AccessToken);
           var instagramData = JsonConvert.DeserializeObject<InstagramBusiness>(results.ToString());
            try
            {
                response = instagramData.businesses.data.First().instagram_business_accounts.Data.First().media.Data;
            }
            catch
            {
                response = new List<InstagramMedia>(); //InstagramAccountConnectResponse.NoInstagramAccount;
            }
            return response;
        }
    }
}
