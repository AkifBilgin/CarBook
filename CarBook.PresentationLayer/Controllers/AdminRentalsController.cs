using CarBook.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class AdminRentalsController : Controller
    {
        private readonly IRentalService _rentalService;

        public AdminRentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public IActionResult Index()
        {
           var values = _rentalService.TGetAll();

            return View(values);
        }
    }
}
