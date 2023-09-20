using Rentacar.DataModels;

namespace Rentacar.BusinessModels.Car
{
    public class CarEditBusinessModel
    {
        public int ID { get; set; }
        public string LicencePlateNumber { get; set; }
        public int CarModelID { get; set; }
        public CarModelDataModel CarModel { get; set; }
        public CarManufacturerDataModel CarManufacturer { get; set; }
        public int ManufacturedYear { get; set; }
        public string CodeName { get; set; }
        public float DailyFee { get; set; }
        public float FixedFee { get; set; }
        public IEnumerable<CarImageDataModel> Images { get; set; }
    }
}
