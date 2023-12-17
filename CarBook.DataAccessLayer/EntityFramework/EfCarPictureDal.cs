using CarBook.DataAccessLayer.Abstract;
using CarBook.DataAccessLayer.Concrete;
using CarBook.DataAccessLayer.Repositories;
using CarBook.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.EntityFramework
{
    public class EfCarPictureDal : GenericRepository<CarPicture>, ICarPictureDal
    {
        public List<CarPicture> GetPicturesByCarId(int carId)
        {
            using CarBookContext context = new CarBookContext();    
            var values = context.CarPictures.Include(x=>x.Car).Where(x=>x.Car.CarID == carId).ToList();
            return values;

        }
    }
}
