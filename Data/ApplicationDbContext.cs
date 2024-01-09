using dini_m3ak.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dini_m3ak.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Car>()
            .HasOne(c => c.User)
            .WithMany(u => u.Cars);

            builder.Entity<Trip>()
            .HasOne(t => t.User);

            builder.Entity<Trip>()
            .HasOne(t => t.Source);

            builder.Entity<Trip>()
            .HasOne(t => t.Destination);

            builder.Entity<Trip>()
            .HasMany(t => t.Passangers);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}