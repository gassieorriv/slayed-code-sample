using Microsoft.EntityFrameworkCore;
using SlayedLifeCore.Configuration;
using SlayedLifeCore.Levels;
using SlayedLifeCore.Preferences;
using SlayedLifeCore.Shop;
using SlayedLifeCore.Social;
using SlayedLifeCore.Support;
using SlayedLifeCore.Users;

namespace SlayedLifeRepo.Context
{
    public partial class SlayedAPIContext : DbContext
    {
        private string ConnectionString { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPreference> UserPreference { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Preference> Preference { get; set; }
        public virtual DbSet<SupportNote> SupportNote { get; set; }
        public virtual DbSet<SocialAccount> SocialAccount { get; set; }
        public virtual DbSet<ConnectedSocialAccount> ConnectedSocialAccount { get; set; }
        public virtual DbSet<UserPaymentAccount> UserPaymentAccount { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductSize> ProductSize { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<StateTax> StateTax { get; set; }
        public virtual DbSet<UserSchedule> UserSchedule { get; set; }
        public SlayedAPIContext(DbContextOptions<SlayedAPIContext> options) : base(options)
        {
            
        }
        public SlayedAPIContext(ICoreConfiguration configuration)
        {

            ConnectionString = configuration.GetConnectionString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(this.ConnectionString))
            {
                optionsBuilder.UseSqlServer(this.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
