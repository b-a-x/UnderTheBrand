using UnderTheBrand.Domain.Core.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Base
{
    /// <summary>
    /// Базовый класс
    /// </summary>
    public class DomainObject : IDomainObject
    {
        protected DomainObject() { }

        /// <summary>
        /// Индификатор
        /// </summary>
        public string Id { get; set; }
    }
}