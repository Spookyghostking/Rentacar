using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.CarManufacturer
{
    public class CarManufacturerCreateBusinessModel
    {
        [Required]
        [MinLength(1), MaxLength(55)]
        public string Name { get; set; }
    }
}
