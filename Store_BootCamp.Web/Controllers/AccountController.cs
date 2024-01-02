using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
