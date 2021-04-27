using Business.Abstract;
using Entities.Car;
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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [Route("AddCar")]
        public IActionResult AddCar([FromForm] Car car, IFormFile[] files)
        {
            var result = _carService.Add(car,files);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllCars")]
        public IActionResult GetAllCars()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllCarDetails")]
        public IActionResult GetAllCarDetails()
        {
            var result = _carService.GetAllCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


       

        [HttpGet("GetCarById/{carId}")]
        public IActionResult GetCarById(int carId)
        {
            var result = _carService.GetById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCarImageById/{carId}")]
        public IActionResult GetCarImageById(int carId)
        {
            var result = _carService.GetCarImageById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCarDetailsById/{carId}")]
        public IActionResult GetCarDetailsById(int carId)
        {
            var result = _carService.GetCarDetailsById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllCarsByBrandId/{brandId}")]
        public IActionResult GetAllCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllCarsByColorId/{colorId}")]
        public IActionResult GetAllCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut("UpdateCar")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }

        [HttpPut("UpdateCarImage")]
        public IActionResult UpdateCarImage([FromForm] CarImage carimage, IFormFile file)
        {
            var result = _carService.UpdateCarImage(carimage,file);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteCar")]
        public IActionResult DeleteCar(int id)
        {
            var result = _carService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteCarImage")]
        public IActionResult DeleteCarImage(int carimageId)
        {
            var result = _carService.DeleteCarImage(carimageId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
