using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalListDto> GetRentalList();

        //bool CheckRental(DateTime rentDate, DateTime returnDate, int carId);
    }
}
