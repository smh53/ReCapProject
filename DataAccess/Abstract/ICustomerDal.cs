using Core.DataAccess;
using Entities.Brand;
using Entities.Customer;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetAllCustomerDetails();
    }
}
