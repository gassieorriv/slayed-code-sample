using System.Threading.Tasks;

namespace SlayedLifeCore.Social.Google
{
    public interface IGoogleHttpClient
    {
        Task<object> ExchangeAuthoriztionCode(string authCode);

        Task<object> GetYoutubeProfileData(ConnectedSocialAccount socialAccount);
    }
}
