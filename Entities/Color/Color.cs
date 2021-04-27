using Core.Entities;
using System.Collections.Generic;

namespace Entities.Color
{
    public class Color : IEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car.Car> Cars { get; set; }
    }
}