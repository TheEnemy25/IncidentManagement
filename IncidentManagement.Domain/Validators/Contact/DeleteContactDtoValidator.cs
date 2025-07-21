using FluentValidation;
using IncidentManagement.Domain.Dtos.Contact;

namespace IncidentManagement.Domain.Validators.Contact
{
    public class DeleteContactDtoValidator : AbstractValidator<DeleteContactDto>
    {
        public DeleteContactDtoValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Contact ID is required.");
        }
    }
}
