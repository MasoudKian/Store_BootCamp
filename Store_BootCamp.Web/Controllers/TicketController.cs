using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.Ticket;
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
        public IActionResult AddTicket()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTicket(TicketViewModel ticket)
        {
            var userId = User.Claims.FirstOrDefault().Value;
            var UserE = ticketService.GetUserById(int.Parse(userId));
            ticket.OwnerId = UserE.Id;
            if (ticket != null)
            {
                ticketService.AddTicket(ticket);
                ticketService.SaveChange();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddTicketMassage(int id)
        {
            if (id != null)
            {
                return View(ticketService.GetTicketDetails(id));
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddTicketMassage()
        {
            var userId = User.Claims.FirstOrDefault().Value;
            if ()
            {
                ticketService.AddTicketMassage();
                ticketService.SaveChange();
            }


            return RedirectToAction("AddTicketMassage",Ticketid);
        }

      

    }
}
