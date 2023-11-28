using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
