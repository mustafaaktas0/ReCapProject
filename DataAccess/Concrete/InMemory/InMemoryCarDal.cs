using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>() { 
            new Car{CarId =1,BrandId =1,ColorId=1, DailyPrice=150,ModelYear=2014,Description="az yakar çok kacar"},
            new Car{CarId =2,BrandId =2,ColorId=1, DailyPrice=150,ModelYear=2014,Description="otoban faresi"}

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public List<CarDetailDto> carDetail()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car deletedCar = _cars.SingleOrDefault(c=>c.CarId ==car.CarId);
            _cars.Remove(deletedCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            Car getById = _cars.Find(c => c.CarId == carId);

            return getById;
        }

        public void Update(Car car)
        {
            Car updatedCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.ModelYear = car.ModelYear; 
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.Description = car.Description;
        }
    }
}
