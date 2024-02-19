using SlayedLifeModels.Shop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlayedLifeCore.Shop
{
    public interface IShopService
    {
        Task<Product> CreateProduct(Product product);

        Task<Service> CreateService(Service service);

        Task<Product> UpdateProduct(Product product);

        Task<Service> UpdateService(Service service);

        Task<List<Service>> GetServices(int userId, int skip, int take);
        Task<List<Product>> GetProducts(int userId);
        Task<List<Product>> GetProducts(int userId, int skip, int take);
        Task<List<StateTax>> GetStateTaxes();
    }
}
