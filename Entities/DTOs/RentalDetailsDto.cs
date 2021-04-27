using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class RentalDetailsDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BrandName { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime RentDate { get; set; }

    }
}
