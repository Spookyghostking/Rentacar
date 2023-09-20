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
        public string LicencePlateNumber { get; set; }
        public string CodeName { get; set; }
        public CarModelDataModel CarModel { get; set; }
        public IEnumerable<CarImageDataModel> Images { get; set; }
        public float DailyFee { get; set; }
        public float FixedFee { get; set; }
        public int ManufacturedYear { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
