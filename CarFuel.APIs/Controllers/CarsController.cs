using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarFuel.Models;
using CarFuel.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarFuel.APIs.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly App app;

        public CarsController(App app)
        {
            this.app = app;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAll()
        {
            return  this.app.Cars.All.ToList();
        }
    }
}
