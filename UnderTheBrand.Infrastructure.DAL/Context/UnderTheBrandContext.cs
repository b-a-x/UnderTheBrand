using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Entity.Entities;
using UnderTheBrand.Infrastructure.Dal.Configurations;

namespace UnderTheBrand.Infrastructure.Dal.Context
{
    public sealed class UnderTheBrandContext : DbContext
    {
        public UnderTheBrandContext(DbContextOptions<UnderTheBrandContext> options)
            : base(options)
        {
            // TODO: Миграция?
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Person> Persons { get; set; }
    }
}
