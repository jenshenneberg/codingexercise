using System.Collections.Generic;
using System.Linq;

namespace RulesEngine.BusinessRuleEngine
{
    internal class BusinessRulesEngine : IBusinessRulesEngine
    {
        private readonly IEnumerable<IBusinessRule> _businessRules;

        public BusinessRulesEngine(IEnumerable<IBusinessRule> businessRules)
        {
            _businessRules = businessRules;
        }

        public void Run(IOrder order)
        {
            var applicableBusinessRules = _businessRules.Where(x => x.Applies(order));
            foreach (var rule in applicableBusinessRules)
            {
                rule.Apply(order);
            }
        }
    }
}
