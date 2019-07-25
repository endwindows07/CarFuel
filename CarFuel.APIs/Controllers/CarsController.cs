using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarFuel.APIs.Models;
using CarFuel.Models;
using CarFuel.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarFuel.APIs.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly App app;

        public CarsController(App app)
        {
            this.app = app;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ProblemDetails))]
        public ActionResult<IEnumerable<CarResponse>> GetAll()
        {
            return this.app.Cars.All.ToList().ConvertAll(it => CarResponse.FromModel(it));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProblemDetails))]
        [ProducesResponseType(404, Type = typeof(ProblemDetails))]
        public ActionResult<CarResponse> GetById(Guid id)
        {
            return CarResponse.FromModel(app.Cars.Find(id));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProblemDetails))]
        [ProducesResponseType(201, Type = typeof(ProblemDetails))]
        public ActionResult<CarResponse> Post(CarReequest  item)
        {
            var result = item.ToModel();

            app.Cars.Add(result);
            app.SaveChanged();

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(404, Type = typeof(ProblemDetails))]
        [ProducesResponseType(402, Type = typeof(ProblemDetails))]
        [ProducesResponseType(204, Type = typeof(ProblemDetails))]
        public ActionResult Put(Guid id, CarReequest item)
        {
            var res = app.Cars.Find(id);
            if (res == null) return NotFound();

            res.Make = item.Make;
            res.Model = item.Model;
            res.Color = item.Color;

            app.Cars.Update(res);
            app.SaveChanged();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404, Type = typeof(ProblemDetails))]
        [ProducesResponseType(202, Type = typeof(ProblemDetails))]
        [ProducesResponseType(200, Type = typeof(ProblemDetails))]
        public ActionResult<CarResponse> Delete(Guid id)
        {
            var c = app.Cars.Find(id);
            if (c == null) return NotFound();

            app.Cars.Delete(c);
            app.SaveChanged();
            return Ok(c);
        }

        [HttpPost("{id}/FillUps")]
        
        [ProducesResponseType(200, Type = typeof(ProblemDetails))]
        [ProducesResponseType(404, Type = typeof(ProblemDetails))]
        public ActionResult<FillUpResponse> AddFillUp(Guid id, FillUp item)
        {
            var car = app.Cars.Find(id);
            if (car == null) return NotFound();
            car.AddFillUp(item.odometer, item.liters);
            app.SaveChanged();
            return Ok(FillUpResponse.FromModel(car.FillUps.Last()));
        }
    }
}
