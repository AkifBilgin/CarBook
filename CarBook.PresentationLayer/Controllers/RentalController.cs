using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.BusinessLayer.ValidationRules.RentalValidator;
using CarBook.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace CarBook.PresentationLayer.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public RentalController(IRentalService rentalService, IMapper mapper, ICarService carService)
        {
            _rentalService = rentalService;
            _mapper = mapper;
            _carService = carService;
        }
        [HttpGet]
        public IActionResult CreateRental()
        {

            return PartialView();
        }

        [HttpPost]
        public IActionResult CreateRental(Rental rental)
        {
            CreateRentalValidator validator = new CreateRentalValidator();
            ValidationResult result = validator.Validate(rental);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                TempData["ErrorMessages"] = errors;
                return RedirectToAction("CarList", "Car");
            }
            else
            {
                _rentalService.TInsert(rental);
                TempData["SuccessMessage"] = "Ihre Buchung wurde erfolgreich durchgeführt!";
                return RedirectToAction("CarList", "Car");
            }
        }

    }
}
