using Microsoft.Extensions.DependencyInjection;
using RulesEngine.BusinessRuleEngine;
using RulesEngine.BusinessRules;
using RulesEngine.Membership;

namespace RulesEngine
{
    public static class Extensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IBusinessRulesEngine, BusinessRulesEngine>();
            services.AddSingleton<IPackageSystem, PackageSystem>();
            services.AddSingleton<IMembershipSystem, MembershipSystem>();
            services.AddBusinessRules();
            return services;
        }


        private static IServiceCollection AddBusinessRules(this IServiceCollection services)
        {
            services.AddSingleton<IBusinessRule, GeneratePackageSlip>();
            services.AddSingleton<IBusinessRule, GenerateRoyaltyPackageSlip>();
            services.AddSingleton<IBusinessRule, ActivateMembership>();

            return services;
        }
    }
}
