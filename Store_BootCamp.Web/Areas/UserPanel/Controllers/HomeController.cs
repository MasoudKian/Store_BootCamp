using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;

namespace Store_BootCamp.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        #region Constructor

        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        [Route("UserPanel/Profile")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
