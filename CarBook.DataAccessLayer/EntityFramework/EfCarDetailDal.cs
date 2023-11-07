using CarBook.DataAccessLayer.Abstract;
using CarBook.DataAccessLayer.Concrete;
using CarBook.DataAccessLayer.Repositories;
using CarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.EntityFramework
{
    public class EfCarDetailDal : GenericRepository<CarDetail>, ICarDetailDal
    {
        public CarDetail GetCarDetailByCarId(int id)
        {
            using (CarBookContext context = new CarBookContext())
            {
                var values = context.CarDetails.Where(x=>x.CarID == id).FirstOrDefault();
                return values;
            }
        }
    }
}
