﻿using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.ViewComponents.UILayout
{
    public class _FooterComponentLayoutPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
