﻿using System.Collections.Generic;
using System.Linq;

namespace UnderTheBrand.Domain.Core.Base
{
    public sealed class PagedResponse<T>
    {
        public PagedResponse(IEnumerable<T> items, long total, int totalPages)
        {
            Total = total;
            TotalPages = totalPages;
            Items = items.ToArray();
        }

        public long Total { get; }

        public int TotalPages { get; }

        public T[] Items { get; }
    }
}