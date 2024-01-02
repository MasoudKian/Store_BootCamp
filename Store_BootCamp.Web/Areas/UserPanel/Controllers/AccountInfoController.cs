using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class AccountInfoController : Controller
    {
        [Route("Profile")]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
