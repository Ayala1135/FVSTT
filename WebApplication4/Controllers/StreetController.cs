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
    public class StreetController : Controller
    {
        public IStreetDAL StreetDAL;
        public StreetController(IStreetDAL StreetDAL)
        {
            this.StreetDAL = StreetDAL;
        }


        //[HttpPost("AddStreet")]
        //public IActionResult AddStreet([FromBody] Street newStreet)
        //{
        //    return Ok(StreetDAL.AddStreet(newStreet));
        //}

        //[HttpPost("AddStreet")]
        //public IActionResult AddStreet([FromBody] Street newStreet,City city)
        //{
        //    return Ok(StreetDAL.AddStreetToSpesificCity(newStreet,city));
        //}
        [HttpGet("AddStreet/{nameNewStreet}")]
        public IActionResult AddStreet(string nameNewStreet)
        {
            return Ok(StreetDAL.AddStreet(nameNewStreet));
        }
        [HttpGet("AddStreetToSpesificCity/{nameNewStreet}/{nameCity}")]
        public IActionResult AddStreetToSpesificCity(string nameNewStreet, string nameCity)
        {
            return Ok(StreetDAL.AddStreetToSpesificCity(nameNewStreet, nameCity));
        }
    }
}
