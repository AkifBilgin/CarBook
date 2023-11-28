using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.ViewComponents.AdminLayoutComponents
{
    public class _TopBarComponentPartial : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
