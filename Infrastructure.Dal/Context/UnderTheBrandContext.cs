using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Model.Entities;
using UnderTheBrand.Infrastructure.Dal.Configurations;

namespace UnderTheBrand.Infrastructure.Dal.Context
{
    public sealed class UnderTheBrandContext : DbContext
    {
        private readonly string _fileName = "Filename=Database_UnderTheBrand.db";
        internal UnderTheBrandContext()
        {
            // TODO: Миграция?
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_fileName);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            base.OnModelCreating(builder);
        }

        internal DbSet<Person> Persons { get; set; }
    }
}
