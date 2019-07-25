using System;
using System.Linq;
using CarFuel.Models;
using CarFuel.Services.Core;
using CarFuel.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace CarFuel.Services
{
    public class CarService : ServiceBase<Car>
    {
        public CarService(AppDB db) : base(db)
        {
            
        }

        public override IQueryable<Car> Query(Func<Car, bool> condition)
        {
            return Db.Cars.Include(it => it.FillUps).Where(condition).AsQueryable();
            //return base.Query(condition);
        }

        public override Car Find(params object[] keys)
        {
            var c = base.Find(keys);
            if (c != null)
            {
                Db.Entry(c).Collection(it => it.FillUps).Load();
            }
            return c;
        }
    }
}
