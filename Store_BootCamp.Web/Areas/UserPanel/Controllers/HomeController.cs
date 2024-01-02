using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;

namespace Store_BootCamp.Web.Areas.UserPanel.Controllers
{
    [Authorize]
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        #region Constructor

        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        
        public IActionResult Index()
        {
            var user = _userService.GetInformationUser(User.Identity!.Name!);
            return View(user);
        }
    }
}
