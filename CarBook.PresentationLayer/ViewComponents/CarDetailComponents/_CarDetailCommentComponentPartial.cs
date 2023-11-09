using CarBook.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarDetailCommentComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CarDetailCommentComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetCommentsByCarId(id);
            return View(values);
        }
    }
}
