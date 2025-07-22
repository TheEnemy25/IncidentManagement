using FluentValidation;
using IncidentManagement.Domain.Dtos.Account;

namespace IncidentManagement.Domain.Validators.Account
{
    public class CreateAccountDtoValidator : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountDtoValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Account full name is required.")
                .MaximumLength(50)
                .WithMessage("Account full name must not exceed 50 characters.");
        }
    }
}