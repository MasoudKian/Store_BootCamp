using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Store_BootCamp.Web.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            var userId = User.Claims;
            
            return View();
        }

    }
}
