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
    public class EfCarCategoryDal : GenericRepository<CarCategory>, ICarCategoryDal
    {
        public List<CarCategory> GetCarsGroupedByCategory()
        {
            using var context = new CarBookContext();
            return context.CarCategories.Include(c => c.Cars).ToList();
        }
    }
    
}
