using FluentValidation;
using IncidentManagement.Domain.Dtos.Contact;

namespace IncidentManagement.Domain.Validators.Contact
{
    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactDtoValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Contact ID is required");

            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MaximumLength(50)
                .WithMessage("First name must not exceed 50 characters.");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .MaximumLength(50)
                .WithMessage("Last name must not exceed 50 characters.");
        }
    }
}
