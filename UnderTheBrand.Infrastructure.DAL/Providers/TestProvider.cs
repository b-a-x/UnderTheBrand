using UnderTheBrand.Domain.Core;
using UnderTheBrand.Domain.Interfaces.Providers;

namespace UnderTheBrand.Infrastructure.DAL.Providers
{
    public class TestProvider : DomainObjectProvider<Test>, ITestProvider
    {
        protected TestProvider() { }
    }
}
