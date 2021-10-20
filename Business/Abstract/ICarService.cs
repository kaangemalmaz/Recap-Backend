using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        IResult UpdateDto(CarListDto carListDto);
        IDataResult<List<CarListDto>> GetCarDetails();
        IDataResult<CarListDto> GetCarDetailsByCarId(int id);
        IDataResult<List<CarListDto>> GetCarListWithBrandAndColorName();
        IDataResult<List<CarListDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarListDto>> GetCarsByColorId(int id);

        IDataResult<List<CarListDto>> GetCarsByFilters(int colorId, int brandId);

        IDataResult<List<CarListDto>> GetCarList();

    }
}
