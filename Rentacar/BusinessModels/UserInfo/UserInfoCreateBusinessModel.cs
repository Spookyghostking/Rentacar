using Microsoft.AspNetCore.Identity;
using Rentacar.BusinessModels.IdentificationDocumentType;

namespace Rentacar.BusinessModels.UserInfo
{
    public class UserInfoCreateBusinessModel
    {
        public IdentityUser? User { get; set; }
        public int IdentificationTypeID { get; set; }
        public string IdentificationNumber { get; set; }
        public IFormFileCollection IdentificationImages { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressOfResidence { get; set; }
        public string PhoneNumber { get; set; }
    }
}
