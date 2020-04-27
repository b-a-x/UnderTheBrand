using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Model.Entities;
using UnderTheBrand.Infrastructure.Dal.Configurations;

namespace UnderTheBrand.Infrastructure.Dal.Context
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
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
