using System.ComponentModel.DataAnnotations;

namespace Rentacar.DataModels
{
    public class CarModelDataModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(55)]
        public string Name { get; set; }
        [Required]
        public CarManufacturerDataModel Manufacturer { get; set; }
    }
}
