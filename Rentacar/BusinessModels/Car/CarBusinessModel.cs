using Rentacar.BusinessModels.CarModel;

namespace Rentacar.BusinessModels.Car
{
    public class CarBusinessModel
    {
        public string LicencePlateNumber { get; set; }
        public CarModelBusinessModel CarModel { get; set; }
        public IFormFileCollection Images { get; set; }
        public DateTime ManufacturedDate { get; set; }
    }
}
