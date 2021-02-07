namespace RulesEngine
{
    public class Order : IOrder
    {
        public bool ContainsPhysicalProduct => true;

        public bool ContainsBook => true;
    }
}
