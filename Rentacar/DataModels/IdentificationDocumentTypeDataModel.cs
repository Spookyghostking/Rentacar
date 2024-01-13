using System.ComponentModel.DataAnnotations;

namespace Rentacar.DataModels
{
    public class IdentificationDocumentTypeDataModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(55)]
        public string Value { get; set; }
    }
}
