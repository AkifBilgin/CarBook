using CarBook.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarDetailAboutAuthorComponentPartial : ViewComponent
    {
        private readonly ICarDetailService _carDetailService;

        public _CarDetailAboutAuthorComponentPartial(ICarDetailService carDetailService)
        {
            _carDetailService = carDetailService;
        }

        public IViewComponentResult Invoke(int id)
        {
           var value = _carDetailService.GetCarDetailWithAutor(id);
            return View(value);
        }
    }
}
