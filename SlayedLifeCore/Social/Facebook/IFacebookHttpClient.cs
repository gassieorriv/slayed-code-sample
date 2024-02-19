using System.Threading.Tasks;

namespace SlayedLifeCore.Social
{
    public interface IFacebookHttpClient
    {
        Task<object> GetFacebookBasicProfile(string facebookId, string accessToken);
        Task<object> GetInstagramAccount(string accessToken);
        Task<object> GetMyPost(string accessToken);
    }
}
