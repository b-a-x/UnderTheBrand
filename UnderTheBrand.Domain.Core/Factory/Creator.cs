using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core.Factory
{
    public abstract class Creator
    {
        public abstract HasIdBase Create();
    }
}
