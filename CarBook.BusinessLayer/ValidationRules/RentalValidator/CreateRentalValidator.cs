using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.BusinessLayer.ValidationRules.RentalValidator
{
    public class CreateRentalValidator : AbstractValidator<Rental>
    {
        private readonly IRentalService _rentalService;

        public CreateRentalValidator(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public CreateRentalValidator()
        {
            RuleFor(x => x.From).LessThanOrEqualTo(x => x.Until).WithMessage("Startdatum darf nicht größer als Enddatum sein");
            RuleFor(x => x.Message).MaximumLength(250);
        }

  
    }
}
