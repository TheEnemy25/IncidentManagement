using IncidentManagement.Data.Contexts;
using IncidentManagement.Data.Entities;
using IncidentManagement.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentManagement.Data
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IncidentDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Account>, BaseRepository<Account>>();
            services.AddScoped<IBaseRepository<Contact>, BaseRepository<Contact>>();
            services.AddScoped<IBaseRepository<Incident>, BaseRepository<Incident>>();

            return services;
        }
    }
}