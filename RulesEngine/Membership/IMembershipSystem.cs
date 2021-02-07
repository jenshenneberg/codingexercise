namespace RulesEngine.Membership
{
    public interface IMembershipSystem
    {
        void ActivateMembership(IOrder order);
        void UpgradeMembership(IOrder order);
    }
}
