using Rentacar.BusinessModels.CarManufacturer;
using Rentacar.DataModels;

namespace Rentacar.BusinessModels.CarModel
{
    public class CarModelBusinessModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CarManufacturerBusinessModel Manufacturer { get; set; }
    }
}
