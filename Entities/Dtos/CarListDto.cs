using Core.Entities;
using Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Dtos
{
    public class CarListDto : IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public List<CarImage> CarImage { get; set; }
        public int Findeks { get; set; }
        public string GearType { get; set; }
        public string EnginePower { get; set; }
        public string FuelType { get; set; }
    }
}
