using System;
namespace CarFuel.APIs.Models
{
    public class FillUpRequest
    {
        public double Odometer { get; set; }
        public double Liters { get; set; }
        public bool IsFull { get; set; }
    }
}
