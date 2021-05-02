using Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.IdIcao).NotEmpty().WithMessage("ID ICAO is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
        }
    }
}
