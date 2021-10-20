using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
                new Car{Id = 1 , BrandId = 1, ColorId = 1, DailyPrice = 150, ModelYear = "1900", Description = "Eski model mercedes"},
                new Car{Id = 2 , BrandId = 2, ColorId = 1, DailyPrice = 1500, ModelYear = "2000", Description = "Eski model mercedes"},
                new Car{Id = 3 , BrandId = 3, ColorId = 1, DailyPrice = 250, ModelYear = "2001", Description = "Eski model mercedes"},
                new Car{Id = 4 , BrandId = 4, ColorId = 1, DailyPrice = 350, ModelYear = "2002", Description = "Eski model mercedes"},
                new Car{Id = 5 , BrandId = 5, ColorId = 1, DailyPrice = 450, ModelYear = "2003", Description = "Eski model mercedes"},
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            var cardeleted = _car.SingleOrDefault(i => i.Id == car.Id);
            _car.Remove(cardeleted);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarListDto> GetAll(Expression<Func<CarListDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(i => i.BrandId == id).ToList();
        }

        public List<Car> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarListDto> GetCarList()
        {
            throw new NotImplementedException();
        }

        public List<CarListDto> GetCarListWithBrandAndColorName()
        {
            throw new NotImplementedException();
        }

        public List<CarListDto> GetCarsByBrandId(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarListDto> GetCarsByColorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarListDto> GetCarsByFilter(Expression<Func<CarListDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsByFilters(int colorId, int brandId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carupdated = _car.SingleOrDefault(i => i.Id == car.Id);
            carupdated.BrandId = car.BrandId;
            carupdated.ColorId = car.ColorId;
            carupdated.DailyPrice = car.DailyPrice;
            carupdated.Description = car.Description;
            carupdated.ModelYear = car.ModelYear;
        }
    }
}
