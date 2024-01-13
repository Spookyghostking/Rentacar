using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.DataModels
{
    public class UserInfoDataModel
    {
        public int ID { get; set; }
        public IdentityUser? User { get; set; }
        [Required]
        public IdentificationDocumentTypeDataModel IdentificationType { get; set; }
        [Required]
        [MinLength(1), MaxLength(128)]
        public string IdentificationNumber { get; set; }
        [Required]
        [MinLength(1), MaxLength(55)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1), MaxLength(55)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MinLength(1), MaxLength(256)]
        public string AddressOfResidence { get; set; }
        [Required]
        [MinLength(1), MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
