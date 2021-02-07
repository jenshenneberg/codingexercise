using System;
using Microsoft.Extensions.DependencyInjection;
using RulesEngine.BusinessRuleEngine;

namespace RulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = SetupServices();
            var engine = serviceProvider.GetRequiredService<IBusinessRulesEngine>();
            var order = GenerateSampleOrder();
            engine.Run(order);
        }

        private static SampleOrder GenerateSampleOrder()
        {
            return new SampleOrder();
        }

        private static IServiceProvider SetupServices()
        {
            var services = new ServiceCollection();
            services.AddServices();
            var provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
