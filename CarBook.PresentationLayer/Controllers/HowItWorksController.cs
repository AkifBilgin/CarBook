using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using CarBook.PresentationLayer.Dtos.HowItWorksDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class HowItWorksController : Controller
    {
        private readonly IHowItWorksStepService _stepService;
        private readonly IMapper _mapper;

        public HowItWorksController(IMapper mapper, IHowItWorksStepService stepService)
        {
            _mapper = mapper;
            _stepService = stepService;
        }

        public IActionResult Index()
        {
            ViewBag.Controller = "Schritte";
            ViewBag.Action = "Index";
            var howItWorks = _stepService.TGetAll();
            var values = _mapper.Map<List<ResultHowItWorksDto>>(howItWorks);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddHowItWorks()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddHowItWorks(CreateHowItWorksDto createHowItWorksDto)
        {
            var value = _mapper.Map<HowItWorksStep>(createHowItWorksDto);
            _stepService.TInsert(value);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteHowItWorks(int id)
        {
            var valueToDelete =  _stepService.TGetByID(id); 
            _stepService.TDelete(valueToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateHowItWorks(int id)
        {
            var value = _stepService.TGetByID(id);
            return PartialView(value);
        }
        [HttpPost]
        public IActionResult UpdateHowItWorks(ResultHowItWorksDto resultHowItWorksDto)
        {
            var value = _mapper.Map<HowItWorksStep>(resultHowItWorksDto);
            _stepService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
