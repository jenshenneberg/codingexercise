using Microsoft.Extensions.DependencyInjection;
using Moq;
using RulesEngine.BusinessRules;
using RulesEngine.Membership;
using Xunit;

namespace RulesEngine.test
{
    public class BusinessRulesUnitTest
    {
        private readonly ServiceCollection _services;

        public BusinessRulesUnitTest()
        {
            _services = new ServiceCollection();
            _services.AddServices();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestGeneratePackageSlipApplies(bool apply)
        {
            var packageSystem = new Mock<IPackageSystem>();
            var order = new Mock<IOrder>();
            order.Setup(x => x.ContainsPhysicalProduct).Returns(apply);
            var rule = new GeneratePackageSlip(packageSystem.Object);
            Assert.Equal(apply, rule.Applies(order.Object));
        }

        [Fact]
        public void TestGeneratePackageSlipApply()
        {
            var packageSystem = new Mock<IPackageSystem>();
            var order = new Mock<IOrder>();
            var rule = new GeneratePackageSlip(packageSystem.Object);
            rule.Apply(order.Object);
            packageSystem.Verify(x => x.GeneratePackageSlip(order.Object, PackageSlipType.Shipping), Times.Once);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestGenerateRoyaltyPackageSlipApplies(bool apply)
        {
            var packageSystem = new Mock<IPackageSystem>();
            var order = new Mock<IOrder>();
            order.Setup(x => x.ContainsBook).Returns(apply);
            var rule = new GenerateRoyaltyPackageSlip(packageSystem.Object);
            Assert.Equal(apply, rule.Applies(order.Object));
        }

        [Fact]
        public void TestGenerateRoyaltyPackageSlipApply()
        {
            var packageSystem = new Mock<IPackageSystem>();
            var order = new Mock<IOrder>();
            var rule = new GenerateRoyaltyPackageSlip(packageSystem.Object);
            rule.Apply(order.Object);
            packageSystem.Verify(x => x.GeneratePackageSlip(order.Object, PackageSlipType.Royalty), Times.Once);
        }

        [Fact]
        public void TestActivateMembershipApply()
        {
            var membershipSystem = new Mock<IMembershipSystem>();
            var order = new Mock<IOrder>();
            var rule = new ActivateMembership(membershipSystem.Object);
            rule.Apply(order.Object);
            membershipSystem.Verify(x => x.ActivateMembership(order.Object), Times.Once);
        }

    }
}
