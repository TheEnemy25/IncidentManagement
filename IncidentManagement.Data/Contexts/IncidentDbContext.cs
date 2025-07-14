using IncidentManagement.Data.Entities;
using IncidentManagement.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Data.Contexts
{
    public sealed class IncidentDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public IncidentDbContext(DbContextOptions<IncidentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
        }
    }
}
