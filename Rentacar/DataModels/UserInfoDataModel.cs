using Microsoft.AspNetCore.Identity;

namespace Rentacar.DataModels
{
    public class UserInfoDataModel
    {
        public int ID { get; set; }
        public IdentityUser? User { get; set; }
        public IdentificationDocumentTypeDataModel IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressOfResidence { get; set; }
        public string PhoneNumber { get; set; }
    }
}
