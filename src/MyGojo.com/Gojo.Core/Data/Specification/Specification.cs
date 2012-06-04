using System;
using System.Linq.Expressions;

namespace Gojo.Core.Data.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        private readonly Expression<Func<T, bool>> _predicate;
        private readonly Func<T, bool> _predicateCompiled;

        public Specification(Expression<Func<T, bool>> predicate)
        {
            Guard.Against<ArgumentNullException>(predicate == null, "Expected a non-null expression as a predicate for the specification.");
            _predicate = predicate;
            _predicateCompiled = predicate.Compile();
        }


        public Expression<Func<T, bool>> Predicate
        {
            get { return _predicate; }
        }

        public bool IsSatisfiedBy(T entity)
        {
            return _predicate.Compile().Invoke(entity);
        }



        // Operator overloads to support Composite Specification Pattern

        public static Specification<T> operator &(Specification<T> leftSide, Specification<T> rightSide)
        {
            var rightInvoke = Expression.Invoke(rightSide.Predicate, leftSide.Predicate.Parameters);
            var newExpression = Expression.MakeBinary(ExpressionType.AndAlso, leftSide.Predicate.Body, rightInvoke);

            return new Specification<T>(Expression.Lambda<Func<T, bool>>(newExpression, leftSide.Predicate.Parameters));
        }

        public static Specification<T> operator |(Specification<T> leftSide, Specification<T> rightSide)
        {
            var rightInvoke = Expression.Invoke(rightSide.Predicate, leftSide.Predicate.Parameters);
            var newExpression = Expression.MakeBinary(ExpressionType.OrElse, leftSide.Predicate.Body, rightInvoke);

            return new Specification<T>(Expression.Lambda<Func<T, bool>>(newExpression, leftSide.Predicate.Parameters));
        }

    }
}
