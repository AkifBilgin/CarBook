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
    public class HowItWorksStepManager : IHowItWorksStepService
    {
        private readonly IHowItWorksStepDal _howItWorkStepDal;

        public HowItWorksStepManager(IHowItWorksStepDal howItWorkStepDal)
        {
            _howItWorkStepDal = howItWorkStepDal;
        }

        public void TDelete(HowItWorksStep entity)
        {
            _howItWorkStepDal.Delete(entity);
        }

        public List<HowItWorksStep> TGetAll()
        {
            return _howItWorkStepDal.GetAll();
        }

        public HowItWorksStep TGetByID(int id)
        {
            return _howItWorkStepDal.GetByID(id);
        }

        public void TInsert(HowItWorksStep entity)
        {
            _howItWorkStepDal.Insert(entity);
        }
        public void TUpdate(HowItWorksStep entity)
        {
            _howItWorkStepDal.Update(entity);
        }
    }
}
