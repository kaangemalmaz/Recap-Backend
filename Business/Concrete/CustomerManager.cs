using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICustomerDal.Get")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.MusteriEklendi);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICustomerDal.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.MusteriSilindi);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Customer> Get(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(i => i.Id == id));
        }

        public IDataResult<Customer> Get(string email)
        {
            throw new NotImplementedException();
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<FindeksListDto> GetFindeksInfo(string email)
        {
           return new SuccessDataResult<FindeksListDto>(_customerDal.GetFindeksInfo(email));
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICustomerDal.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.MusteriGuncellendi);
        }


        //private IResult CheckFindeksInfo(string email, int carId)
        //{
        //    var result = _customerDal.GetFindeksInfo(email, carId);
        //    if (result.CstmrFindeks < result.CarFindeks)
        //    {
        //        return new ErrorResult(Messages.FindeksIsNotEnough);
        //    }
        //    return new SuccessResult();
        //}
    }
}
