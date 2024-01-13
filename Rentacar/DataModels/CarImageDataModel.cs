using System.ComponentModel.DataAnnotations;

namespace Rentacar.DataModels
{
    public class CarImageDataModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(512)]
        public string Url { get; set; }
        [Required]
        public CarDataModel Car { get; set; }
    }
}
