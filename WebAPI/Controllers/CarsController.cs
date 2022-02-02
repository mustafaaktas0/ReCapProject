﻿using Business.Abstract;
using Entities.Concrete;
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
    public class CarsController : ControllerBase
    {

        ICarService _carService;


        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _carService.GetAll();

                 if (result.Success)
                    { 
                      return Ok(result.Data);
                    }
                else
                    {
                    return BadRequest(result.Message);
                    }
             }
        /// <summary>
        /// added car 
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result.Message); }
        }

        [HttpGet("getbyıd")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);

            if (result.Success)
            {
                return Ok(result.Data);

            }
            else { return BadRequest(result.Data); }
        }




        [HttpGet("getbybrandıd")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
