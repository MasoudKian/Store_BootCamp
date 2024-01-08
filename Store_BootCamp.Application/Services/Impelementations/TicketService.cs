using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.Ticket;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Domain.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.Services.Impelementations
{
    public class TicketService : ITicketService
    {
        #region ctor
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticket)
        {
            _ticketRepository = ticket;
        }

        public void AddTicketMassage(TicketMessage ticket)
        {
            throw new NotImplementedException();
        }
        #endregion



        public void CreateTicket(Ticket ticket, string txt)
        {
            if (ticket != null)
            {
                _ticketRepository.CreateTicket(ticket, txt);
            }
        }

        public void Delete(int id)
        {
            if (id != null)
            {
                _ticketRepository.Delete(id);
            }
        }

        public ICollection<Ticket> GetAll()
        {
            return _ticketRepository.GetAll();
        }

        public Ticket GetById(int id)
        {
            return _ticketRepository.GetById(id);

        }

        public User GetUserById(int id)
        {
            return _ticketRepository.GetUserById(id);
        }

        public ICollection<TicketViewModel> GetUserTickets(int id)
        {
            var UserTickets = new List<TicketViewModel>();
            foreach (var ticket in _ticketRepository.GetUserTickets(id))
            {
                var TicketM = new TicketViewModel();
                TicketM.TicketPriority  = ticket.TicketPriority;
                TicketM.TicketSection   = ticket.TicketSection;
                TicketM.Title = ticket.Title;
                TicketM.dateTime = ticket.CreateDate;
                TicketM.TicketState = ticket.TicketState;
                UserTickets.Add(TicketM);
            }
            return UserTickets;
        }

        public void SaveChange()
        {
            _ticketRepository.SaveChange();
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                _ticketRepository.UpdateTicket(ticket);
            }
        }
    }
}
