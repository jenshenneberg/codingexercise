using Microsoft.Extensions.DependencyInjection;
using RulesEngine.BusinessRules;

namespace RulesEngine
{
    public static class Extensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IBusinessRulesEngine, BusinessRulesEngine>();
            services.AddSingleton<IPackageSystem, PackageSystem>();
            services.AddBusinessRules();
            return services;
        }


        private static IServiceCollection AddBusinessRules(this IServiceCollection services)
        {
            services.AddSingleton<IBusinessRule, GeneratePackageSlip>();
            return services;
        }
    }
}
