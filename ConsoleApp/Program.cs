using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //  CarTest();


            //ColorTest();

            // ResultTest();

            //  UserAddTest();

            // RentalAddTest();

            //CustomerAddTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
           var result =  rentalManager.Add(new Rental { RentalId = 6, CarId = 1, UserId = 1, RentDate = DateTime.Now, ReturnDate = null });

            Console.WriteLine(result.Message);
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { CustomerId = 3, UserId = 3, CompanyName = " biraz pahalı" });
        }

       

        //private static void UserAddTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(new User { UserId = 1, FirstName = "Mustafa", LastName = "Aktaş", Email = "mustafa@gmail.com", Password = "12345" });
        //}

        private static void ResultTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Description);
                }
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(new Car { CarId = 3, BrandId = 2, ColorId = 2, ModelYear = 1999, DailyPrice = 50, Description = "tarihi eser" });
            foreach (var item in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}
