using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Domain.InterfacesRepository;
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
        #endregion



        public void CreateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                _ticketRepository.CreateTicket(ticket);
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

        public ICollection<Ticket> GetUserTickets(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            _ticketRepository.SaveChange();
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket!=null) {
            _ticketRepository.UpdateTicket(ticket);
            }
        }
    }
}
