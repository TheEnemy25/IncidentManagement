using FluentValidation;
using IncidentManagement.Domain.Dtos.Contact;

namespace IncidentManagement.Domain.Validators.Contact
{
    public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactDtoValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email must be valid")
                .MaximumLength(100)
                .WithMessage("Email must not exceed 50 characters.");

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

            RuleFor(c => c.AccountId)
                .NotEmpty()
                .WithMessage("AccountId is required");
        }
    }
}