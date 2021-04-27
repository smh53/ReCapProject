using Business.Abstract;
using Entities.Color;
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
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("AddColor")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllColors")]
        public IActionResult GetAllColors()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetColorById")]
        public IActionResult GetColorById(int colorId)
        {
            var result = _colorService.GetById(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut("UpdateColor")]
        public IActionResult UpdateCar( Color color)
        {
            var result = _colorService.Update(color);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteColor")]
        public IActionResult DeleteCar(int id)
        {
            var result = _colorService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
