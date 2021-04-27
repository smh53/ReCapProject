using Business.Abstract;
using Entities.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllCustomerDetails")]
        public IActionResult GetAllCustomerDetails()
        {
            var result = _customerService.GetAllCustomerDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }




        [HttpGet("GetCustomerById")]
        public IActionResult GetCustomerById(int customerId)
        {
            var result = _customerService.GetById(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCar(Customer customer)
        {
            var result = _customerService.Update(customer);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCar(int id)
        {
            var result = _customerService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
