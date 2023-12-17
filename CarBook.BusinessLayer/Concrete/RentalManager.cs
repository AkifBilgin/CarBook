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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public void TDelete(Rental entity)
        {
            _rentalDal.Delete(entity);
        }

        public List<Rental> TGetAll()
        {
            return _rentalDal.GetAll();
        }

        public Rental TGetByID(int id)
        {
            return _rentalDal.GetByID(id);
        }

        public void TInsert(Rental entity)
        { 
            _rentalDal.Insert(entity);
        }

        public void TUpdate(Rental entity)
        {
            _rentalDal.Update(entity);
        }
    }
}
