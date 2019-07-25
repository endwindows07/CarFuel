using CarFuel.Models;

namespace CarFuel.APIs.Models
{
    public class CarReequest
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Car ToModel()
        {
            return new Car
            {
                Make = Make,
                Model = Model,
                Color = Color
            };
        }
    }
}
