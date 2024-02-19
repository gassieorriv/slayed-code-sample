using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Shop;
using SlayedLifeRepo.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeRepo.Shop
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly SlayedAPIContext context;
        public ServiceRepository(SlayedAPIContext context)
        {
            this.context = context;
        }
        public async Task<Service> Create(Service service)
        {
            service.CreatedDate = DateTime.Now;
            await context.AddAsync(service);
            context.SaveChanges();
            return service;
        }

        public IQueryable<Service> Get()
        {
            return context.Service.AsNoTracking();
        }

        public async Task<Service> Update(Service service)
        {
            var existingService = Get().Where(x => x.Id == service.Id).FirstOrDefault();
            existingService.Name = service.Name == null ? existingService.Name : service.Name;
            existingService.Active = service.Active;
            existingService.Deleted = service.Deleted;
            existingService.Description = service.Description == null ? existingService.Description : service.Description;
            existingService.Discount = service.Discount == null ? existingService.Discount : service.Discount;
            existingService.Price = service.Price;
            existingService.Duration = service.Duration;
            existingService.TaxId = service.TaxId;
            existingService.ModifiedDate = DateTime.Now;
            context.Update(existingService);
            await context.SaveChangesAsync();
            return existingService;
        }
    }
}
