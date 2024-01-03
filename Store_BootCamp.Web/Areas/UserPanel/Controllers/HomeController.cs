using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        [Route("Profile")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
