using SlayedLifeCore.Users;
using System;

namespace SlayedLifeCore.Support
{
    public class SupportNote
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string note { get; set; }
        public bool resolved { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual User User { get; set; }
    }
}
