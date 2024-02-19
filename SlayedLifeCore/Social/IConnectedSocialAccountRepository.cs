using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeCore.Social
{
    public interface IConnectedSocialAccountRepository
    {
        Task<ConnectedSocialAccount> Add(ConnectedSocialAccount connectedSocialAccount);
        Task<ConnectedSocialAccount> Create(ConnectedSocialAccount connectedSocialAccount);
        Task<ConnectedSocialAccount> Update(ConnectedSocialAccount connectedSocialAccount);
        IQueryable<ConnectedSocialAccount> Get();

        Task<int> SaveChanges();
    }
}
