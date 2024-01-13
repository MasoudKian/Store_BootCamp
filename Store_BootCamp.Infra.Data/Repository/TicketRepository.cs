using Microsoft.EntityFrameworkCore;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Domain.Models.Tickets;
using Store_BootCamp.Infra.Data.Context;
using Store_BootCamp.Infra.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Store_BootCamp.Infra.Data.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly StoreDBContext _dbContext;
        public TicketRepository(StoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMassage(TicketMessage ticket)
        {
          _dbContext.TicketMessages.Add(ticket);
                
        }

        public void AddTicketByAdmin(Ticket ticket, string txt,int AdminId)
        {
            var Admin = GetUserById(AdminId);
            if (txt != null)
            {
                var Massage = new TicketMessage();
                Massage.Text = txt;
                Massage.Ticket = ticket;
                Massage.SenderId =Admin.Id ;
                Massage.Sender = Admin;
                AddTicketMassage(Massage);
            }

            _dbContext.Add(ticket);


        }

        public void AddTicketMassage(TicketMessage ticket)
        {
         
            _dbContext.TicketMessages.Add(ticket);

        }

        public void ChangeState(int id)
        {
            var ticket=GetById(id);
            ticket.TicketState = (TicketState)2;
        }

        public void CreateTicket(Ticket ticket)
        {
      

            _dbContext.Add(ticket);

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

        public Ticket getTicketDetails(int id)
        {
            var ticket=_dbContext.Tickets.Include(a=>a.TicketMessages).ThenInclude(a=>a.Sender).Include(a=>a.Owner).Where(a=>a.Id==id).FirstOrDefault();
            return ticket;
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(a => a.Id == id);
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
