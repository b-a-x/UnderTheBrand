using UnderTheBrand.Domain.Core;
using UnderTheBrand.Domain.Interfaces.Providers;
using UnderTheBrand.Infrastructure.DAL.Context;

namespace UnderTheBrand.Infrastructure.DAL.Providers
{
    public class TestProvider : DomainObjectProvider<Test>, ITestProvider
    {
        protected TestProvider() { }

        public TestProvider(UnderTheBrandContext context) : base(context)
        {
        }
    }
}
