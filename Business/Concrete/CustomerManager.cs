using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Customer;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult AddTransactionalTest(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int customerId)
        {
            var result = _customerDal.Get(f => f.CustomerId == customerId);
            if (result != null)
            {
                _customerDal.Delete(result);
                return new SuccessResult("Müşteri Silindi.");
            }
            return new ErrorResult("Böyle bir kayıt zaten yok");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails()
        {
            var result = _customerDal.GetAllCustomerDetails();
            return new SuccessDataResult<List<CustomerDetailDto>>(result);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var result = _customerDal.Get(f => f.CustomerId == customerId);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result);
            }
            return new ErrorDataResult<Customer>(result, "Bulunamadı.");
        }

        public IResult Update(Customer customer)
        {
            var result = _customerDal.Get(f => f.CustomerId == customer.CustomerId);
            if (result != null)
            {
                result.CompanyName = customer.CompanyName;
              
                _customerDal.Update(customer);
                return new SuccessResult("Müşteri güncellendi.");
            }
            return new ErrorResult("Böyle bir kayıt yok.");
        }
    }
}
