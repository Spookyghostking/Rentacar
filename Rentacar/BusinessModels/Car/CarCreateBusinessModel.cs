using Rentacar.BusinessModels.CarModel;
using Rentacar.DataModels;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.Car
{
    public class CarCreateBusinessModel
    {
        public string LicencePlateNumber { get; set; }
        public int CarModelID { get; set; }
        public string CodeName { get; set; }
        public float DailyFee { get; set; }
        public float FixedFee { get; set; }
        public IFormFileCollection Images { get; set; }
        public int ManufacturedYear { get; set; }
    }
}
