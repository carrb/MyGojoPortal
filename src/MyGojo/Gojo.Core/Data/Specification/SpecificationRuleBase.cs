using System;

namespace Gojo.Core.Data.Specification
{
    public abstract class SpecificationRuleBase<T>
    {
        private ISpecification<T> _rule;

        protected SpecificationRuleBase(ISpecification<T> rule)
        {
            Guard.Against<ArgumentNullException>(rule == null, "Expected a non-null and valid ISpecification<T> rule instance.");
            _rule = rule;
        }


        public bool IsSatisfied(T entity)
        {
            Guard.Against<ArgumentNullException>(entity == null, "Expected a non-null entity instance against which the rule can be evaluated.");
            return _rule.IsSatisfiedBy(entity);
        }

    }
}
