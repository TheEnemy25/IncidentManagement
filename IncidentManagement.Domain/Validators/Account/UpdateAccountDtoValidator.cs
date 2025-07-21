using FluentValidation;
using IncidentManagement.Domain.Dtos.Account;

namespace IncidentManagement.Domain.Validators.Account
{
    public class UpdateAccountDtoValidator : AbstractValidator<UpdateAccountDto>
    {
        public UpdateAccountDtoValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("Account ID is required");

            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Account name is required")
                .MaximumLength(50)
                .WithMessage("Incident name must not exceed 50 characters.");
        }
    }
}