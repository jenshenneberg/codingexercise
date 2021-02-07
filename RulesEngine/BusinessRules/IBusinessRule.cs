namespace RulesEngine
{
    public interface IBusinessRule
    {
        /// <summary>
        /// Indicates it the business rule applies to the order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>true if the business rule applies</returns>
        bool Applies(Order order);

        /// <summary>
        /// Apply the business rule to the order
        /// </summary>
        /// <param name="order"></param>
        void Apply(Order order);

    }
}
