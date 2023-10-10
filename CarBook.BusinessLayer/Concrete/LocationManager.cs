using CarBook.BusinessLayer.Abstract;
using CarBook.DataAccessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.BusinessLayer.Concrete
{
    public class LocationManager : ILocationService
    {
        private readonly ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public void TDelete(Location entity)
        {
            _locationDal.Delete(entity);
        }

        public List<Location> TGetAll()
        {
           return _locationDal.GetAll();
        }

        public Location TGetByID(int id)
        {
            return _locationDal.GetByID(id);
        }

        public void TInsert(Location entity)
        {
            _locationDal.Insert(entity);
        }

        public void TUpdate(Location entity)
        {
            _locationDal.Update(entity);
        }
    }
}
