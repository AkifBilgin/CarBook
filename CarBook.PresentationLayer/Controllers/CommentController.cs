using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using CarBook.PresentationLayer.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            ViewBag.Controller = "Kommentare";
            ViewBag.Action = "Index";
            var comments = _commentService.GetAllCommentsWithCar();
            var values = _mapper.Map<List<ResultCommentDto>>(comments);

            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var commentToDelete = _commentService.TGetByID(id);
            _commentService.TDelete(commentToDelete);
            return RedirectToAction("Index");
        }
        public IActionResult MakeComment(CreateCommentDto createCommentDto) 
        {
            var id = TempData["id"];
            createCommentDto.CreatedDate = DateTime.Now;
            createCommentDto.CarID = (int)id;
            var value = _mapper.Map<Comment>(createCommentDto);
            _commentService.TInsert(value);
            return RedirectToAction("CarDetails", "Car", new { id = createCommentDto.CarID });
        }
    }
}
