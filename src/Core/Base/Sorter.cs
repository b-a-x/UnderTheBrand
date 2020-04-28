using System;
using System.Linq;
using System.Linq.Expressions;

namespace UnderTheBrand.Domain.Core.Base
{
    public class Sorter<T>
    {
        public readonly string PropertyName;
        public readonly LambdaExpression Expression;

        public Sorter(LambdaExpression expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public Sorter(string propertyName)
        {
            PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        }

        public static implicit operator LambdaExpression(Sorter<T> sorter)
            => sorter.Expression;
    }
}