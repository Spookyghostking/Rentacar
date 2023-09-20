using Rentacar.DataModels;

namespace Rentacar.BusinessModels.Car
{
    public class CarDetailsBusinessModel
    {
        public int ID { get; set; }
        public string LicencePlateNumber { get; set; }
        public string CarManufacturerName { get; set; }
        public string CarModelName { get; set; }
        public int ManufacturedYear { get; set; }
        public string CodeName { get; set; }
        public float DailyFee { get; set; }
        public float FixedFee { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<CarImageDataModel> Images { get; set; }
    }
}
