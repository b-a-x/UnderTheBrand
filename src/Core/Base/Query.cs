using UnderTheBrand.Domain.Core.Interfaces;

namespace UnderTheBrand.Domain.Core.Base
{
    public class Query<T> : IFilter<T>
    {
        protected Query()
        {
        }

        public Query(Spec<T> spec, Sorter<T> sorter = null)
        {
            Spec = spec;
            Sorter = sorter;
        }

        public virtual Spec<T> Spec { get; }

        public virtual Sorter<T> Sorter { get; }
    }
}