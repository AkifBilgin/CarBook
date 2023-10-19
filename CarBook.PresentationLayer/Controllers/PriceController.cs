using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.PresentationLayer.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceService _priceService;
        private readonly ICarService _carService;
        public PriceController(IPriceService priceService, ICarService carService)
        {
            _priceService = priceService;
            _carService = carService;
        }

        public IActionResult Index()
        {
           var values =  _priceService.TGetPricesWithCars();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreatePrice()
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString(),
                                           }).ToList();
            ViewBag.car = values;   
            return View();
        }
        [HttpPost]
        public IActionResult CreatePrice(Price price) 
        { 
            _priceService.TInsert(price);
            return RedirectToAction("Index");   
        }

        public IActionResult DeletePrice(int id)
        {
            var values = _priceService.TGetByID(id);
            _priceService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdatePrice(int id) 
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString(),
                                           }).ToList();
            ViewBag.car = values;
            var value = _priceService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdatePrice(Price price)
        {
            _priceService.TUpdate(price);
            return RedirectToAction("Index");
        }


    }
}
