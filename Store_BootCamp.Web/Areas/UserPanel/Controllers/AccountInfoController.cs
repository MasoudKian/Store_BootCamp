using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class AccountInfoController : Controller
    {
        [Route("/UserPanel/Profile")]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
