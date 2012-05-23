using System;
using System.Linq.Expressions;

namespace Gojo.Core.Extensions
{
    public static class LambdaExtensions
    {
        public static string GetPropertyName<TProperty>(this Expression<Func<TProperty>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;

                if (unaryExpression != null)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;

                    if (memberExpression == null)
                        throw new NotImplementedException();
                }
                else
                    throw new NotImplementedException();
            }

            var propertyName = memberExpression.Member.Name;
            return propertyName;
        }

        public static string GetPropertyName<T, TProperty>(this Expression<Func<T, TProperty>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;

                if (unaryExpression != null)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;

                    if (memberExpression == null)
                        throw new NotImplementedException();
                }
                else
                    throw new NotImplementedException();
            }

            var propertyName = memberExpression.Member.Name;
            return propertyName;
        }

        public static String PropertyToString<R>(this Expression<Func<R>> action)
        {
            MemberExpression ex = (MemberExpression)action.Body;
            return ex.Member.Name;
        }

        public static void CheckIsNotNull<R>(this Expression<Func<R>> action)
        {
            CheckIsNotNull(action, null);
        }

        public static void CheckIsNotNull<R>(this Expression<Func<R>> action, string message)
        {
            MemberExpression ex = (MemberExpression)action.Body;
            var memberName = ex.Member.Name;
            if (action.Compile()() == null)
            {
                throw new ArgumentNullException(memberName, message);
            }
        }
    }
}
