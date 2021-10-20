using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarListDto> GetCarsByFilter(Expression<Func<CarListDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new CarListDto
                             {
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 CarName = car.CarName,
                                 ColorId = color.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 Findeks = car.CarFindeks,
                                 Id = car.Id,
                                 ModelYear = car.ModelYear,
                                 EnginePower = car.EnginePower,
                                 FuelType = car.FuelType,
                                 GearType = car.GearType,
                                 CarImage = (from i in context.CarImages
                                             where (car.Id == i.CarId)
                                             select new CarImage{ CarId = i.CarId, Date = i.Date, Id = i.Id, ImagePath = i.ImagePath }).ToList()
                             };

                return filter != null ?
                    result.Where(filter).ToList()
                    : result.ToList();
            }
        }

        public List<CarListDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new CarListDto
                             {
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 CarName = car.CarName,
                                 ColorId = color.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 Findeks = car.CarFindeks,
                                 Id = car.Id,
                                 ModelYear = car.ModelYear,
                                 CarImage = (from i in context.CarImages
                                             where (car.Id == i.CarId)
                                             select new CarImage { CarId = i.CarId, Date = i.Date, Id = i.Id, ImagePath = i.ImagePath }).ToList(),
                                 EnginePower = car.EnginePower,
                                 FuelType = car.FuelType,
                                 GearType = car.GearType,
                             };

                return result.ToList();
            }
        }

        public CarListDto GetCarDetailsByCarId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             where car.Id == id
                             select new CarListDto
                             {
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 CarName = car.CarName,
                                 ColorId = color.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 Findeks = car.CarFindeks,
                                 Id = car.Id,
                                 ModelYear = car.ModelYear,
                                 CarImage = (from i in context.CarImages
                                             where (car.Id == i.CarId)
                                             select new CarImage { CarId = i.CarId, Date = i.Date, Id = i.Id, ImagePath = i.ImagePath }).ToList(),
                                 EnginePower = car.EnginePower,
                                 FuelType = car.FuelType,
                                 GearType = car.GearType,
                             };

                return result.FirstOrDefault();
            }
        }

        public List<CarListDto> GetCarListWithBrandAndColorName()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new CarListDto
                             {
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 CarName = car.CarName,
                                 ColorId = color.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 Findeks = car.CarFindeks,
                                 Id = car.Id,
                                 ModelYear = car.ModelYear,
                                 CarImage = (from i in context.CarImages
                                             where (car.Id == i.CarId)
                                             select new CarImage { CarId = i.CarId, Date = i.Date, Id = i.Id, ImagePath = i.ImagePath }).ToList(),
                                 EnginePower = car.EnginePower,
                                 FuelType = car.FuelType,
                                 GearType = car.GearType,
                             };

                return result.ToList();
            }
        }


        public List<CarListDto> GetCarsByFilters(int colorId, int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             where brand.Id == brandId && color.Id == colorId
                             select new CarListDto
                             {
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 CarName = car.CarName,
                                 ColorId = color.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 Findeks = car.CarFindeks,
                                 Id = car.Id,
                                 ModelYear = car.ModelYear,
                                 CarImage = (from i in context.CarImages
                                             where (car.Id == i.CarId)
                                             select new CarImage { CarId = i.CarId, Date = i.Date, Id = i.Id, ImagePath = i.ImagePath }).ToList(),
                                 EnginePower = car.EnginePower,
                                 FuelType = car.FuelType,
                                 GearType = car.GearType,
                             };

                return result.ToList();
            }
        }

        public List<CarListDto> GetCarList()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new CarListDto
                             {
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 CarName = car.CarName,
                                 ColorId = color.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 Findeks = car.CarFindeks,
                                 Id = car.Id,
                                 ModelYear = car.ModelYear,
                                 CarImage = (from i in context.CarImages
                                             where (car.Id == i.CarId)
                                             select new CarImage { CarId = i.CarId, Date = i.Date, Id = i.Id, ImagePath = i.ImagePath }).ToList(),
                                 EnginePower = car.EnginePower,
                                 FuelType = car.FuelType,
                                 GearType = car.GearType,

                             };
                             

                return result.ToList();
            }
        }

        public void UpdateDto(CarListDto carListDto)
        {
            using ReCapContext context = new ReCapContext();
            Car car = new Car()
            {
                BrandId = carListDto.BrandId,
                CarFindeks = carListDto.Findeks,
                CarName = carListDto.CarName,
                ColorId = carListDto.ColorId,
                DailyPrice = carListDto.DailyPrice,
                Description = carListDto.Description,
                EnginePower = carListDto.EnginePower,
                FuelType = carListDto.FuelType,
                GearType = carListDto.GearType,
                Id = carListDto.Id,
                ModelYear = carListDto.ModelYear
            };
            CarImage carImage = new CarImage()
            {
                CarId = carListDto.Id,
                ImagePath = carListDto.CarImage.ToString()
            };
            context.Set<Car>().Update(car);
            context.Set<CarImage>().Add(carImage);
            context.SaveChanges();
        }
    }
}
