using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarFuel.Models
{
    public class FillUp
    {
        public FillUp(int odometer, double liters)
        {
            this.odometer = odometer;
            this.liters = liters;
        }

        public int Id { get; set; }
        public bool isFull;

        [Range(0, 9_999_999)]
        public int odometer { get; set; }


        public double liters { get; set; }
        public double? Kml
        {
            get
            {
                //if (odometer < 0) throw new InvalidDtataException(propertyName: nameof(odometer), message: "odometer ต้องมีค่ามากกว่า 0");
                //if (liters < 0) throw new InvalidDtataException(propertyName: nameof(liters), message: "liters ต้องมีค่ามากกว่า 0");
                //if (Next != null)
                //{
                if (odometer < 0) throw new Exception();
                if (liters < 0) throw new Exception();
                if (Next != null) return null;
                if (Next.odometer < odometer) throw new Exception();
                return (Next.odometer - odometer) / Next.liters;
                //}
                //return null;
            }
        }
        public FillUp Next { get; set; } // navigation property
    }
}
