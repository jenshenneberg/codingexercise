namespace RulesEngine.BusinessRules
{
    /// <summary>
    /// If the payment is for a book, create a duplicate packing slip for the royalty department.
    /// </summary>
    public class GenerateRoyaltyPackageSlip : IBusinessRule
    {
        private readonly IPackageSystem _packageSystem;

        public GenerateRoyaltyPackageSlip(IPackageSystem packageSystem)
        {
            _packageSystem = packageSystem;
        }

        public bool Applies(IOrder order)
        {
            return order.ContainsBook;
        }

        public void Apply(IOrder order)
        {
            _packageSystem.GeneratePackageSlip(order, PackageSlipType.Royalty);
        }
    }
}
