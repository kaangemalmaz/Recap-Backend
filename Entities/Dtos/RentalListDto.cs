using Core.Entities;
using System;

namespace Entities.Dtos
{
    public class RentalListDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
