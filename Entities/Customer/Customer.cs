using Core.Entities;
using Core.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Customer
{
   public class Customer : IEntities
    {
       
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Rental.Rental> Rentals { get; set; }

    }
}
