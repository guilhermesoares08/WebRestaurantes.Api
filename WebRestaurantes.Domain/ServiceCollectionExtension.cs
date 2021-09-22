using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebRestaurantes.Domain
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddScoped<IRestaurantService, RestaurantService>();

            services.AddScoped<IDomainService, DomainService>();

            services.AddScoped<IRestaurantAddressService, RestaurantAddressService>();

            services.AddScoped<ISchedulingService, SchedulingService>();

            services.AddScoped<IRestaurantExtensionService, RestaurantExtensionService>();

            services.AddScoped<ITableService, TableService>();

            services.AddScoped<IImageService, ImageService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
