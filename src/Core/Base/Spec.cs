using System;
using System.Linq.Expressions;

namespace UnderTheBrand.Domain.Core.Base
{
    public class Spec<T>
    {
        public readonly Expression<Func<T, bool>> Expression;

        public static bool operator false(Spec<T> _) => false;

        public static bool operator true(Spec<T> _) => false;

        public static implicit operator Expression<Func<T, bool>>(Spec<T> spec)
            => spec.Expression;

        public static implicit operator Spec<T>(Expression<Func<T, bool>> expression)
            => new Spec<T>(expression);

        public Spec(Expression<Func<T, bool>> expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        //TODO: Подумать как реализовать
        /*
        public static Spec<T> operator &(Spec<T> spec1, Spec<T> spec2)
            => new Spec<T>(spec1.Expression.And(spec2.Expression));

        public static Spec<T> operator |(Spec<T> spec1, Spec<T> spec2)
            => new Spec<T>(spec1.Expression.Or(spec2.Expression));

        public static Spec<T> operator !(Spec<T> spec)
            => new Spec<T>(spec.Expression.Not());
        */
    }
}