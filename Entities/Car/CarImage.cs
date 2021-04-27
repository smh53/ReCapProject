using Core.Entities;
using Entities.BASE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Car
{
  public class CarImage : AutoDateTime, IEntities
    {
        [Key]
        public int Id { get; set; }
      
        public int CarId { get; set; }
        public string ImageName { get; set; }
        public string  ImageType { get; set; }
        public string ImagePath { get; set; }

      

    }
}
