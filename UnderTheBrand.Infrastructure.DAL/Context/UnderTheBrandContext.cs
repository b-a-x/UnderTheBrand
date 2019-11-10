using UnderTheBrand.Infrastructure.DAL.Extensions.EntityTypeBuilder;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core;

namespace UnderTheBrand.Infrastructure.DAL.Context
{
    public sealed class UnderTheBrandContext : DbContext
    {
        private UnderTheBrandContext()
        {
        }

        public UnderTheBrandContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().BindTest();
        }

        public DbSet<Test> Tests { get; set; }
    }
}
