using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public ICityDAL CityDAL;
        public CityController(ICityDAL CityDAL)
        {
            this.CityDAL = CityDAL;
        }
        // GET: api/City
        [HttpGet("GetCities")]
        public IActionResult GetCities()
        {
            return Ok(CityDAL.GetCities());
        }

        // GET: api/City/5
        [HttpGet("GetAllStreetsOfCityByIdCity/{id}")]
        public IActionResult GetAllStreetsOfCityByIdCity(int id)
        {
            return Ok(CityDAL.GetAllStreetsOfCityByIdCity(id));
        }

        //[HttpPost("AddCity")]
        //public IActionResult AddCity([FromBody] City newCity)
        //{
        //    return Ok(CityDAL.AddCity(newCity));
        //}
        [HttpGet("AddCity/{nameNewCity}")]
        public IActionResult AddCity(string nameNewCity)
        {
            return Ok(CityDAL.AddCity(nameNewCity));
        }


    }
}
