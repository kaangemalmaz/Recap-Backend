using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {

        List<CarListDto> GetCarList();


        List<CarListDto> GetCarDetails();
        CarListDto GetCarDetailsByCarId(int id);

        void UpdateDto(CarListDto carListDto);

        List<CarListDto> GetCarListWithBrandAndColorName();
        List<CarListDto> GetCarsByFilters(int colorId, int brandId);

        List<CarListDto> GetCarsByFilter(Expression<Func<CarListDto, bool>> filter = null);

    }
}
