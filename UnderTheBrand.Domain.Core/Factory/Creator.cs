using UnderTheBrand.Domain.Core.Interfaces;

namespace UnderTheBrand.Domain.Core.Factory
{
    public abstract class Creator<T> where T : IHasId
    {
        public abstract T Create();
    }
}
