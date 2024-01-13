using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rentacar.DataModels
{
    [Index(nameof(LicencePlateNumber), IsUnique = true)]
    public class CarDataModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(25)]
        public string LicencePlateNumber { get; set; }
        [Required]
        [MinLength(1), MaxLength(55)]
        public string CodeName { get; set; }
        [Required]
        public CarModelDataModel CarModel { get; set; }
        [Required]
        public CarBodyTypeDataModel CarBodyType { get; set; }
        public IEnumerable<CarImageDataModel>? Images { get; set; }
        [Required]
        public int SeatCount { get; set; }
        [Required]
        public float DailyFee { get; set; }
        [Required]
        public float FixedFee { get; set; }
        [Required]
        public int ManufacturedYear { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
    }
}
