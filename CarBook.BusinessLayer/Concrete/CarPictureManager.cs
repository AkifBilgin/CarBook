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
    public class CarPictureManager : ICarPictureService
    {
        private readonly ICarPictureDal _carPictureDal;

        public CarPictureManager(ICarPictureDal carPictureDal)
        {
            _carPictureDal = carPictureDal;
        }

        public List<CarPicture> GetPicturesByCarId(int carId)
        {
            return _carPictureDal.GetPicturesByCarId(carId);
        }

        public void TDelete(CarPicture entity)
        {
            _carPictureDal.Delete(entity);
        }

        public List<CarPicture> TGetAll()
        {
            return _carPictureDal.GetAll();
        }

        public CarPicture TGetByID(int id)
        {
            return _carPictureDal.GetByID(id);
        }

        public void TInsert(CarPicture entity)
        {
            _carPictureDal.Insert(entity);
        }

        public void TUpdate(CarPicture entity)
        {
            _carPictureDal.Update(entity);
        }
    }
}
