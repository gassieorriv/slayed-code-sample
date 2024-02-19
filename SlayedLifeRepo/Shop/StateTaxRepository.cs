using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Shop;
using SlayedLifeRepo.Context;
using System.Linq;

namespace SlayedLifeRepo.Shop
{
    public class StateTaxRepository : IStateTaxRepository
    {
        private readonly SlayedAPIContext context;

        public StateTaxRepository(SlayedAPIContext context)
        {
            this.context = context;
        }

        public IQueryable<StateTax> Get()
        {
            return context.StateTax.AsNoTracking();
        }
    }
}
