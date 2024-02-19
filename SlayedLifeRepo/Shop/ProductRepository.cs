using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Shop;
using SlayedLifeRepo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeRepo.Shop
{
    public class ProductRepository : IProductRepository
    {
        private readonly SlayedAPIContext context;

        public ProductRepository(SlayedAPIContext context)
        {
            this.context = context;
        }

        public async Task<Product> Create(Product product)
        {
            product.CreatedDate = DateTime.Now;
            await context.AddAsync(product);
            context.SaveChanges();
            return product;
        }

        public async Task<ProductSize> Create(ProductSize productSize)
        {
            await context.AddAsync(productSize);
            context.SaveChanges();
            return productSize;
        }

        public async Task<ProductSize> Update(ProductSize productSize)
        {
            var existingProduct = GetProductSizes().Where(x => x.id == productSize.id).FirstOrDefault();
            existingProduct.Quantity = productSize.Quantity;
            existingProduct.Active = productSize.Active;
            context.Update(existingProduct);
            await context.SaveChangesAsync();
            return existingProduct;
        }

        public IQueryable<Product> Get()
        {
            return context.Product.AsNoTracking();
        }

        public IQueryable<ProductSize> GetProductSizes()
        {
            return context.ProductSize.AsNoTracking();
        }

        public async Task<Product> Update(Product product)
        {
            var existingProduct = Get().Where(x => x.Id == product.Id).FirstOrDefault();
            context.Entry(existingProduct).State = EntityState.Modified;
            existingProduct.Name = product.Name == null ? existingProduct.Name : product.Name;
            existingProduct.Active = product.Active;
            existingProduct.Deleted = product.Deleted;
            existingProduct.Description = product.Description == null ? existingProduct.Description : product.Description;
            existingProduct.Discount = product.Discount == null ? existingProduct.Discount : product.Discount;
            existingProduct.Price = product.Price;
            existingProduct.DiscountType = product.DiscountType == null ? existingProduct.DiscountType : product.DiscountType;
            existingProduct.ShippingType = product.ShippingType == null ? existingProduct.ShippingType : product.ShippingType;
            existingProduct.TaxId = product.TaxId;
            existingProduct.Category = product.Category;
            existingProduct.Shipping = product.Shipping;
            existingProduct.ModifiedDate = DateTime.Now;
            context.Update(existingProduct);
            
            await context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
