using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebRestaurantes.Domain;
using WebRestaurantes.Repository.Interfaces;

namespace WebRestaurantes.Repository
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebRestaurantesDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<WebRestaurantesContext>(x => x.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWebRestaurantesRepository, WebRestaurantesRepository>();

            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IRestaurantAddressRepository, RestaurantAddressRepository>();

            services.AddScoped<IDomainRepository, DomainRepository>();

            services.AddScoped<ISchedulingRepository, SchedulingRepository>();

            services.AddScoped<IRestaurantExtensionRepository, RestaurantExtensionRepository>();

            return services;
        }
    }
}
