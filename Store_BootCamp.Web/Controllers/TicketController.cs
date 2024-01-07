using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace Store_BootCamp.Web.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            var userId = User.Claims;
            var fata = DateAndTime.Now.ToString();
            return View();
        }

    }
}
