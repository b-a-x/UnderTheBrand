using UnderTheBrand.Domain.Core.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Factory
{
    public abstract class Creator<T> where T : IHasId
    {
        public abstract T Create();
    }
}
