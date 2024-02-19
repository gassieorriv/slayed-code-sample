using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlayedLifeCore.Social
{
    public interface ISocailMediaService
    {
        Task<FacebookUser> GetFacebookBasicProfile();
        Task<ConnectedSocialAccount> CreateConnectedSocialAccount(ConnectedSocialAccount connectedSocialAccount);
        Task<ConnectedSocialAccount> GetFacebookUser(string fbid);
        Task<ConnectedSocialAccount> GetGoogleUser(string googleId);
        Task<ConnectedSocialAccount> UpdateConnectedSocialAccount(ConnectedSocialAccount connectedSocialAccount);
        Task<ConnectedSocialAccount> SaveUserTwitterInformation(ConnectedSocialAccount connectedSocialAccount);
        Task<InstagramAccountConnectResponse> ConnectInstagramAccount();
        Task<List<ConnectedSocialAccount>> UpdateConncetedAccountActiveStatus(List<ConnectedSocialAccount> connectedAccounts);
        Task<object> GetFacebookPost();
        Task<bool> ConnectYoutubeAccount(ConnectedSocialAccount social);
    }
}
