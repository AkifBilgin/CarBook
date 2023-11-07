using CarBook.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarDeatailCategoryComponentPartial : ViewComponent
    {
        private readonly ICarCategoryService _carCategoryService;

        public _CarDeatailCategoryComponentPartial(ICarCategoryService carCategoryService)
        {
            _carCategoryService = carCategoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values =  _carCategoryService.TGetAll();
            return View(values);
        }
    }
}
