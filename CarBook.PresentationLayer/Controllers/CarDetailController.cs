using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.PresentationLayer.Controllers
{
    public class CarDetailController : Controller
    {
        private readonly ICarDetailService _carDetailService;
        private readonly ICarService _carService;
        private readonly UserManager<AppUser> _userManager;

        public CarDetailController(ICarDetailService carDetailService, ICarService carService, UserManager<AppUser> userManager)
        {
            _carDetailService = carDetailService;
            _carService = carService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _carDetailService.GetCarDetailListWithInfo();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCarDetails()
        {
            List<SelectListItem> carList = (from x in _carService.TGetAllCarsWithBrands()
                                            select new SelectListItem
                                            {
                                                Text = $"{x.Brand.BrandName} {x.Model}",
                                                Value = x.CarID.ToString(),
                                            }).ToList();
            ViewBag.CarList = carList;

            List<SelectListItem> userList = (from x in _userManager.Users
                                             select new SelectListItem
                                             {
                                                 Text = $"{x.Name} {x.Surname}",
                                                 Value = x.Id.ToString(),
                                             }).ToList();
            ViewBag.UserList = userList;
            return View();
        }
        [HttpPost]
        public IActionResult AddCarDetails(CarDetail carDetail)
        {
            carDetail.CreatedDate = DateTime.Now;   
            _carDetailService.TInsert(carDetail);
            return RedirectToAction("Index");   
        }

        public IActionResult DeleteCarDetail(int id)
        {
            var carDetailToDelete = _carDetailService.TGetByID(id);
            _carDetailService.TDelete(carDetailToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCarDetail(int id)
        {
            List<SelectListItem> carList = (from x in _carService.TGetAllCarsWithBrands()
                                            select new SelectListItem
                                            {
                                                Text = $"{x.Brand.BrandName} {x.Model}",
                                                Value = x.CarID.ToString(),
                                            }).ToList();
            ViewBag.CarList = carList;

            List<SelectListItem> userList = (from x in _userManager.Users
                                             select new SelectListItem
                                             {
                                                 Text = $"{x.Name} {x.Surname}",
                                                 Value = x.Id.ToString(),
                                             }).ToList();
            ViewBag.UserList = userList;
            var value = _carDetailService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCarDetail(CarDetail carDetail)
        {
            _carDetailService.TUpdate(carDetail);
            return RedirectToAction("Index");
        }
    }
}
