using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _ıCarImageDal;

        public CarImageManager(ICarImageDal ıCarImageDal)
        {
            _ıCarImageDal = ıCarImageDal;
        }

        [SecuredOperation("carImage.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileHelper.AddAsync(file);
            _ıCarImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _ıCarImageDal.Get(p => p.Id == carImage.Id).ImagePath;

            IResult result = BusinessRules.Run(
                FileHelper.DeleteAsync(oldpath));

            if (result != null)
            {
                return result;
            }

            _ıCarImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_ıCarImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            IDataResult<List<CarImage>> result = (IDataResult<List<CarImage>>)BusinessRules.Run(CheckIfCarImageExist(id));
            if (result != null)
            {
                return result;
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageExist(id).Data);
        }


        [CacheAspect]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_ıCarImageDal.Get(c => c.Id == id));
        }

       
        public IResult Update(IFormFile file,CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _ıCarImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.UpdateAsync(oldpath, file);
            carImage.Date = DateTime.Now;
            _ıCarImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }
        private IDataResult<List<CarImage>> CheckIfCarImageExist(int carId)
        {
            var result = _ıCarImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { CarId = carId, ImagePath = @"\Images\default.jpg", Date = DateTime.Now } });
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }
        private IResult CheckIfCarImageCount(int carId)
        {
            var result = _ıCarImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageExist);
            }
            return new SuccessResult();
        }
    }
}
