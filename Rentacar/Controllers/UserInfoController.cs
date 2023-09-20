using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.UserInfo;

namespace Rentacar.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserInfoBusinessLogic _userInfo;
        private readonly IIdentificationDocumentTypeBusinessLogic _identificationTypes;

        public UserInfoController(
            UserManager<IdentityUser> userManager,
            IUserInfoBusinessLogic userInfo,
            IIdentificationDocumentTypeBusinessLogic identificationTypes)
        {
            _userManager = userManager;
            _userInfo = userInfo;
            _identificationTypes = identificationTypes;
        }
        public async Task<IActionResult> Index()
        {
            if (!(HttpContext.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("Create");
            }

            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            IEnumerable<UserInfoDetailsBusinessModel> userInfo = _userInfo.GetDetailsByUserID(user.Id);

            if (userInfo == null || userInfo.Count() == 0)
            {
                return RedirectToAction("Create");
            }
            return View(userInfo);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_userInfo.GetDetailsByID(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.IdentificationDocumentTypeOptions = _identificationTypes.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserInfoCreateBusinessModel userInfo)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userInfo.User = await _userManager.GetUserAsync(HttpContext.User);
            }

            _userInfo.Insert(userInfo);
            return RedirectToAction("index");
        }
    }
}
