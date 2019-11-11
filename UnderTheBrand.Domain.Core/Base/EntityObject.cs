using System;
using UnderTheBrand.Domain.Core.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Base
{
    /// <summary>
    /// Базовый класс
    /// </summary>
    public class EntityObject : IEntityObject
    {
        protected EntityObject() { }

        public EntityObject(Guid guid)
        {
            Id = guid;
        }

        /// <summary>
        /// Индификатор
        /// </summary>
        public Guid Id { get; }
    }
}