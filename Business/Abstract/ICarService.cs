using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface ICarService
    {
        IDataResult< List<Car>>GetCarsByBrandId(int brandId);
        
        IDataResult<  List<Car>> GetCarsByColorId(int colorId);
        IDataResult< List<Car>>GetAll();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetById(int id);

    }
}
