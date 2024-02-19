using System.Linq;

namespace SlayedLifeCore.Shop
{
    public interface IStateTaxRepository
    {
        IQueryable<StateTax> Get();
    }
}
