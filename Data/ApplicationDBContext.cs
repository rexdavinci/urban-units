using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace fractionalized.Data
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : IdentityDbContext<Subscriber>(options)
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingUnit> BuildingUnits { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
