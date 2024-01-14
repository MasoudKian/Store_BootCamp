using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            ticket.OwnerId = int.Parse(userId);
            if (ModelState.IsValid)
            {
                ticketService.AddTicket(ticket,int.Parse(userId));
                ticketService.SaveChange();
                return RedirectToAction("Index");

            }
            return View();
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
        public IActionResult AddTicketMassage(TicketDetailsViewModel ticketDetails)
        {
            var userId = User.Claims.FirstOrDefault().Value;
            ticketDetails.SenderId = int.Parse(userId);
            if (ticketDetails.ticketId !=null & ticketDetails.massage!=null)
            {
            ticketService.AddTicketMassage(ticketDetails);
            }



            return RedirectToAction("AddTicketMassage", ticketDetails.ticketId);
        }



    }
}
