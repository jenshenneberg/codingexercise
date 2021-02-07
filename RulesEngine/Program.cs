using System;
using Microsoft.Extensions.DependencyInjection;

namespace RulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = SetupServices();
            var engine = serviceProvider.GetRequiredService<IBusinessRulesEngine>();
            var order = GenerateTestOrder();
            engine.Run(order);
        }

        private static Order GenerateTestOrder()
        {
            return new Order();
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
