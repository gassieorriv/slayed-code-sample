using System.Linq;
using System.Threading.Tasks;

namespace SlayedLifeCore.Preferences
{
    public interface IPreferenceRepository
    {
        Task<Preference> Create(Preference preference);

        Task<Preference> Update(Preference preference);

        IQueryable<Preference> Get();
    }
}
