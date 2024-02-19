using SlayedLifeCore.Preferences;

namespace SlayedLifeCore.Users
{
    public class UserPreference
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int preferenceId { get; set; }
        public bool active { get; set; }
        public virtual Preference Preference { get; set; }
    }
}
