using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.DTOs;
using Entities.Rental;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetAllRentalDetails()
        {
            using (var context = new ReCapContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join cu in context.Customers
                             on rental.CustomerId equals cu.CustomerId
                             join us in context.Users
                             on cu.CustomerId equals us.Id

                             select new RentalDetailsDto
                             {
                                 BrandName = brand.Name,
                                 CarId = car.Id,
                                 CustomerId = cu.CustomerId,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Id = rental.Id,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,

                             };

                return result.ToList();
                            
            }
        }
    }
}
