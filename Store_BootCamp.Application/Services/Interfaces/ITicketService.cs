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
        public void CreateTicket(Ticket ticket);
        public void Delete(int id);
        public ICollection<Ticket> GetAll();
        public void UpdateTicket(Ticket ticket);
        public Ticket GetById(int id);
        public ICollection<Ticket> GetUserTickets(int id);
        public void SaveChange();
    }
}
