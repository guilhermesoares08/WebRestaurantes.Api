using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebRestaurantes.Domain;


namespace WebRestaurantes.Repository
{
    public class WebRestaurantesContext : IdentityDbContext<User, Role, int,
                                                    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public WebRestaurantesContext(DbContextOptions<WebRestaurantesContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<RestaurantAddress> RestaurantAddress { get; set; }

        public DbSet<RestaurantExtension> RestaurantExtension { get; set; }

        public DbSet<Domain.Domain> Domain { get; set; }

        public DbSet<DomainValue> DomainValue { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<State> State { get; set; }

        public DbSet<Scheduling> Scheduling { get; set; }

        public DbSet<SchedulingOrder> Times { get; set; }

        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());

            modelBuilder.Entity<RestaurantExtension>()
            .HasOne(s => s.DomainValue)
            .WithMany()
            .HasForeignKey(e => e.DomainValueId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
            .Entity<SchedulingOrder>(
               eb =>
               {
                   eb.HasNoKey();
               });
        }
    }
}