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

        void UpdateActiveFlag(int userId, int carId);

        //bool CheckRental(DateTime rentDate, DateTime returnDate, int carId);
    }
}
