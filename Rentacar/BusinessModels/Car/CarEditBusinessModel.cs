using Microsoft.AspNetCore.Mvc.Rendering;
using Rentacar.DataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentacar.BusinessModels.Car
{
    public class CarEditBusinessModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(25)]
        [Display(Name = "Licence Plate Number")]
        public string LicencePlateNumber { get; set; }
        [Required]
        [Display(Name = "Model")]
        public int CarModelID { get; set; }
        public CarModelDataModel CarModel { get; set; }
        public CarManufacturerDataModel CarManufacturer { get; set; }
        [Required]
        [Display(Name = "Type")]
        public int CarBodyTypeID { get; set; }
        [Required]
        public int ManufacturedYear { get; set; }
        [Required]
        [MinLength(1), MaxLength(25)]
        [Display(Name = "Code Name")]
        public string CodeName { get; set; }
        [Required]
        [Display(Name = "Seat Count")]
        public int SeatCount { get; set; }
        [Required]
        [Display(Name = "Daily Fee")]
        public float DailyFee { get; set; }
        [Required]
        [Display(Name = "Reservation Fee")]
        public float FixedFee { get; set; }
        public IEnumerable<CarImageDataModel>? Images { get; set; }
        [NotMapped]
        [Display(Name = "Year of manufacture")]
        public List<SelectListItem>? CarBodyTypeList { get; set; }
    }
}
