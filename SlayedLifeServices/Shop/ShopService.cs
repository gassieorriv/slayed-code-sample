using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeServices.Shop
{
    public class ShopService : IShopService
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IProductRepository productRepository;
        private readonly IStateTaxRepository stateTaxRepository;
        public ShopService(
            IServiceRepository serviceRepository,
            IStateTaxRepository stateTaxRepository,
            IProductRepository productRepository)
        {
            this.serviceRepository = serviceRepository;
            this.productRepository = productRepository;
            this.stateTaxRepository = stateTaxRepository;
        }

        public async Task<Product> CreateProduct(Product product)
        {
           var newProduct = await productRepository.Create(product);
            foreach(ProductSize size in product.ProductSize)
            {
                size.ProductId = newProduct.Id;
                await productRepository.Create(size);
            }
            return newProduct;
        }

        public async Task<Service> CreateService(Service service)
        {
            return await serviceRepository.Create(service);
        }

        public async Task<List<Product>> GetProducts(int userId)
        {
            var productIqueryable = productRepository.Get();
            var productList = await productIqueryable.Where(x => x.UserId == userId && !x.Deleted).ToListAsync();
            return productList;
        }

        public async Task<List<Product>> GetProducts(int userId, int skip, int take)
        {
            var productQueryable = productRepository.Get();
            var productSizeQueryably = productRepository.GetProductSizes();
            var productList = await productQueryable
                                    .Skip(skip)
                                    .Take(take)
                                    .Where(x => x.UserId == userId && !x.Deleted).ToListAsync();

            var productSizeList = await productSizeQueryably.Where(x => productList.Contains(x.Product)).ToListAsync();
            productList.ForEach(x =>
            {
                x.ProductSize = productSizeList.Where(y => y.ProductId == x.Id && y.Active).ToList();
            });
            return productList;
        }

        public async Task<List<Service>> GetServices(int userId, int skip, int take)
        {
            var serviceIqueryable = serviceRepository.Get();
            var serviceList = await serviceIqueryable
                                    .Where(x => x.UserId == userId && !x.Deleted)
                                    .Skip(skip)
                                    .Take(take).ToListAsync();
            return serviceList;
        }

        public async Task<List<StateTax>> GetStateTaxes()
        {
          return await stateTaxRepository.Get().ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            if (product != null && product.ProductSize != null) 
            {
                foreach(ProductSize productSize in product.ProductSize)
                {
                    productSize.ProductId = product.Id;
                    if(productSize.id > 0)
                    {
                        await productRepository.Update(productSize);
                    }
                    else
                    {
                        await productRepository.Create(productSize);
                    }
                }
            }
          var response = await productRepository.Update(product);
            response.ProductSize = product.ProductSize;
            return response;
        }

        public async Task<Service> UpdateService(Service service)
        {
            return await serviceRepository.Update(service);
        }
    }
}
