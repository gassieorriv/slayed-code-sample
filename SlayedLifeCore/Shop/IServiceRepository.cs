using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeCore.Shop
{
    public interface IServiceRepository
    {
        Task<Service> Create(Service service);

        Task<Service> Update(Service service);

        IQueryable<Service> Get();
    }
}
