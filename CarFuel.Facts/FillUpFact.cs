using System;
using System.Collections.Generic;
using System.Linq;
using CarFuel.Models;
using Xunit;

namespace CarFuel.Facts
{
    public class FillUpFact
    {
        public class GenaeralUsage
        {
            [Fact]
            public void NewFillUp()
            {
                // arrange
                // act
                FillUp f1 = new FillUp(odometer: 1000, liters: 50.0);

                // assert
                Assert.Equal(1000, f1.odometer);
                Assert.Equal(50.0, f1.liters);
                Assert.False(f1.isFull);
                Assert.Null(f1.Next);
            }
        }
        public class Kml
        {

            [Fact]
            public void FirstFillUp()
            {
                //FillUp f1 = new FillUp(odometer: 1000, liters: 50.0);
                //var result = f1.Kml;
                //Assert.Null(result);
            }

            [Fact]
            public void TwoFillUp()
            {
                FillUp f1 = new FillUp(odometer: 1000, liters: 50.0);
                FillUp f2 = new FillUp(odometer: 1600, liters: 60.0);
                f1.Next = f2;
                var result = f1.Kml;
                Assert.Equal(10.0, result);
            }

            [Theory]
            [InlineData(1000, 151.0)]
            [InlineData(-1500, 52.0)]
            [InlineData(-1999, 53.0)]
            public void InvalidData(int odometer, double liters)
            {
                FillUp f1 = new FillUp(odometer, liters);
                //Assert.Null(f1.Kml);
                Assert.ThrowsAny<Exception>(() =>
                {
                    var k1 = f1.Kml;
                });
            }
        }

        
    }
}
