using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.PresentationLayer.Dtos.CarPictureDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarDeatailCategoryComponentPartial : ViewComponent
    {
        private readonly ICarCategoryService _carCategoryService;
        public _CarDeatailCategoryComponentPartial(ICarCategoryService carCategoryService, IMapper mapper)
        {
            _carCategoryService = carCategoryService;

        }

        public IViewComponentResult Invoke()
        {
            var values = _carCategoryService.GetCarsGroupedByCategory();
            return View(values);
        }
    }
}
