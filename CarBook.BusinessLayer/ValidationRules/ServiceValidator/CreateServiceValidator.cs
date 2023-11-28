using CarBook.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.BusinessLayer.ValidationRules.ServiceValidator
{
    public class CreateServiceValidator : AbstractValidator<Service>
    {
        public CreateServiceValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Bitte einen Titel eingeben");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bitte eine Beschreibung hinzufügen");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Bitte einen Icon eingeben");
            RuleFor(x => x.Title).MinimumLength(3).MaximumLength(30);
            RuleFor(x=>x.Description).MinimumLength(10).MaximumLength(250);
        }
    }
}
