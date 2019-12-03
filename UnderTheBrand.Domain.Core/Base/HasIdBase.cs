using System;
using UnderTheBrand.Domain.Core.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Base
{
    public abstract class HasIdBase<TKey> : IHasId<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }

        object IHasId.Id => Id;
    }
}