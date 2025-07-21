using FluentValidation;
using IncidentManagement.Domain.Dtos.Incident;

namespace IncidentManagement.Domain.Validators.Incident
{
    public class DeleteIncidentDtoValidator : AbstractValidator<DeleteIncidentDto>
    {
        public DeleteIncidentDtoValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
