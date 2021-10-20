using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            if (car.Description.Length > 2)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarAddedError);
            }

        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(i => i.Id == id));

        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //Burada iş kuralları işletilir tüm ifler tüm kontroller burada unutma 
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<CarListDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarListDto>>(_carDal.GetCarDetails(), "Araba detayları gönderilmiştir.");
        }

        public IDataResult<CarListDto> GetCarDetailsByCarId(int id)
        {
            return new SuccessDataResult<CarListDto>(_carDal.GetCarDetailsByCarId(id));
        }

       
        public IDataResult<List<CarListDto>> GetCarList()
        {
            return new SuccessDataResult<List<CarListDto>>(_carDal.GetCarList(),"Araba Listesi başarı ile yüklenmiştir.");
        }

        public IDataResult<List<CarListDto>> GetCarListWithBrandAndColorName()
        {
            return new SuccessDataResult<List<CarListDto>>(_carDal.GetCarListWithBrandAndColorName(), "Arabalar Listelenmiştir.");
        }

        [CacheAspect]
        public IDataResult<List<CarListDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarListDto>>(_carDal.GetCarsByFilter(i=>i.BrandId == id).ToList());
        }

        [CacheAspect]
        public IDataResult<List<CarListDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarListDto>>(_carDal.GetCarsByFilter(i=>i.ColorId == id).ToList());
        }

        public IDataResult<List<CarListDto>> GetCarsByFilters(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarListDto>>(_carDal.GetCarsByFilters(colorId, brandId));
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IResult UpdateDto(CarListDto carListDto)
        {
            //CarImage carImage = new CarImage(){CarId = carListDto.Id};
            //_carImageService.Add(carListDto.CarImage.First(), carImage);
            _carDal.UpdateDto(carListDto);
            return new SuccessResult();
        }
    }
}
