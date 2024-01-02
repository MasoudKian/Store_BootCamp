using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.Controllers
{
    public class AccountController : Controller
    {
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
