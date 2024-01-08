using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Tickets;
using Store_BootCamp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Infra.Data.Repository
{
    public class TicketRepository:ITicketRepository
    {
        private readonly StoreDBContext _dbContext;
        public TicketRepository(StoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void CreateTicket(Ticket ticket)
        {
            if (ticket != null) {
               _dbContext.Add(ticket);
            }
        }

        public void Delete(int id)
        {
            var ticket = GetById(id);
            ticket.IsDelete = true;            
        }

        public ICollection<Ticket> GetAll()
        {
            var tickets = _dbContext.Tickets.ToList();
            return tickets;
        }

        public Ticket GetById(int id)
        {
            var ticket = _dbContext.Tickets.FirstOrDefault(a=>a.Id==id);
            return ticket;
        }

        public ICollection<Ticket> GetUserTickets(int id)
        {
            var UserTickets = _dbContext.Tickets.Where(a => a.OwnerId == id).ToList();
            return UserTickets;
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
        }
    }
}
