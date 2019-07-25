using System;
using System.Linq;
using CarFuel.Models;
using CarFuel.Services;
using CarFuel.Services.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CarFuel.Facts
{
    public class CarServiceFact
    {
        public class Add
        {
            [Fact]
            public void AddFirstCar()
            {
                var option = new DbContextOptionsBuilder<AppDB>().UseInMemoryDatabase("TestDB").Options;
                using (var db = new AppDB(option))
                {
                    var app = new App(db);

                    app.Cars.Add(new Car());

                    db.SaveChanges();

                    var result = app.Cars.All.ToList();
                    Assert.Single(result);
                }

            }

            [Fact]
            public void CannotAddMoreThenTwoCar()
            {
                var option = new DbContextOptionsBuilder<AppDB>().UseInMemoryDatabase("TestDB").Options;
                using (var db = new AppDB(option))
                {
                    var app = new App(db);

                    Assert.ThrowsAny<Exception>(() =>
                    {
                        app.Cars.Add(new Car());
                        app.SaveChanged();
                        app.Cars.Add(new Car());
                        app.SaveChanged();
                        app.Cars.Add(new Car());
                        app.SaveChanged();
                    });

                    //var result = app.Cars.All(itar => true);
                    //Assert.Single(result);
                }
            }


            //[Fact]
            //public void CannotAddMoreThanTwoCars()
            //{

            //    var options = new DbContextOptionsBuilder<AppDB>()
            //    .UseInMemoryDatabase("testdb")
            //    .Options;
            //    using (var db = new AppDB(options))
            //    {
            //        var app = new App(db);
            //        app.Cars.Add(new Car());
            //        app.Cars.Add(new Car());

            //        db.SaveChanges();

            //        Assert.ThrowsAny<Exception>(() =>
            //        {
            //            app.Cars.Add(new Car());
            //            db.SaveChanges();
            //        });


            //    }
            //}
        }
    }
}
