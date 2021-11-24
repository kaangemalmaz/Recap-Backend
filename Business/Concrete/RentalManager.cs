using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //[ValidationAspect(typeof(RentalValidator))]
        //[TransactionScopeAspect]
        //[CacheRemoveAspect("IRentalDal.Get")]
        public IResult Add(Rental rental)
        {
            var selected = _rentalDal.Get(i => i.CarId == rental.CarId);
            if (selected == null || (selected != null && !String.IsNullOrEmpty(selected.ReturnDate.ToString())))
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("Bu araba henüz teslim edilmemiştir.");
            }

        }

        public IResult CheckRental(DateTime rentDate, DateTime returnDate, int carId)
        {
            var selectedCar = _rentalDal.GetAll(i => i.CarId == carId);
            if (selectedCar != null)
            {
                var resultCanRent = selectedCar.Where(i => i.RentDate >= rentDate || returnDate <= i.ReturnDate).ToList();
                if (resultCanRent.Count > 0)
                {
                    return new ErrorResult();
                }

                return new SuccessResult();
                
            }
            return new ErrorResult();
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalDal.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(i => i.Id == id));
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalListDto>> GetRentalList()
        {
            return new SuccessDataResult<List<RentalListDto>>(_rentalDal.GetRentalList());
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalDal.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult UpdateActiveFlag(int userId, int carId)
        {
            _rentalDal.UpdateActiveFlag(userId, carId);
            return new SuccessResult();
        }
    }
}
