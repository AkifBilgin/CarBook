using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.BusinessLayer.ValidationRules.ContactValidator;
using CarBook.BusinessLayer.ValidationRules.ServiceValidator;
using CarBook.EntityLayer.Concrete;
using CarBook.PresentationLayer.Dtos.CommentDtos;
using CarBook.PresentationLayer.Dtos.ContactDto;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.title1 = "Kontakt";
            ViewBag.title2 = "Für etwaige Fragen ?";
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(CreateContactDto createContactDto)
        //{
        //    var value = _mapper.Map<Contact>(createContactDto);
        //    ContactValidator contactvalidator = new();
        //    ValidationResult result = contactvalidator.Validate(value);
        //    if(result.IsValid)
        //    {
        //        _contactService.TInsert(value);
        //        return RedirectToAction("Index");    
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //        return RedirectToAction("Index");
        //    }


        //}
        [HttpPost]
        public IActionResult Index(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            ContactValidator contactvalidator = new();
            ValidationResult result = contactvalidator.Validate(value);
            if (result.IsValid)
            {
                _contactService.TInsert(value);
                return Json(new { success = true });
            }
            else
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, errors = errors });
            }
        }

    }
}
