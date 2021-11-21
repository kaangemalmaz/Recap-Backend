using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        //public bool CheckRental(DateTime rentDate, DateTime returnDate, int carId)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = context.Rentals.Where(i => i.ReturnDate != null && i.ReturnDate > rentDate && i.CarId == carId).FirstOrDefault();
        //        if (result != null)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}

        public List<RentalListDto> GetRentalList()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rental in context.Rentals
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             select new RentalListDto
                             {
                                 Id = rental.Id,
                                 CarName = brand.Name + " " + car.CarName,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 TotalPrice = Convert.ToDecimal(rental.ReturnDate.Value.Day - rental.RentDate.Day) * car.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
