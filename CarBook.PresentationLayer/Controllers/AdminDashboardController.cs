using CarBook.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ICarService _carService;
        private readonly IPriceService _priceService;
        private readonly ICarStatusService _carStatusService;

        public AdminDashboardController(ICarService carSErvice, IPriceService priceService, ICarStatusService carStatusService)
        {
            _carService = carSErvice;
            _priceService = priceService;
            _carStatusService = carStatusService;
        }

        public IActionResult Index()
        {
            int carCount = _carService.TGetAll().Count;
            ViewBag.CarCount = carCount;

            decimal avaregePrice = _priceService.TGetAll().Average(x=>x.PriceValue);
            ViewBag.CarPrice = Math.Round(avaregePrice,2);

            int cars = _carService.TGetAll().Where(x=>x.CarStatusID== 6).Count();
            ViewBag.Cars = cars;

            int kunde = _carService.TGetAll().Where(x => x.CarStatusID == 1).Count();
            ViewBag.Kunde = kunde;

            return View();
        }
    }
}
