using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core.Interfaces
{
    public interface IFilter<T>
    {
        Spec<T> Spec { get; }
    }
}