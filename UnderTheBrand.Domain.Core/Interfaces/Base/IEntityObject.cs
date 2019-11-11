using System;

namespace UnderTheBrand.Domain.Core.Interfaces.Base
{
    public interface IEntityObject
    {
        /// <summary>
        /// Индификатор
        /// </summary>
        Guid Id { get; }
    }
}