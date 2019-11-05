using UnderTheBrand.Domain.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Base
{
    /// <summary>
    /// Базовый класс
    /// </summary>
    public class DomainObject : IDomainObject
    {
        /// <summary>
        /// Индификатор
        /// </summary>
        public string Id { get; set; }
    }
}