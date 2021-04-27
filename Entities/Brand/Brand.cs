using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Brand
{
   public class Brand : IEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Car.Car> Cars { get; set; }
    }
}
