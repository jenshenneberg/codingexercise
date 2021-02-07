using Microsoft.Extensions.DependencyInjection;
using Moq;
using RulesEngine.BusinessRuleEngine;
using Xunit;

namespace RulesEngine.test
{
    public class RulesEngineUnitTest
    {
        private readonly ServiceCollection _services;

        public RulesEngineUnitTest()
        {
            _services = new ServiceCollection();
            _services.AddServices();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestThatOnlyApplicableBusinessRulesAreApplied(bool apply)
        {
            var order = new Mock<IOrder>();
            var testRule = new Mock<IBusinessRule>();
            testRule.Setup(x => x.Applies(It.IsAny<IOrder>())).Returns(apply);
            _services.AddSingleton<IBusinessRule>(testRule.Object);
            var provider = _services.BuildServiceProvider();
            var businessRulesEngine = provider.GetService<IBusinessRulesEngine>();
            businessRulesEngine.Run(order.Object);
            testRule.Verify(x => x.Applies(order.Object));
            testRule.Verify(x => x.Apply(order.Object), apply ? Times.Once : Times.Never);
        }

        [Fact]
        public void TestThatMultipleBusinessRulesAreApplied()
        {
            var order = new Mock<IOrder>();
            var applicableRule = new Mock<IBusinessRule>();
            applicableRule.Setup(x => x.Applies(It.IsAny<IOrder>())).Returns(true);
            _services.AddSingleton<IBusinessRule>(applicableRule.Object);

            var nonApplicableRule = new Mock<IBusinessRule>();
            nonApplicableRule.Setup(x => x.Applies(It.IsAny<IOrder>())).Returns(false);
            _services.AddSingleton<IBusinessRule>(nonApplicableRule.Object);

            var provider = _services.BuildServiceProvider();
            var businessRulesEngine = provider.GetService<IBusinessRulesEngine>();
            businessRulesEngine.Run(order.Object);
            applicableRule.Verify(x => x.Applies(order.Object), Times.Once);
            applicableRule.Verify(x => x.Apply(order.Object), Times.Once);
            nonApplicableRule.Verify(x => x.Applies(order.Object), Times.Once);
            nonApplicableRule.Verify(x => x.Apply(order.Object), Times.Never);

        }
    }
}
