using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
