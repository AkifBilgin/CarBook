using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.ViewComponents.AdminLayoutComponents
{
    public class _LeftSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
