﻿using System;
using System.Linq;
using System.Linq.Expressions;
using UnderTheBrand.Infrastructure.Core.Base;

namespace UnderTheBrand.Domain.Core.Base
{
    public class Sorter<T>
    {
        private readonly string _propertyName;
        private readonly LambdaExpression _expression;

        public Sorter(LambdaExpression expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public Sorter(string propertyName)
        {
            _propertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        }

        public static implicit operator LambdaExpression(Sorter<T> sorter)
            => sorter._expression;

        public IOrderedQueryable<T> Order(IQueryable<T> queryable)
            => _propertyName != null
                ? queryable.OrderBy(_propertyName)
                : (IOrderedQueryable<T>)((dynamic)queryable).OrderBy(_expression);
    }
}
