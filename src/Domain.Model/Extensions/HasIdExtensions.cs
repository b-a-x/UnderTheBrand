using System;
using UnderTheBrand.Domain.Model.Interfaces;

namespace UnderTheBrand.Domain.Model.Extensions
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