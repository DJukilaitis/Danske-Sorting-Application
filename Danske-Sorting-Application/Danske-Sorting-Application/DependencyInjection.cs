using Danske_Sorting_Application.Interfaces;
using Danske_Sorting_Application.Repositories;
using Danske_Sorting_Application.Services;

namespace Danske_Sorting_Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<INumberOrderingService, NumberOrderingService>();
            services.AddScoped<INumberOrderingRepository, NumberOrderingRepository>();

            return services;
        }
    }
}
