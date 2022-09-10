using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            // BrandTest();
            // ColorTest();
            //UserTest();
            CustomerTest();
            //RentalTest();
        }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer { UserId=1,CompanyName="abc"});
            customerManager.Add(new Customer { UserId=1, CompanyName="aaa" });
            customerManager.Add(new Customer { UserId=1, CompanyName="bbb" });
            customerManager.Add(new Customer { UserId=1, CompanyName="ccc" });
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
            Console.WriteLine("------------------------");

            //customerManager.Update(new Customer { UserId=1,CompanyName="abc"  });
            //foreach (var customer in customerManager.GetAll().Data)
            //{
            //    Console.WriteLine(customer.CompanyName);
            //}
            //Console.WriteLine("------------------------");

            //customerManager.Delete(new Customer { UserId = 1, CompanyName = "abc" });
            //foreach (var customer in customerManager.GetAll().Data)
            //{
            //    Console.WriteLine(customer.CompanyName);
            //}
            //Console.WriteLine("------------------------");

            Console.WriteLine(customerManager.GetById(1).Data.CompanyName);

            foreach (var customer in customerManager.GetCustomerDetail().Data)
            {
                Console.WriteLine(customer.CompanyName+" "+customer.FirstName);
            }
           
        }
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental { CarId=1, CustomerId=1,RentDate=new DateTime(2000,02,22) , ReturnDate=new DateTime(2000,03,12)});
            rentalManager.Add(new Rental { CarId = 2, CustomerId = 1, RentDate = new DateTime(2013, 02, 22), ReturnDate = new DateTime(2013, 02, 25) });
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentDate);
            }
            Console.WriteLine("------------------------");

            rentalManager.Update(new Rental { Id = 2, CarId = 2, CustomerId = 1, RentDate = new DateTime(2000, 02, 22), ReturnDate = new DateTime(2000, 02, 22) });
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentDate);
            }
            Console.WriteLine("------------------------");

            rentalManager.Delete(new Rental { Id = 2, CarId = 2, CustomerId = 1, RentDate = new DateTime(2000,03,02), ReturnDate = new DateTime(2000,03,12) });
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentDate);
            }
            Console.WriteLine("------------------------");

            Console.WriteLine(rentalManager.GetById(1).Data.RentDate);
        }
        //private static void UserTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());

        //    userManager.Add(new User { FirstName="sueda", LastName="akın",Email="sue@gmail.com", Password="123" });
        //    userManager.Add(new User { FirstName = "elif", LastName = "akın", Email = "elif@gmail.com", Password = "1234" });
        //    foreach (var user in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(user.FirstName);
        //    }
        //    Console.WriteLine("------------------------");

        //    userManager.Update(new User { Id = 20, FirstName = "elif", LastName = "akın", Email = "elif@gmail.com", Password = "elif123" });
        //    foreach (var user in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(user.FirstName);
        //    }
        //    Console.WriteLine("------------------------");

        //    userManager.Delete(new User { Id=20 ,FirstName = "elif", LastName = "akın", Email = "elif@gmail.com", Password = "1234" });
        //    foreach (var user in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(user.FirstName);
        //    }
        //    Console.WriteLine("------------------------");

        //    Console.WriteLine(userManager.GetById(1).Data.FirstName);
        //}
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { Name = "siyah" });
            colorManager.Add(new Color { Name = "siyah" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine("------------------------");

            colorManager.Update(new Color { Id = 7, Name = "Siyah" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine("------------------------");

            colorManager.Delete(new Color { Id = 8, Name = "siyah" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine("------------------------");

            Console.WriteLine(colorManager.GetById(7).Data.Name);
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand { Name = "toyota" });
            brandManager.Add(new Brand { Name = "toyota" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine("------------------------");

            brandManager.Update(new Brand { Id = 2, Name = "Toyota" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine("------------------------");

            brandManager.Delete(new Brand { Id = 3, Name = "toyota" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine("------------------------");

            Console.WriteLine(brandManager.GetById(2).Data.Name);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { BrandId = 2, ColorId = 9, DailyPrice = 500, Description = "araba 2", ModelYear = 2001 });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("------------------------------");

            carManager.Update(new Car { Id = 2004, BrandId = 1, ColorId = 2, DailyPrice = 500, Description = "araba 2", ModelYear = 2001 });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("------------------------------");

            carManager.Delete(new Car { Id = 2004, BrandId = 6, ColorId = 2, DailyPrice = 500, Description = "araba 2", ModelYear = 2001 });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("------------------------------");

            Console.WriteLine(carManager.GetById(2003).Data.Description);

            //foreach (var car in carManager.GetCarsDetail().Data)
            //{
            //    Console.WriteLine(car.Description+" "+car.ColorName+" "+car.BrandName+" "+car.DailyPrice);
            //}
        }
    }
}
