using System;
using System.Linq.Expressions;

namespace Gojo.Core.Data.Specification
{
    public interface ISpecification<T>
    {
        // Get the expression that encapsulates the criteria of the specification
        Expression<Func<T, bool>> Predicate { get; }

        // Evaluate the specification against the entity of type T
        bool IsSatisfiedBy(T entity);
    }
}
