using System.ComponentModel.DataAnnotations;

namespace Rentacar.DataModels
{
    public class IdentificationDocumentImageDataModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(512)]
        public string Url { get; set; }
        [Required]
        public UserInfoDataModel UserInfo { get; set; }
    }
}
