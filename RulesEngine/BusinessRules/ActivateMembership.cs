using RulesEngine.Membership;

namespace RulesEngine.BusinessRules
{
    /// <summary>
    /// If the payment is for a membership, activate that membership.
    /// </summary>
    public class ActivateMembership : IBusinessRule
    {
        private readonly IMembershipSystem _membershipSystem;

        public ActivateMembership(IMembershipSystem membershipSystem)
        {
            _membershipSystem = membershipSystem;
        }

        public bool Applies(IOrder order)
        {
            return order.ContainsMembership;
        }

        public void Apply(IOrder order)
        {
            _membershipSystem.ActivateMembership(order);
        }
    }
}
