using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _ıCarDal;

        public CarManager(ICarDal ıCarDal)
        {
            _ıCarDal = ıCarDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
               _ıCarDal.Add(car);
                return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 50)
            {
                throw new Exception();
            }
            Add(car);
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _ıCarDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        [PerformanceAspect(1)]
        public IDataResult<List<Car>> GetAll()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Car>>( _ıCarDal.GetAll(),Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_ıCarDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_ıCarDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_ıCarDal.GetAll(c => c.ColorId == id));
        }
        public IDataResult<List<CarDetailDto>> GetCarsDetail(int Id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_ıCarDal.GetCarsDetail(c => c.Id == Id));
        }
        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _ıCarDal.GetCarsDetail(),Messages.DetailsListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _ıCarDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
