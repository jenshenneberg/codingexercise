using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace RulesEngine.test
{
    public class RulesEngineUnitTest
    {
        private ServiceCollection services;

        public RulesEngineUnitTest()
        {
            services = new ServiceCollection();
            services.AddServices();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestThatOnlyApplicableBusinessRulesAreApplied(bool apply)
        {
            var order = new Order();
            var testRule = new Mock<IBusinessRule>();
            testRule.Setup(x => x.Applies(It.IsAny<Order>())).Returns(apply);
            services.AddSingleton<IBusinessRule>(testRule.Object);
            var provider = services.BuildServiceProvider();
            var businessRulesEngine = provider.GetService<IBusinessRulesEngine>();
            businessRulesEngine.Run(order);
            testRule.Verify(x => x.Applies(order));
            if (apply)
                testRule.Verify(x => x.Apply(order));
        }
    }
}
