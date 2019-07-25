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
        public CarService(App db) : base(db)
        {

        }

        public override IQueryable<Car> Query(Func<Car, bool> condition)
        {
            return app.db.Cars.Include(it => it.FillUps).Where(it => !it.IsDeleted).AsQueryable();
            //return base.Query(condition);
        }

        public override Car Find(params object[] keys)
        {
            var c = base.Find(keys);
            if (c == null) return null;
            if (c.IsDeleted) return null;
            app.db.Entry(c).Collection(it => it.FillUps).Load();
            return c;
        }

        public override Car Delete(Car item)
        {
            if (!item.IsDeleted)
            {
                item.IsDeleted = true;
                item.DeleteDateTime = DateTime.Now;
            }


            return item;
        }

        public override Car Add(Car item)
        {
            if (app.db.Cars.Count() >= 2) throw new Exception();
            return base.Add(item);
        }
    }
}
