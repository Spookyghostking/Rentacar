using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.CarImage
{
    public class CarImageCreateBusinessModel
    {
        [Required]
        public int CarID { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
