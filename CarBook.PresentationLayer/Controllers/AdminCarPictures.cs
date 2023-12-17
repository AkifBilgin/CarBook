using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using CarBook.PresentationLayer.Dtos.CarPictureDto;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CarBook.PresentationLayer.Controllers
{

    public class AdminCarPictures : Controller
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly ICarPictureService _carPictureService;
        private readonly IConfiguration _configuration;

        public AdminCarPictures(ICarService carService, IMapper mapper, ICarPictureService carPictureService, IConfiguration configuration)
        {
            _carService = carService;
            _mapper = mapper;
            _carPictureService = carPictureService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> carid = (from x in _carService.TGetAllCarsWithBrands()
                                          select new SelectListItem()
                                          {
                                              Text = $"{x.Brand.BrandName} {x.Model}",
                                              Value = x.CarID.ToString()
                                          }).ToList();
            ViewBag.CarId = carid;
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateCarPictureDto carPictureDto, IFormFile image1, IFormFile image2, IFormFile image3)
        {
            Cloudinary cloudinary = new Cloudinary(new Account(_configuration["Cloudinary:CloudName"], _configuration["Cloudinary:ApiKey"], _configuration["Cloudinary:Api-Secret"]));

            // Upload image1
            using var stream1 = image1.OpenReadStream();
            var uploadParams1 = new ImageUploadParams()
            {
                File = new CloudinaryDotNet.FileDescription(image1.FileName, stream1),
            };
            var uploadResult1 = cloudinary.Upload(uploadParams1);
            carPictureDto.CarPicturUrl1 = uploadResult1.Url.ToString();

            // Upload image2
            using var stream2 = image2.OpenReadStream();
            var uploadParams2 = new ImageUploadParams()
            {
                File = new CloudinaryDotNet.FileDescription(image2.FileName, stream2),
            };
            var uploadResult2 = cloudinary.Upload(uploadParams2);
            carPictureDto.CarPicturUrl2 = uploadResult2.Url.ToString();

            // Upload image3
            using var stream3 = image3.OpenReadStream();
            var uploadParams3 = new ImageUploadParams()
            {
                File = new CloudinaryDotNet.FileDescription(image3.FileName, stream3),
            };
            var uploadResult3 = cloudinary.Upload(uploadParams3);
            carPictureDto.CarPicturUrl3 = uploadResult3.Url.ToString();
            var value = _mapper.Map<CarPicture>(carPictureDto);
            _carPictureService.TInsert(value);
            return View();
        }

    }
}
