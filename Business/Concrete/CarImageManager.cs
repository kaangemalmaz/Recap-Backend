using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot"; //yol verilir.
        private static string _folderName = "\\images\\"; // oradaki images klasörü olduğu söylenir.
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        //[TransactionScopeAspect]
        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {

            IResult result = BusinessRules.Run(ControlCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Upload(formFile);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(i => i.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarSuccessDeleted);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<CarImage> Get(int id)
        {
            var image = _carImageDal.Get(i => i.Id == id);
            if (image == null)
            {
                return DefaultCarControl();
            }

            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarId == id));
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetCarImageById(int id)
        {
            var image = _carImageDal.Get(i => i.Id == id);
            if (image == null)
            {
                return DefaultCarControlList();
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == id));
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var image = _carImageDal.Get(i => i.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            var updatedfile = FileHelper.Update(formFile, image.ImagePath);
            if (!updatedfile.Success)
            {
                return new ErrorResult(Messages.CarUpdatedFail);
            }

            carImage.ImagePath = updatedfile.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        [CacheAspect]
        private Result ControlCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.ExceedCarImageCount);
            }
            return new SuccessResult();
        }



        private IDataResult<CarImage> DefaultCarControl()
        {
            return new SuccessDataResult<CarImage>(_currentDirectory + _folderName + "1.jpg");
        }

        private IDataResult<List<CarImage>> DefaultCarControlList()
        {
            return new SuccessDataResult<List<CarImage>>(_currentDirectory + _folderName + "1.jpg");
        }
    }
}
