namespace RulesEngine.BusinessRules
{
    /// <summary>
    /// If the payment is for a physical product, generate a packing slip for shipping.
    /// </summary>
    class GeneratePackageSlip : IBusinessRule
    {
        private readonly IPackageSystem _packageSystem;

        public GeneratePackageSlip(IPackageSystem packageSystem)
        {
            _packageSystem = packageSystem;
        }

        public bool Applies(IOrder order)
        {
            return order.ContainsPhysicalProduct;
        }

        public void Apply(IOrder order)
        {
            _packageSystem.GeneratePackageSlip(order, PackageSlipType.Shipping);
        }
    }
}
