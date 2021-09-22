using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using WebRestaurantes.Domain;


namespace WebRestaurantes.Repository
{
    public class WebRestaurantesContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public WebRestaurantesContext(DbContextOptions<WebRestaurantesContext> options,
            IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

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

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

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