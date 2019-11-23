using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Entity.Entities;
using UnderTheBrand.Infrastructure.DAL.Configurations;

namespace UnderTheBrand.Infrastructure.DAL.Context
{
    public sealed class UnderTheBrandContext : DbContext
    {
        public UnderTheBrandContext(DbContextOptions<UnderTheBrandContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PersonConfiguration());
        }

        public DbSet<Person> Persons { get; set; }
    }
}
