using Business.Abstract;
using Entities.Brand;
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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("AddBrand")]
        public IActionResult AddBrand(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllBrands")]
        public IActionResult GetAllBrands()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetBrandById")]
        public IActionResult GetBrandById(int brandId)
        {
            var result = _brandService.GetById(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut("UpdateBrand")]
        public IActionResult UpdateCar(Brand brand)
        {
            var result = _brandService.Update(brand);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteBrand")]
        public IActionResult DeleteCar(int id)
        {
            var result = _brandService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
