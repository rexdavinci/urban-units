using fractionalized.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace fractionalized.Data
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : IdentityDbContext<Subscriber>(options)
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingUnit> BuildingUnits { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<BuildingGroup> BuildingGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) // must seed role before creating user
        {

            base.OnModelCreating(builder);


            builder.Entity<Portfolio>(x => x.HasKey(k => new { k.Subscriber, k.BuildingUnit }));
            builder.Entity<Portfolio>()
                .HasOne(u => u.Subscriber)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(k => k.SubscriberId);

            builder.Entity<Portfolio>()
                .HasOne(b => b.BuildingUnit)
                .WithMany(b => b.Portfolios)
                .HasForeignKey(k => k.BuildingUnitId);



            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
