using FluentValidation;
using IncidentManagement.Domain.Dtos.Incident;

namespace IncidentManagement.Domain.Validators.Incident
{
    public class UpdateIncidentDtoValidator : AbstractValidator<UpdateIncidentDto>
    {
        public UpdateIncidentDtoValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .WithMessage("Incident name is required")
                .MaximumLength(50)
                .WithMessage("Incident name must not exceed 50 characters.");

            RuleFor(i => i.Description)
                .NotEmpty()
                .WithMessage("Incident description is required")
                .MaximumLength(500)
                .WithMessage("Incident description must not exceed 500 characters.");
        }
    }
}
