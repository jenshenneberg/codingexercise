namespace RulesEngine.BusinessRuleEngine
{
    public interface IBusinessRulesEngine
    {
        void Run(IOrder order);
    }
}
