using IncidentManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentManagement.Data.EntityConfigurations
{
    internal sealed class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incidents");

            builder.HasKey(i => i.Name);
            builder.Property(i => i.Name).ValueGeneratedOnAdd();

            builder.Property(i => i.Description).IsRequired();
        }
    }
}
