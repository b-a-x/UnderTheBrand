using System;
using UnderTheBrand.Domain.Core.Interfaces;

namespace UnderTheBrand.Domain.Core.Extensions
{
    public static class HasIdExtensions
    {
        public static bool IsNew<TKey>(this IHasId<TKey> obj)
            where TKey : IEquatable<TKey>
        {
            return obj.Id == null || obj.Id.Equals(other: default);
        }
    }
}