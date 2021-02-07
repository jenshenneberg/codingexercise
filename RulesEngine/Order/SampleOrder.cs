namespace RulesEngine
{

    public class SampleOrder : IOrder
    {
        public bool ContainsPhysicalProduct => true;

        public bool ContainsBook => true;

        public bool ContainsMembership => true;

        public bool IsMembershipUpgrade => throw new System.NotImplementedException();
    }
}
