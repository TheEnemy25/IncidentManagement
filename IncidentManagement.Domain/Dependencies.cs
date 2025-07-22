using FluentValidation;
using FluentValidation.AspNetCore;
using IncidentManagement.Domain.Dtos.Account;
using IncidentManagement.Domain.Dtos.Contact;
using IncidentManagement.Domain.Dtos.Incident;
using IncidentManagement.Domain.MappingProfiles;
using IncidentManagement.Domain.Services.Abstractions;
using IncidentManagement.Domain.Services.Implementations;
using IncidentManagement.Domain.Validators.Account;
using IncidentManagement.Domain.Validators.Contact;
using IncidentManagement.Domain.Validators.Incident;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentManagement.Domain
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ContactMappingProfile>();
                cfg.AddProfile<AccountMappingProfile>();
                cfg.AddProfile<IncidentMappingProfile>();
            });

            return services;
        }

        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<CreateAccountDto>, CreateAccountDtoValidator>();
            services.AddScoped<IValidator<UpdateAccountDto>, UpdateAccountDtoValidator>();

            services.AddScoped<IValidator<CreateContactDto>, CreateContactDtoValidator>();
            services.AddScoped<IValidator<UpdateContactDto>, UpdateContactDtoValidator>();

            services.AddScoped<IValidator<CreateFullIncidentDto>, CreateFullIncidentDtoValidator>();
            services.AddScoped<IValidator<UpdateIncidentDto>, UpdateIncidentDtoValidator>();

            return services;
        }

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IIncidentService, IncidentService>();

            return services;
        }
    }
}