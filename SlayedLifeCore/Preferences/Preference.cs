using SlayedLifeCore.Levels;

namespace SlayedLifeCore.Preferences
{
    public class Preference
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int levelId { get; set; }
        public virtual Level level { get; set; }
    }
}
