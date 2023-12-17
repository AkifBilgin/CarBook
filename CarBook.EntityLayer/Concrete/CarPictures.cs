using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.EntityLayer.Concrete
{
    public class CarPicture
    {
        public int CarPictureID { get; set; }
        public string CarPicturUrl1 { get; set; }
        public string CarPicturUrl2 { get; set; }
        public string CarPicturUrl3 { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
