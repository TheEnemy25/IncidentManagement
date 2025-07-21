using IncidentManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentManagement.Data.EntityConfigurations
{
    internal sealed class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);

            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);

            builder.HasOne(c => c.Account)
                .WithMany(a => a.Contacts)
                .HasForeignKey(c => c.AccountId)
                .HasPrincipalKey(a => a.Id)
                .IsRequired();
        }
    }
}
