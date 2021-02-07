using RulesEngine.Membership;

namespace RulesEngine.BusinessRules
{
    /// <summary>
    /// If the payment is for a membership, activate that membership.
    /// </summary>
    public class UpgradeMembership : IBusinessRule
    {
        private readonly IMembershipSystem _membershipSystem;

        public UpgradeMembership(IMembershipSystem membershipSystem)
        {
            _membershipSystem = membershipSystem;
        }

        public bool Applies(IOrder order)
        {
            return order.IsMembershipUpgrade;
        }

        public void Apply(IOrder order)
        {
            _membershipSystem.UpgradeMembership(order);
        }
    }
}
