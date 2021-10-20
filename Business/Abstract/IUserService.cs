using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> Get(int id);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user, string password);

        IResult UpdateUser(UserForUpdate userForUpdate);

        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

    }
}
