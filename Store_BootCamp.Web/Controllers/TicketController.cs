using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Domain.Models.Tickets;

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
            var user = User.Claims.FirstOrDefault().Value;
            var tickets = ticketService.GetUserTickets(int.Parse(user));
            return View(tickets);
        }
        [HttpGet]
        public IActionResult AddTicket() {
            return View();
        }
        [HttpPost]
        public IActionResult AddTicket(Ticket ticket,string text)
        {
            var userId = User.Claims.FirstOrDefault().Value;
            var UserE=ticketService.GetUserById(int.Parse(userId));
            ticket.Owner = UserE;
            if (ticket != null)
            {
                ticketService.CreateTicket(ticket,text);
                ticketService.SaveChange();
            }
            return RedirectToAction("Index");
        }
 
    }
}
