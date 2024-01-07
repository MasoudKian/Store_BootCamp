using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Store_BootCamp.Web.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
