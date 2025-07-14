using IncidentManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentManagement.Data.EntityConfigurations
{
    internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(a => a.Id);

            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(a => a.Name).IsRequired();

            builder.Property(a => a.IncidentName).IsRequired();

            builder.HasOne(a => a.Incident)
                .WithMany(i => i.Accounts)
                .HasForeignKey(a => a.IncidentName)
                .HasPrincipalKey(i => i.Name)
                .IsRequired();
        }
    }
}
