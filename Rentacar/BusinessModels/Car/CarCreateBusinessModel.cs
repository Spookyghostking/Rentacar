using Microsoft.AspNetCore.Mvc.Rendering;
using Rentacar.BusinessModels.CarModel;
using Rentacar.DataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentacar.BusinessModels.Car
{
    public class CarCreateBusinessModel
    {
        [Required]
        [MinLength(1), MaxLength(25)]
        [Display(Name = "Licence Plate Number")]
        public string LicencePlateNumber { get; set; }
        [Required]
        [Display(Name = "Model")]
        public int CarModelID { get; set; }
        [Required]
        [Display(Name = "Type")]
        public int CarBodyTypeID { get; set; }
        [Required]
        [MinLength(1), MaxLength(55)]
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
        public IFormFileCollection? Images { get; set; }
        [Required]
        [Display(Name = "Year of manufacture")]
        public int ManufacturedYear { get; set; }
        [NotMapped]
        public List<SelectListItem>? CarBodyTypeList { get; set; }
    }
}
