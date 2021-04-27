using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Car
{
   public class Car : IEntities
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public ICollection<Rental.Rental> Rentals { get; set; }
        public ICollection<CarImage> CarImages { get; set; }
    }
}
