using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeCore.Shop
{
    public interface IProductRepository
    {
        Task<Product> Create(Product product);

        Task<Product> Update(Product product);

        Task<ProductSize> Create(ProductSize productSize);

        Task<ProductSize> Update(ProductSize product);

        IQueryable<Product> Get();

        IQueryable<ProductSize> GetProductSizes();
    }
}
