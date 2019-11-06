using UnderTheBrand.Infrastructure.DAL.Extensions.EntityTypeBuilder;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core;

namespace UnderTheBrand.Infrastructure.DAL.DataBase
{
    public class UnderTheBrandContext : DbContext
    {
        public UnderTheBrandContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().BindTest();
        }

        public DbSet<Test> Tests { get; set; }
    }
}
