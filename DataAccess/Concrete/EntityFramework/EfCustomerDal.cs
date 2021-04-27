using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Customer;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetAllCustomerDetails()
        {
            using (var context = new ReCapContext())
            {
                var result = from cu in context.Customers
                             join us in context.Users on
                             cu.CustomerId equals us.Id
                             select new CustomerDetailDto
                             {
                                 Id = us.Id,
                                 CompanyName = cu.CompanyName,
                                 Email = us.Email,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Status = us.Status

                             };

                return result.ToList();
            }
        }
    }
}
