using System;
using CarFuel.Models;
using CarFuel.Services.Core;
using CarFuel.Services.Data;

namespace CarFuel.Services
{
    public class CarService : ServiceBase<Car>
    {
        public CarService(AppDB db) : base(db)
        {

        }
    }
}
