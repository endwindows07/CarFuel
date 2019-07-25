using System;
using System.Collections.Generic;
using System.Linq;
using CarFuel.Models;

namespace CarFuel.APIs.Models
{
    public class CarResponse
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double? AverageKml { get; set; }
        public List<FillUpResponse> FillUps { get; set; }


        public static CarResponse FromModel(Car item)
        {
            return new CarResponse
            {
                Id = item.Id,
                Make = item.Make,
                Model = item.Model,
                Color = item.Color,
                AverageKml = item.AverageKmL,
                FillUps = item.FillUps.ToList()
                .ConvertAll(it => FillUpResponse.FromModel(it)),
            };
        }
    }
}
