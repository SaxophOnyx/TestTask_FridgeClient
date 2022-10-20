using FridgeClient.FridgeAPI.ApiProvider;
using Microsoft.Extensions.DependencyInjection;

namespace FridgeClient
{
    public static class ServicesExtensions
    {
        public static void ConfigureDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IFridgeApiProvider, FridgeApiProvider>();
        }
    }
}
