using Core.Utilities.Results;
using Entities.Customer;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails();
        IDataResult<Customer> GetById(int customerId);

        IResult Add(Customer customer);

        IResult Delete(int customerId);
        IResult Update(Customer customer);

        IResult AddTransactionalTest(Customer customer);
    }
}
