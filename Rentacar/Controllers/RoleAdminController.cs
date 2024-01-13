using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rentacar.BusinessModels.Role;

namespace Rentacar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleAdminController(
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<IdentityRole> roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            IdentityResult result = await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                return View(role);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole role)
        {
            throw new NotImplementedException();
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            IdentityResult result = await _roleManager.UpdateAsync(role);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                return View(role);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(IdentityRole role)
        {
            IdentityRole adminRole = await _roleManager.FindByNameAsync("Admin");
            if (adminRole != null && (role.Id == adminRole.Id || role.Name == adminRole.Name))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            IdentityResult result = await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UserRoles(string? q)
        {
            IEnumerable<IdentityUser> users = _userManager.Users;
            if (q != null)
            {
                users = users.Where(u => u.Email.ToLower().Contains(q));
            }
            users = users.ToList();
            List< Tuple < IdentityUser, List<string> > > userRoles = new List<Tuple<IdentityUser, List<string>>>();
            foreach (IdentityUser user in users)
            {
                List<string> roles = (await _userManager.GetRolesAsync(user)).ToList();
                userRoles.Add(Tuple.Create(user, roles));
            }
            return View(userRoles);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            List<string> roles = (await _userManager.GetRolesAsync(user)).ToList();
            List<SelectListItem> roleList = new List<SelectListItem>();
            foreach (var role in _roleManager.Roles)
            {
                roleList.Add(new SelectListItem(role.Name, role.Name));
            }

            RoleAssignBusinessModel model = new RoleAssignBusinessModel() {
                UserID = user.Id, 
                UserEmail = user.Email, 
                Roles = roles, 
                RoleList = roleList
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(RoleAssignBusinessModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            IdentityUser user = await _userManager.FindByIdAsync(model.UserID);
            if (user == null || model.ToggledRole == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            IdentityRole role = await _roleManager.FindByNameAsync(model.ToggledRole);
            if (role == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            IdentityUser requestUser = await _userManager.GetUserAsync(HttpContext.User);
            bool isAdmin = await _userManager.IsInRoleAsync(requestUser, "Admin");
            IdentityRole adminRole = await _roleManager.FindByNameAsync("Admin");
            if (requestUser == user && isAdmin && role == adminRole)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }
            IdentityResult result;
            if (await _userManager.IsInRoleAsync(user, role.Name))
            {
                result = await _userManager.RemoveFromRoleAsync(user, role.Name);
            } else
            {
                result = await _userManager.AddToRoleAsync(user, role.Name);
            }
            if (result.Succeeded)
            {
                return RedirectToAction("AssignRole", new { id = user.Id });
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
