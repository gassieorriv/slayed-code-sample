using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeCore.Users
{
    public interface IUserRepository
    {
        Task<User> Create(User user);

        Task<User> Update(User user);

        IQueryable<User> Get();
    }
}
