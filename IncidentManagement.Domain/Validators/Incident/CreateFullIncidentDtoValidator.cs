using FluentValidation;
using IncidentManagement.Domain.Dtos.Incident;

namespace IncidentManagement.Domain.Validators.Incident
{
    public sealed class CreateFullIncidentDtoValidator : AbstractValidator<CreateFullIncidentDto>
    {
        public CreateFullIncidentDtoValidator()
        {
            RuleFor(i => i.AccountName)
               .NotEmpty()
               .WithMessage("Account name is required")
               .MaximumLength(50)
               .WithMessage("Account name must not exceed 50 characters.");

            RuleFor(i => i.ContactFirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MaximumLength(50)
                .WithMessage("First name must not exceed 50 characters.");

            RuleFor(i => i.ContactLastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .MaximumLength(50)
                .WithMessage("Last name must not exceed 50 characters.");

            RuleFor(i => i.ContactEmail)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format")
                .MaximumLength(100)
                .WithMessage("Email must not exceed 100 characters.");

            RuleFor(i => i.IncidentDescription)
                .NotEmpty()
                .WithMessage("Incident description is required")
                .MaximumLength(500)
                .WithMessage("Incident description must not exceed 500 characters.");
        }
    }
}