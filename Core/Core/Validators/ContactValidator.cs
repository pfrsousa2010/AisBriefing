using Core.Models;
using FluentValidation;

namespace Core.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("phone is required.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("invalid email");
            RuleFor(x => x.Group).NotEmpty().WithMessage("group is required.");
        }
    }
}
