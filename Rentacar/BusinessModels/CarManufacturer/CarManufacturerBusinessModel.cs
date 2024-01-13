using Rentacar.DataModels;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.CarManufacturer
{
    public class CarManufacturerBusinessModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(55)]
        public string Name { get; set; }
    }
}
