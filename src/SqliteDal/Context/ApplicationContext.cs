using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Model.Entities;
using UnderTheBrand.Infrastructure.SqliteDal.Configurations;

namespace UnderTheBrand.Infrastructure.SqliteDal.Context
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