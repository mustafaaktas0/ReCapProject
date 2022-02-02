using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            if (CheckCarReturn(rental.CarId))
            {
                _rentalDal.Add(rental);
                return new SuccessResult("eklendi ....");
            }
            else return new ErrorResult("arac daha teslim edilmemiş");
          
        }

        private bool CheckCarReturn(int carId)
        {
            var resultList = _rentalDal.GetAll(r => r.CarId == carId).ToList();
            if (resultList.Count <= 0)
            {
                return true;
            }

            var result = resultList.Last().ReturnDate != null ?   true :   false;

            return result == true ? true : false;
          
        }
    }
}
