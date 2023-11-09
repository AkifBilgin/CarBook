using CarBook.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarDetailService _carDetailService;

        public CarController(ICarService carService, ICarDetailService carDetailService)
        {
            _carService = carService;
            _carDetailService = carDetailService;
        }

        public IActionResult Index()
        {
            var values = _carService.TGetAllCarsWithBrands();
            return View(values);
        }
        public IActionResult CarList()
        {
            ViewBag.title1 = "Fahrzeug Liste";
            ViewBag.title2 = "unsere Autos";
            var values = _carService.TGetAllCarsWithBrands();
            return View(values);
        }

        public IActionResult CarDetails(int id)
        {
            ViewBag.title1 = "Fahrzeug Details";
            ViewBag.title2 = "Details";
            ViewBag.id=id;
            var value = _carDetailService.TGetCarDetailByCarId(id);
            ViewBag.CarDetails = value.Description;
            return View();
        }
    }
}
