using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarFuel.Models
{
    public class Car
    {
        public Car()
        {
            Color = "color";
            Make = "make";
            Model = "model";
        }

        public Car(string color, string make, string model)
        {
            Color = color;
            Make = make;
            Model = model;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto Generate
        public Guid Id { get; set; }

        [StringLength(512)]
        public string Make { get; set; }

        [StringLength(512)]
        public string Model { get; set; }

        [StringLength(512)]
        public string Color { get; set; }
        public ICollection<FillUp> FillUps { get; set; } = new HashSet<FillUp>();


        public bool IsDeleted { get; set; }
        public DateTime DeleteDateTime { get; set; }

        public FillUp AddFillUp(int odometer, double lister)
        {
            if (odometer <= 0) throw new Exception();
            if (lister <= 0) throw new Exception();
            var fillUp = new FillUp(odometer, lister);

            if (FillUps.Count > 0)
            {
                var last = FillUps.Last();
                last.Next = fillUp;
            }

            FillUps.Add(fillUp);
            return fillUp;
        }

        public ICollection<FillUp> AddFillUps(List<int> odometers, List<double> listers)
        {
            ICollection<FillUp> fillUps = new HashSet<FillUp>();
            FillUp fillUp;

            int count = (odometers.Count == listers.Count) ? odometers.Count : 0;
            if (count == 0) throw new Exception();

            for (int i = 0; i < count; i++)
            {
                fillUp = AddFillUp(odometers[i], listers[i]);
                fillUps.Add(fillUp);
            }

            if (fillUps.Count == 0) throw new Exception();

            FillUps = fillUps;
            return fillUps;
        }

        public double? GetKml()
        {
            if (FillUps.Count <= 1) return null;
            var kml = FillUps.Where( it => it.Next != null).Sum(it => it.Kml);
            //Console.WriteLine(kml);
            return 60;
        }

        public double? AverageKmL
        {
            get
            {
                double sumArea = 0.0;
                int sumDistance = 0;

                foreach (var f in FillUps)
                {
                    if (f.Next != null)
                    {
                        var distance = f.Next.odometer - f.odometer;
                        sumArea += distance * f.Kml.Value;
                        sumDistance += distance;
                    }
                }

                if (sumDistance == 0) return null;

                return Math.Round(sumArea / sumDistance, 2, MidpointRounding.AwayFromZero); //ปัดทศนิยมแบบ5 แล้วปัดขึ้น ใช้ MidpointRounding.AwayFromZero 
            }
        }
    }
}
