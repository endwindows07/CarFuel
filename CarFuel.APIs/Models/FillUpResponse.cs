using CarFuel.Models;

namespace CarFuel.APIs.Models
{
    public class FillUpResponse
    {
        public int Id { get; set; }
        public int Obometer { get; set; }
        public double Liters { get; set; }
        public bool IsFull { get; set; }
        public double? Kml { get; set; }

        public static FillUpResponse FromModel(FillUp item)
        {
            return new FillUpResponse
            {
                Id = item.Id,
                Obometer = item.odometer,
                Liters = item.liters,
                IsFull = item.isFull,
                Kml = item.Kml,
            };
        }
    }
}