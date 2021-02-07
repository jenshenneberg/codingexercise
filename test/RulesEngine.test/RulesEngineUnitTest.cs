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
            testRule.Verify(x => x.Apply(order), apply ? Times.Once : Times.Never);
        }

        [Fact]
        public void TestThatMultipleBusinessRulesAreApplied()
        {
            var order = new Order();
            var applicableRule = new Mock<IBusinessRule>();
            applicableRule.Setup(x => x.Applies(It.IsAny<Order>())).Returns(true);
            services.AddSingleton<IBusinessRule>(applicableRule.Object);

            var nonApplicableRule = new Mock<IBusinessRule>();
            nonApplicableRule.Setup(x => x.Applies(It.IsAny<Order>())).Returns(false);
            services.AddSingleton<IBusinessRule>(nonApplicableRule.Object);

            var provider = services.BuildServiceProvider();
            var businessRulesEngine = provider.GetService<IBusinessRulesEngine>();
            businessRulesEngine.Run(order);
            applicableRule.Verify(x => x.Applies(order), Times.Once);
            applicableRule.Verify(x => x.Apply(order), Times.Once);
            nonApplicableRule.Verify(x => x.Applies(order), Times.Once);
            nonApplicableRule.Verify(x => x.Apply(order), Times.Never);

        }
    }
}
