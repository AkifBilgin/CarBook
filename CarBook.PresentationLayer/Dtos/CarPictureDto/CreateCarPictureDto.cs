﻿using CarBook.EntityLayer.Concrete;

namespace CarBook.PresentationLayer.Dtos.CarPictureDto
{
    public class CreateCarPictureDto
    {
  
        public string CarPicturUrl1 { get; set; }
        public string CarPicturUrl2 { get; set; }
        public string CarPicturUrl3 { get; set; }
        public int CarID { get; set; }
  
    }
}

