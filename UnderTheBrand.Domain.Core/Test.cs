using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core
{
    public class Test : DomainObject
    {
        public string Name { get; set; }
        protected Test() { }

        public Test(string name)
        {
            Name = name;
        }
    }
}
