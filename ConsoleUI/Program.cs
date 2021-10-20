using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //CarDtoTest();
            //UserAdd();
            //CustomerAdd();

            RentalManager rent = new RentalManager(new EfRentalDal());
            //var falseresponse = rent.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = DateTime.Today});
            var trueresponse = rent.Add(new Rental { CarId = 3, CustomerId = 4, RentDate = DateTime.Now });
            //Console.WriteLine(falseresponse.Message + " " + falseresponse.Success);
            Console.WriteLine(trueresponse.Message + " " + trueresponse.Success);

        }

        private static void CustomerAdd()
        {
            CustomerManager customer = new CustomerManager(new EfCustomerDal());
            customer.Add(new Customer { CompanyName = "Tiktak", UserId = 1 });
            customer.Add(new Customer { CompanyName = "Halk", UserId = 2 });
            customer.Add(new Customer { CompanyName = "Vakıf", UserId = 3 });
            customer.Add(new Customer { CompanyName = "Ziraat", UserId = 4 });
            customer.Add(new Customer { CompanyName = "Ak", UserId = 5 });
            customer.Add(new Customer { CompanyName = "Albaraka", UserId = 6 });
            Console.WriteLine("==============================\n Eklenen Customer bilgileri \n ================");
            foreach (var c in customer.GetAll().Data)
            {
                Console.WriteLine(c.Id + " " + c.CompanyName + " " + c.UserId);
            }
        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Kaan",  LastName = "Ahmet", Email = "ahmetkaan@gmail.com" });
            userManager.Add(new User { FirstName = "Kaan1", LastName = "Ahmet", Email = "ahmetkaan1@gmail.com"});
            userManager.Add(new User { FirstName = "Kaan2", LastName = "Ahmet", Email = "ahmetkaan2@gmail.com"});
            userManager.Add(new User { FirstName = "Kaan3", LastName = "Ahmet", Email = "ahmetkaan3@gmail.com"});
            userManager.Add(new User { FirstName = "Kaan4", LastName = "Ahmet", Email = "ahmetkaan4@gmail.com"});
            userManager.Add(new User { FirstName = "Kaan5", LastName = "Ahmet", Email = "ahmetkaan5@gmail.com"});
            Console.WriteLine("User Eklendi");
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var cars = carManager.GetCarDetails();
            foreach (var c in cars.Data)
            {
                Console.WriteLine(c.Id + "/" + c.BrandName + "/" + c.ColorName + "/" + c.DailyPrice + "/" + c.CarName);
            }
            Console.WriteLine(cars.Success);
            Console.WriteLine(cars.Message);


        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            #region List
            //foreach (var c in colorManager.GetAll())
            //{
            //    Console.WriteLine(c.Id + " " + c.Name);
            //}
            #endregion

            #region Add
            //colorManager.Add(new Color { Name = "Bordo" });
            //Console.WriteLine("Color eklendi"); 
            #endregion


            #region Update
            // colorManager.Update(new Color { Id = 8, Name = "Tavşan ağzı" });
            //Console.WriteLine("Güncelleme işlemi yapıldı"); 
            #endregion

            #region Delete
            //colorManager.Delete(new Color { Id = 8 });
            //foreach (var c in colorManager.GetAll())
            //{
            //    Console.WriteLine(c.Id + " " + c.Name);
            //} 
            #endregion
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            #region List
            //foreach (var c in carManager.GetAll())
            //{
            //    Console.WriteLine(c.Description);
            //}
            #endregion

            #region Add
            //carManager.Add(new Car { ColorId=3, BrandId = 4, ModelYear = "1990", DailyPrice = 1000000, Description = "Şekil"});
            //Console.WriteLine("Car eklendi");
            #endregion


            #region Update
            // colorManager.Update(new Car { Id = 8, Name = "Mazda X20" });
            //Console.WriteLine("Güncelleme işlemi yapıldı"); 
            #endregion

            #region Delete
            //carManager.Delete(new Car { Id = 4 });
            //foreach (var c in carManager.GetAll())
            //{
            //    Console.WriteLine(c.Id + " " + c.Name);
            //} 
            #endregion


        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            #region List
            //foreach (var c in brandManager.GetAll())
            //{
            //    Console.WriteLine(c.Id + " " + c.Name);
            //}
            #endregion

            #region Add
            //brandManager.Add(new Brand { Name = "Kia" });
            //Console.WriteLine("Brand eklendi"); 
            #endregion


            #region Update
            // brandManager.Update(new Brand { Id = 8, Name = "Mazda X20" });
            //Console.WriteLine("Güncelleme işlemi yapıldı"); 
            #endregion

            #region Delete
            //brandManager.Delete(new Brand { Id = 4 });
            //foreach (var c in brandManager.GetAll())
            //{
            //    Console.WriteLine(c.Id + " " + c.Name);
            //} 
            #endregion
        }
    }
}
