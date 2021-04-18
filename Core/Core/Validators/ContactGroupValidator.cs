using Core.Models;
using FluentValidation;

namespace Core.Validators
{
    public class ContactGroupValidator : AbstractValidator<ContactGroup>
    {
        public ContactGroupValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name is required.");
        }
    }
}
