using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.PresentationLayer.Dtos.CarPictureDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarPicturesComponentsPartial : ViewComponent
    {
        private readonly ICarPictureService _carPictureService;
        private readonly IMapper _mapper;

        public _CarPicturesComponentsPartial(ICarPictureService carPictureService, IMapper mapper)
        {
            _carPictureService = carPictureService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {
            var pictures = _carPictureService.GetPicturesByCarId(id);
            var values = _mapper.Map<List<ResultCarPictureDto>>(pictures);
            return View(values);
        }
    }
}
