using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _ıRentalDal;
        IFindeksService _findeksService;

        public RentalManager(IRentalDal ıRentalDal, IFindeksService findeksService)
        {
            _ıRentalDal = ıRentalDal;
            _findeksService = findeksService;
        }
        //[SecuredOperation("rental.add,user")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(ChechkIfReturnDate(rental),_findeksService.CheckIfFindeksNo(rental.CustomerId,rental.CarId));
            if (result==null)
            {
                _ıRentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(result.Message);
        }

        public IResult Delete(Rental rental)
        {
            _ıRentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_ıRentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_ıRentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_ıRentalDal.GetRentalDetail(),Messages.Listed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _ıRentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
        public IResult ChechkIfReturnDate(Rental rental)
        {
           var rentals= _ıRentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var rent in rentals)
            {
                if (rent.ReturnDate >= rental.RentDate)
                {
                    return new ErrorResult(Messages.Alreadyrentals);
                }
            }
            return new SuccessResult();
        }
    }
}
