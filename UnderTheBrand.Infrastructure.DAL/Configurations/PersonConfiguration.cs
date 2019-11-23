using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnderTheBrand.Domain.Entity.Entities;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Infrastructure.DAL.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person) + "s");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever().IsRequired();

            builder.OwnsOne(p => p.Age, a => {
                a.Property(u => u.Value).HasColumnName(nameof(Age));
                a.Property(u => u.Value).HasColumnType("int");
                a.Property(u => u.Value).IsRequired();
            });

            builder.OwnsOne(b => b.PersonalName, pn => {
                pn.OwnsOne(p => p.FirstName, fn => {
                    fn.Property(x => x.Value).HasColumnName(nameof(PersonalName.FirstName));
                    fn.Property(x => x.Value).HasColumnType("nvarchar(100)");
                    fn.Property(x => x.Value).IsRequired();
                });

                pn.OwnsOne(p => p.LastName, ln => {
                    ln.Property(x => x.Value).HasColumnName(nameof(PersonalName.LastName));
                    ln.Property(x => x.Value).HasColumnType("nvarchar(100)");
                    ln.Property(x => x.Value).IsRequired();
                });
            });
        }
    }
}
