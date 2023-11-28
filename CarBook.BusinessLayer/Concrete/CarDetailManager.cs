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
    public class CarDetailManager : ICarDetailService
    {
        private readonly ICarDetailDal _carDetailDal;

        public CarDetailManager(ICarDetailDal carDetailDal)
        {
            _carDetailDal = carDetailDal;
        }

        public List<CarDetail> GetCarDetailListWithInfo()
        {
            return _carDetailDal.GetCarDetailListWithInfo();
        }

        public CarDetail GetCarDetailWithAutor(int id)
        {
            return _carDetailDal.GetCarDetailWithAutor(id);
        }

        public void TDelete(CarDetail entity)
        {
            _carDetailDal.Delete(entity);
        }

        public List<CarDetail> TGetAll()
        {
            return _carDetailDal.GetAll();
        }

        public CarDetail TGetByID(int id)
        {
            return _carDetailDal.GetByID(id);
        }

        public CarDetail TGetCarDetailByCarId(int id)
        {
           return _carDetailDal.GetCarDetailByCarId(id);
        }

        public void TInsert(CarDetail entity)
        {
            _carDetailDal.Insert(entity);
        }

        public void TUpdate(CarDetail entity)
        {
            _carDetailDal.Update(entity);
        }
    }
}
