using Store_BootCamp.Application.ViewModels.Ticket;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Domain.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.Services.Interfaces
{
    public interface ITicketService
    {
        public AddTicketResult AddTicket(TicketViewModel ticket,int userId);
        public State AddTicketMassage(TicketDetailsViewModel ticketDetails);
      

        public void Delete(int id);
        public ICollection<Ticket> GetAll();
        public void UpdateTicket(Ticket ticket);
        public Ticket GetById(int id);
        public User GetUserById(int id);
        public ICollection<TicketViewModel> GetUserTickets(int id);
        public TicketDetailsViewModel GetTicketDetails(int id);
       
        public void ChangeState(int id);
        public state CreateTickAdmin(AddTicketByAdminViewmodel addTicketByAdminViewmodel,int AdmiId);
        public void SaveChange();
    }
}
