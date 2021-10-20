using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> Get(int id);
        IDataResult<Customer> Get(string email);
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);


        IDataResult<FindeksListDto> GetFindeksInfo(string email);
    }
}
