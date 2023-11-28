using CarBook.BusinessLayer.Abstract;
using CarBook.BusinessLayer.ValidationRules.ServiceValidator;
using CarBook.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.TGetAll();
            return View(values);
        }

        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            CreateServiceValidator validationRules = new CreateServiceValidator();
            ValidationResult result = validationRules.Validate(service);
            if (result.IsValid)
            {
                _serviceService.TInsert(service);
                return RedirectToAction("ServiceList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
            return View();
        }
        public IActionResult DeleteService(int id)
        {
            var serviceToDelete = _serviceService.TGetByID(id);
            _serviceService.TDelete(serviceToDelete);
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = _serviceService.TGetByID(id);
            return View(value); 
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return RedirectToAction("ServiceList");
        }
    }
}
