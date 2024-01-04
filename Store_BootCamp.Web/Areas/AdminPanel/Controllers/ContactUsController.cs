using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ContactUsController : Controller
    {
        public IActionResult SiteMessages()
        {
            return View();
        }
    }
}
