namespace RulesEngine
{
    /// <summary>
    /// Sample order implementation
    /// The real order implementation will have (extension) methods to determine if the properties below are true or not
    /// For instance the "ContainsBook" property will evauate to true if one or more of the products on the order are books
    /// </summary>
    public class SampleOrder : IOrder
    {
        public bool ContainsPhysicalProduct { get; set; } = false;

        public bool ContainsBook { get; set; } = false;

        public bool ContainsMembership { get; set; } = false;

        public bool IsMembershipUpgrade { get; set; } = false;
    }
}
