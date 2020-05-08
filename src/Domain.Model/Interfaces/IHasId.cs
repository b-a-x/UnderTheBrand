﻿using System;

namespace UnderTheBrand.Domain.Model.Interfaces
{
    public interface IHasId
    {
        object Id { get; }
    }

    public interface IHasId<out TKey> : IHasId
        where TKey : IEquatable<TKey>
    {
        new TKey Id { get; }
    }
}