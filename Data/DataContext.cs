using diplom_back.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace diplom_back.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole<Guid>>().HasData
            (
                new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = "FreeUser", NormalizedName = "FREEUSER" },
                new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = "PlusUser", NormalizedName = "PLUSUSER" },
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );
        }

        public DbSet<Organization> Organization { get; set; } = null!;
        public DbSet<OrganizationIndicators> OrganizationIndicators { get; set; } = null!;
        public DbSet<LiquidityIndicators> LiquidityIndicators { get; set; } = null!;
        public DbSet<ProfitabilityIndicators> ProfitabilityIndicators { get; set; } = null!;
        public DbSet<FinancialIndicators> FinancialIndicators { get; set; } = null!;
    }
}
