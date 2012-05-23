using System;
using System.Linq;
using System.Linq.Expressions;

namespace Gojo.Core.Data.Specification
{
    ///<summary>
    /// Extension methods for <see cref="ISpecification{T}"/>.
    ///</summary>
    public static class SpecificationExtensions
    {

        /// Retuns a new specification ADD-ing this one with the passed one.
        ///
        public static ISpecification<T> And<T>(this ISpecification<T> rightHand, ISpecification<T> leftHand)
        {
            var rightInvoke = Expression.Invoke(rightHand.Predicate, leftHand.Predicate.Parameters.Cast<Expression>());
            var newExpression = Expression.MakeBinary(ExpressionType.AndAlso, leftHand.Predicate.Body, rightInvoke);
            return new Specification<T>(Expression.Lambda<Func<T, bool>>(newExpression, leftHand.Predicate.Parameters));
        }


        /// Retuns a new specification OR-ing this one with the passed one.
        /// 
        public static ISpecification<T> Or<T>(this ISpecification<T> rightHand, ISpecification<T> leftHand)
        {
            var rightInvoke = Expression.Invoke(rightHand.Predicate, leftHand.Predicate.Parameters.Cast<Expression>());
            var newExpression = Expression.MakeBinary(ExpressionType.OrElse, leftHand.Predicate.Body, rightInvoke);
            return new Specification<T>(Expression.Lambda<Func<T, bool>>(newExpression, leftHand.Predicate.Parameters));
        }
    }
}