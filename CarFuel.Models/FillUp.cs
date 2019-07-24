using System;
using System.Collections.Generic;

namespace CarFuel.Models
{
    public class FillUp
    {
        public FillUp(int odometer, double liters)
        {
            this.odometer = odometer;
            this.liters = liters;
        }

        public bool isFull;
        public int odometer { get; set; }
        public double liters { get; set; }
        public double? Kml
        {
            get
            {
                //if (odometer < 0) throw new InvalidDtataException(propertyName: nameof(odometer), message: "odometer ต้องมีค่ามากกว่า 0");
                //if (liters < 0) throw new InvalidDtataException(propertyName: nameof(liters), message: "liters ต้องมีค่ามากกว่า 0");

                if (odometer < 0) throw new Exception();
                if (liters < 0) throw new Exception();
                if (Next.odometer < odometer) throw new Exception();
                if (Next == null) return null;
                return (Next.odometer - odometer) / Next.liters;
            }
        }
        public FillUp Next { get; set; } // navigation property
    }
}
