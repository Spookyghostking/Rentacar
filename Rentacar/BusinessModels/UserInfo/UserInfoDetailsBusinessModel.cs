using Microsoft.AspNetCore.Identity;
using Rentacar.BusinessModels.IdentificationDocumentImage;
using Rentacar.BusinessModels.IdentificationDocumentType;

namespace Rentacar.BusinessModels.UserInfo
{
    public class UserInfoDetailsBusinessModel
    {
        public int ID { get; set; }
        public IdentityUser? User { get; set; }
        public IdentificationDocumentTypeBusinessModel IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public IEnumerable<IdentificationDocumentImageBusinessModel> IdentificationImages { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressOfResidence { get; set; }
        public string PhoneNumber { get; set; }
    }
}
