using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;

namespace Store_BootCamp.Web.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;
        public TicketController(ITicketService ticket)
        {
            ticketService = ticket;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
