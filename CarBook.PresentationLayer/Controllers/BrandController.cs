using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CarBook.PresentationLayer.Controllers
{
    public class BrandController : Controller
    {

        private readonly IBrandService _brandService;
        
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index(string name)
        {
            ViewBag.Controller = "Marken";
            ViewBag.Action = "Index";
            ViewData["CurrentFilter"] = name;
            var values = from x in _brandService.TGetAll() select x;
            if (!string.IsNullOrEmpty(name))
            {
                values = values.Where(x => x.BrandName.ToLower().Contains(name.ToLower()));
            }
            return View(values.ToList());

        }

        [HttpGet]
        public IActionResult AddBrand() 
        {
            ViewBag.Controller = "Marken";
            ViewBag.Action = "Neu Marke";
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            _brandService.TInsert(brand);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBrand(int id)
        {
            var value = _brandService.TGetByID(id);
            _brandService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public IActionResult UpdateBrand(int id) 
        {
            ViewBag.Controller = "Marken";
            ViewBag.Action = "Update Marke";
            var value = _brandService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateBrand(Brand brand)
        {
             _brandService.TUpdate(brand);
            return RedirectToAction("Index");
        }

        //public IActionResult SearchBrandByName(string name)
        //{
        //    ViewData["CurrentFilter"] = name;
        //    var values = from x in _brandService.TGetAll() select x;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        values = values.Where(x=>x.BrandName.Contains(name));
        //    }
        //    return View(values.ToList());
        //}
    }
}
