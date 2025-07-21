using FluentValidation;
using IncidentManagement.Domain.Dtos.Account;

namespace IncidentManagement.Domain.Validators.Account
{
    public class DeleteAccountDtoValidator : AbstractValidator<DeleteAccountDto>
    {
        public DeleteAccountDtoValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("Account ID is required.");
        }
    }
}
