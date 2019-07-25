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
                using (var db = new AppDB(option) )
                {
                    var cars = new CarService(db);

                    cars.Add(new Models.Car());
                    db.SaveChanges();

                    var result = cars.All.ToList();
                    Assert.Single(result);
                }
            }

            [Fact]
            public void CannotAddMoreThenTwoCar()
            {
                var option = new DbContextOptionsBuilder<AppDB>().UseInMemoryDatabase("TestDB").Options;
                using (var db = new AppDB(option))
                {
                    var cars = new CarService(db);


                    Assert.ThrowsAny<Exception>(() =>
                    {
                        cars.Add(new Car());
                        db.SaveChanges();
                        cars.Add(new Car());
                        db.SaveChanges();
                        cars.Add(new Car());
                        db.SaveChanges();
                    });

                    var result = cars.All.ToList();
                    //Assert.Single(result);
                }
            }
        }
    }
}
