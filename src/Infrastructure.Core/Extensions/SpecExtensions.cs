using System;
using System.Linq.Expressions;
using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Infrastructure.Core.Extensions
{
    public static class SpecExtensions
    {
        public static bool IsSatisfiedBy<T>(this Spec<T> spec, T obj) => spec.Expression.AsFunc()(obj);

        public static Spec<T> From<T>(this Spec<T> spec, Expression<Func<T, T>> mapFrom)
            => spec.Expression.From(mapFrom);
    }
}