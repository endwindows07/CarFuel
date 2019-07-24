using System;
using System.Collections.Generic;
using System.Linq;
using CarFuel.Models;
using Xunit;

namespace CarFuel.Facts
{
    public class CarFact
    {
        [Fact]
        public void AddCar()
        {
            Car car = new Car(color: "red",
                              make: "...",
                              model: "model 4");
            Assert.NotNull(car);
        }

        [Theory]
        [InlineData(100, 1000)]
        [InlineData(200, 100)]
        [InlineData(10, 5)]
        public void AddFillUpCar(int odometer, double liters)
        {
            Car car = new Car(color: "red",
                              make: "...",
                              model: "model 4");

            car.AddFillUp(odometer, liters);

            foreach (var item in car.FillUps)
            {
                Assert.Equal(odometer, item.odometer);
                Assert.Equal(liters, item.liters);
            }
        }

        [Theory]
        [InlineData(100, -1000)]
        [InlineData(-200, 100)]
        [InlineData(10, -5)]
        public void InvalidAddFillUpCar(int odometer, double liters)
        {
            Car car = new Car(color: "red",
                              make: "...",
                              model: "model 4");

            Assert.Throws<Exception>(() =>
            {
                car.AddFillUp(odometer, liters);
            });
        }

        [Fact]
        public void AddFillUpsCar()
        {
            Car car = new Car(color: "red",
                              make: "...",
                              model: "model 4");

            List<int> odometers = new List<int> { 1000, 2000, 3000, 4000 };
            List<double> listers = new List<double> { 50, 50, 20, 45 };

            _ = car.AddFillUps(odometers, listers);

            var fillUps = car.FillUps.ToList();
            for (int i = 0; i < odometers.Count; i++)
            {
                Assert.Equal(fillUps[i].odometer, odometers[i]);
                Assert.Equal(fillUps[i].liters, listers[i]);
            }
        }

        [Fact]
        public void InvalidAddFillUpsCar()
        {
            Car car = new Car(color: "red",
                              make: "...",
                              model: "model 4");

            List<int> odometers = new List<int> { 400, 2000, 3000, 4000 };
            List<double> listers = new List<double> { 50, -20, 45 };

            Assert.Throws<Exception>(() =>
            {
                _ = car.AddFillUps(odometers, listers);
            });
        }
    }
}
