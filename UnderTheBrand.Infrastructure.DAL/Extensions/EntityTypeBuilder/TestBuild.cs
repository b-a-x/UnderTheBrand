using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core;

namespace UnderTheBrand.Infrastructure.DAL.Extensions.EntityTypeBuilder
{
    internal static class TestBuild
    {
        private const string _tableName = nameof(Test) + "s";
        private const string _id = nameof(Test) + "Id";

        internal static void BindTest(this EntityTypeBuilder<Test> test)
        {
            test.ToTable(_tableName);

            test.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName(_id);
        }
    }
}
