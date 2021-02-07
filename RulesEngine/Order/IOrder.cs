namespace RulesEngine
{
    public interface IOrder
    {
        bool ContainsPhysicalProduct { get; }
        bool ContainsBook { get; }
        bool ContainsMembership { get; }
        bool IsMembershipUpgrade { get; }
    }
}
