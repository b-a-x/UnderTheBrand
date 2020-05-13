using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Model.Entities;
using UnderTheBrand.Infrastructure.SqliteDal.Configurations;
using UnderTheBrand.Presentation.Web.Server.Models;

namespace UnderTheBrand.Presentation.Web.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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