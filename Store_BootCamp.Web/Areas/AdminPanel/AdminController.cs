using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;

namespace Store_BootCamp.Web.Areas.AdminPanel
{
    [Area("AdminPanel")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
