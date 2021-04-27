using Business.Abstract;
using Entities.Rental;
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
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService brandService)
        {
            _rentalService = brandService;
        }

        [HttpPost("AddRental")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllRentals")]
        public IActionResult GetAllRentals()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllRentalDetails")]
        public IActionResult GetAllRentalDetails()
        {
            var result = _rentalService.GetAllRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("GetRentalById")]
        public IActionResult GetRentalById(int rentalId)
        {
            var result = _rentalService.GetById(rentalId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut("UpdateRental")]
        public IActionResult UpdateCar(Rental rental)
        {
            var result = _rentalService.Update(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteRental")]
        public IActionResult DeleteCar(int id)
        {
            var result = _rentalService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
