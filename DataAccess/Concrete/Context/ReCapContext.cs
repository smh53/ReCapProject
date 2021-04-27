
using Entities.Brand;
using Entities.Car;
using Entities.Color;
using Entities.Customer;
using Entities.Rental;
using Core.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Context
{
  public  class ReCapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=SEMIHTAVUKCU\SQLEXPRESS;Database=RECAP_DEV;User Id=sa;Password=123456;");
            
        }
      
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
     

    }
}
