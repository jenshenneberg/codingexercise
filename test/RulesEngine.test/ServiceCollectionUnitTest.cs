using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace RulesEngine.test
{
    public class ServiceCollectionUnitTest
    {
        [Fact]
        public void ServiceCollectionTest()
        {
            var services = new ServiceCollection();
            services.AddServices();
            var provider = services.BuildServiceProvider();
            Assert.NotNull(provider);
        }
    }
}
