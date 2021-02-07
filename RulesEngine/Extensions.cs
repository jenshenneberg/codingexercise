using Microsoft.Extensions.DependencyInjection;

namespace RulesEngine
{
    public static class Extensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<BusinessRulesEngine>();
            return services;
        }
    }
}
