﻿using Core.Entities;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public int CarFindeks { get; set; }
        public string CarName { get; set; }
        public string GearType { get; set; }
        public string EnginePower { get; set; }
        public string FuelType { get; set; }
    }
}
