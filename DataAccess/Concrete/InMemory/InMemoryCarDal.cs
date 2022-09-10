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
            _cars = new List<Car> 
            { 
               new Car{Id=1, BrandId=1,ColorId=2,ModelYear=1985,DailyPrice=500,Description="araba 1"},
               new Car{Id=2, BrandId=2,ColorId=1,ModelYear=1999,DailyPrice=600,Description="araba 2"},
               new Car{Id=3, BrandId=2,ColorId=2,ModelYear=1990,DailyPrice=450,Description="araba 3"},
               new Car{Id=4, BrandId=1,ColorId=1,ModelYear=1989,DailyPrice=300,Description="araba 4"},
               new Car{Id=5, BrandId=3,ColorId=2,ModelYear=2010,DailyPrice=1000,Description="araba 5"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deletedCar = _cars.SingleOrDefault(c=>c.Id==car.Id);
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

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarsDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updatedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.Description = car.Description;
            updatedCar.DailyPrice = car.DailyPrice;
        }
    }
}
