using System;
using System.Collections.Generic;

namespace CarFuel.Models
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public ICollection<FillUp> FillUps { get; set; } = new HashSet<FillUp>();

        public FillUp AddFillUp(int odometer, double lister)
        {
            if (odometer <= 0) throw new Exception();
            if (lister <= 0) throw new Exception();
            var fillUp = new FillUp(odometer, lister);
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
    }
}
