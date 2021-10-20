using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        

        [ValidationAspect(typeof(UserValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserDal.Get")]
        public IResult Add(User user)
        {

            //var context = new ValidationContext<Product>(product); //burada Context Product generic nesnesi için çalışacak ve parantez içindeki product metodun içinden gelmektedir.
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //    if (!result.IsValid)
            //    {
            //        throw new ValidationException(result.Errors);
            //}

            _userDal.Add(user);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserDal.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(i => i.Id == id));
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [PerformanceAspect(5)]
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(i => i.Email == email));
        }

        [PerformanceAspect(5)]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
            //return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserDal.Get")]
        public IResult Update(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var updatedUser = new User
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = user.Status
            };
            _userDal.Update(updatedUser);
            return new SuccessResult();
        }

        public IResult UpdateUser(UserForUpdate userForUpdate)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForUpdate.Password, out passwordHash, out passwordSalt);
            var updatedUser = new User
            {
                Email = userForUpdate.Email,
                FirstName = userForUpdate.FirstName,
                Id = userForUpdate.Id,
                LastName = userForUpdate.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = userForUpdate.Status
            };
            _userDal.Update(updatedUser);
            return new SuccessResult();
        }
    }
}
