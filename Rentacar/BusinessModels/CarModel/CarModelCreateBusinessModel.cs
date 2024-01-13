using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.CarModel
{
    public class CarModelCreateBusinessModel
    {
        [Required]
        [MinLength(1), MaxLength(55)]
        public string Name { get; set; }
        [Required]
        public int ManufacturerID { get; set; }
    }
}
