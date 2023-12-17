using AutoMapper;
using CarBook.EntityLayer.Concrete;
using CarBook.PresentationLayer.Dtos.CarPictureDto;
using CarBook.PresentationLayer.Dtos.CommentDtos;
using CarBook.PresentationLayer.Dtos.ContactDto;
using CarBook.PresentationLayer.Dtos.HowItWorksDto;

namespace CarBook.PresentationLayer.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultCommentDto, Comment>().ReverseMap();
            CreateMap<CreateCommentDto, Comment>().ReverseMap();

            CreateMap<ResultHowItWorksDto, HowItWorksStep>().ReverseMap();
            CreateMap<CreateHowItWorksDto, HowItWorksStep>().ReverseMap();

            CreateMap<ResultCarPictureDto, CarPicture>().ReverseMap();
            CreateMap<CreateCarPictureDto, CarPicture>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();
        }
    }
}
