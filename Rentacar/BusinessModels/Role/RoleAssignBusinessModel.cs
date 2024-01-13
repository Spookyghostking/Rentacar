using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rentacar.BusinessModels.Role
{
    public class RoleAssignBusinessModel
    {
        public string UserID { get; set; }
        public string UserEmail { get; set; }
        public List<string>? Roles { get; set; }
        public string? ToggledRole { get; set; }
        public IEnumerable<SelectListItem>? RoleList { get; set; }
    }
}
