using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);

        IDataResult<List<RentalListDto>> GetRentalList();

        IResult CheckRental(DateTime rentDate, DateTime returnDate, int carId);

        IResult UpdateActiveFlag(int userId, int carId);
    }
}
