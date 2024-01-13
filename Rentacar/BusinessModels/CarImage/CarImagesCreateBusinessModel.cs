using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.CarImage
{
    public class CarImagesCreateBusinessModel
    {
        [Required]
        public int CarID { get; set; }
        [Required]
        public IFormFileCollection Images { get; set; }
    }
}
