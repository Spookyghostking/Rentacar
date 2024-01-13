using Rentacar.BusinessModels.CarModel;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.Car
{
    public class CarListBusinessModel
    {
        public int ID { get; set; }
        [Display(Name = "Licence Plate")]
        public string LicencePlateNumber { get; set; }
        [Display(Name = "Manufacturer")]
        public string CarManufacturerName { get; set; }
        [Display(Name = "Model")]
        public string CarModelName { get; set; }
        [Display(Name = "Type")]
        public string CarBodyTypeValue { get; set; }
        [Display(Name = "Birth year")]
        public int ManufacturedYear { get; set; }
        [Display(Name = "Name")]
        public string CodeName { get; set; }
        [Display(Name = "Seat Count")]
        public int SeatCount { get; set; }
        [Display(Name = "Daily Fee")]
        public float DailyFee { get; set; }
        [Display(Name = "Reservation Fee")]
        public float FixedFee { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
