using Microsoft.Extensions.DependencyInjection;

namespace RulesEngine
{
    public static class Extensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IBusinessRulesEngine, BusinessRulesEngine>();
            return services;
        }


        public static IServiceCollection AddBusinessRule(this IServiceCollection services)
        {
            services.AddSingleton<IBusinessRulesEngine, BusinessRulesEngine>();
            return services;
        }
    }
}
