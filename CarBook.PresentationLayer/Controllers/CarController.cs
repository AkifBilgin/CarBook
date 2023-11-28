
using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CarBook.PresentationLayer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarDetailService _carDetailService;
        private readonly IBrandService _brandService;
        private readonly ICarCategoryService _carCategoryService;
        private readonly ICarStatusService _carStatusService;
        private readonly IConfiguration _configuration;


        public CarController(ICarService carService, ICarDetailService carDetailService, IBrandService brandService, ICarCategoryService carCategoryService, ICarStatusService carStatusService, IConfiguration configuration)
        {
            _carService = carService;
            _carDetailService = carDetailService;
            _brandService = brandService;
            _carCategoryService = carCategoryService;
            _carStatusService = carStatusService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.Controller = "Fuhrpark";
            ViewBag.Action = "Index";
            var values = _carService.TGetAllCarsWithBrands();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            ViewBag.Controller = "Fuhrpark";
            ViewBag.Action = "Neues Auto";
            List<SelectListItem> carCategory = (from x in _carCategoryService.TGetAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CarCategoryID.ToString()
                                                }).ToList();
            ViewBag.CarCategory = carCategory;

            List<SelectListItem> carBrand = (from x in _brandService.TGetAll()
                                             select new SelectListItem
                                             {
                                                 Text = x.BrandName,
                                                 Value = x.BrandID.ToString()
                                             }).ToList();
            ViewBag.CarBrand = carBrand;

            List<SelectListItem> carStatus = (from x in _carStatusService.TGetAll()
                                              select new SelectListItem
                                              {
                                                  Text = x.CarStatusName,
                                                  Value = x.CarStatusID.ToString()
                                              }).ToList();
            ViewBag.CarStatus = carStatus;
            return View();
        }
        [HttpPost]
        public IActionResult AddCar(Car car, IFormFile imageUrl)
        {
            Cloudinary cloudinary = new Cloudinary(new Account(_configuration["Cloudinary:CloudName"], _configuration["Cloudinary:ApiKey"], _configuration["Cloudinary:Api-Secret"]));
            using var stream = imageUrl.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new CloudinaryDotNet.FileDescription(imageUrl.FileName, stream),

            };
            var uploadResult = cloudinary.Upload(uploadParams);
            car.ImageUrl = uploadResult.Url.ToString();
            _carService.TInsert(car); 
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCar(int id)
        {
            var carToDelete = _carService.TGetByID(id);
            _carService.TDelete(carToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCar(int id)
        {
            ViewBag.Controller = "Fuhrpark";
            ViewBag.Action = "Update Auto";
            List<SelectListItem> carCategory = (from x in _carCategoryService.TGetAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CarCategoryID.ToString()
                                                }).ToList();
            ViewBag.CarCategory = carCategory;

            List<SelectListItem> carBrand = (from x in _brandService.TGetAll()
                                             select new SelectListItem
                                             {
                                                 Text = x.BrandName,
                                                 Value = x.BrandID.ToString()
                                             }).ToList();
            ViewBag.CarBrand = carBrand;

            List<SelectListItem> carStatus = (from x in _carStatusService.TGetAll()
                                              select new SelectListItem
                                              {
                                                  Text = x.CarStatusName,
                                                  Value = x.CarStatusID.ToString()
                                              }).ToList();
            ViewBag.CarStatus = carStatus;
            var carToUpdate = _carService.TGetByID(id);
            return View(carToUpdate);
        }

        [HttpPost]
        public IActionResult UpdateCar(Car car, IFormFile imageUrl)
        {
            Cloudinary cloudinary = new Cloudinary(new Account(_configuration["Cloudinary:CloudName"], _configuration["Cloudinary:ApiKey"], _configuration["Cloudinary:Api-Secret"]));
            using var stream = imageUrl.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new CloudinaryDotNet.FileDescription(imageUrl.FileName, stream),

            };
            var uploadResult = cloudinary.Upload(uploadParams);
            car.ImageUrl = uploadResult.Url.ToString();
            _carService.TUpdate(car);
            return RedirectToAction("Index");
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
            ViewBag.id = id;
            var value = _carDetailService.TGetCarDetailByCarId(id);
            ViewBag.CarDetails = value.Description;
            return View();
        }

        public IActionResult AdminCarDetails(int id)
        {
            var value = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).FirstOrDefault();
            ViewBag.Brand = value.Brand.BrandName;
            return PartialView(value);
        }
    }
}
