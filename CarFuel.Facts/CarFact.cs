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
        public void NewCar()
        {
            Car car = new Car(color: "red",
                              make: "...",
                              model: "model 4");
            Assert.NotNull(car.FillUps);

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

        [Fact]
        public void AddSingleFillUp()
        {
            var car = new Car();

            var f = car.AddFillUp(1000, 20);

            Assert.Equal(1, car.FillUps.Count);
            Assert.Equal(1000, f.odometer);
            Assert.Equal(20, f.liters);
        }


        [Fact]
        public void AddTwoFillUp()
        {
            var car = new Car();

            var v1 = car.AddFillUp(1000, 20);
            var v2 = car.AddFillUp(2000, 30);

            Assert.Equal(2, car.FillUps.Count);
            Assert.Equal(1000, v1.odometer);
            Assert.Equal(20, v1.liters);
            Assert.Equal(2000, v2.odometer);
            Assert.Equal(30, v2.liters);

            Assert.Same(v2, v1.Next);
        }

        [Fact]
        public void AverageFillUp()
        {
            var car = new Car();
            double? kml = car.GetKml();
            Assert.Null(kml);
            //Assert.Equal    
            //var result = f.Kml;
        }

        [Fact]
        public void SingleFillUp()
        {
            var car = new Car();
            car.AddFillUp(1000, 20);
            double? kml = car.GetKml();
            Assert.Null(kml);
        }

        [Fact]
        public void TwoFillUp()
        {
            var car = new Car();
            car.AddFillUp(1000, 50);
            car.AddFillUp(1600, 60);

            double? kml = car.GetKml();
            var it = Math.Round((double)kml, 2, MidpointRounding.AwayFromZero);
            Assert.Equal(60, it);
        }
    }
}
