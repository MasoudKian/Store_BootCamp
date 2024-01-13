using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.Ticket;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Domain.Models.Tickets;
using Store_BootCamp.Infra.Data.Migrations;
using Store_BootCamp.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Store_BootCamp.Application.Services.Impelementations
{
    public class TicketService : ITicketService
    {
        #region ctor
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;
        public TicketService(ITicketRepository ticket, IUserRepository userRepository)
        {
            _ticketRepository = ticket;
            _userRepository = userRepository;
        }

        #endregion

        //      if (text != null)
        //    {
        //        var Massage = new TicketMessage();
        //Massage.Text = text;
        //        Massage.Ticket = ticket;
        //        Massage.SenderId = ticket.OwnerId;
        //        AddTicketMassage(Massage);
        //}

        public AddTicketResult AddTicket(TicketViewModel ticket)
        {
            if (ticket == null)
            {
                return AddTicketResult.Failed;
            }
            var newTicket = new Ticket
            {
                Title = ticket.Title,
                CreateDate = DateTime.Now,
                TicketPriority = ticket.TicketPriority,
                TicketState = ticket.TicketState,
                TicketSection = ticket.TicketSection,
                OwnerId = ticket.OwnerId,
            };

            _ticketRepository.CreateTicket(newTicket);
            SaveChange();
            var newTicketMassage = new TicketMessage
            {
                Text = ticket.Text,
                CreateDate = DateTime.Now,
                SenderId = ticket.OwnerId,
                TicketId = newTicket.Id,

            };
            _ticketRepository.AddMassage(newTicketMassage);
            SaveChange();
            return AddTicketResult.Success;
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

        public TicketDetailsViewModel GetTicketDetails(int id)
        {
            var tickets = _ticketRepository.getTicketDetails(id);
            var ticketViewmodel = new TicketDetailsViewModel();
            ticketViewmodel.title = tickets.Title;
            ticketViewmodel.ticketMessages = tickets.TicketMessages;
            ticketViewmodel.Date = tickets.CreateDate;
            ticketViewmodel.ticketId = tickets.Id;
            ticketViewmodel.TicketState = tickets.TicketState;
            ticketViewmodel.OwnerId = tickets.OwnerId;
            return ticketViewmodel;
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
                TicketM.TicketPriority = ticket.TicketPriority;
                TicketM.TicketSection = ticket.TicketSection;
                TicketM.Title = ticket.Title;
                TicketM.dateTime = ticket.CreateDate;
                TicketM.TicketState = ticket.TicketState;
                TicketM.id = ticket.Id;
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

        public void AddTicketMassage(TicketDetailsViewModel massage)
        {
            var NewMassage = new TicketMessage
            {
                SenderId = massage.SenderId,
                TicketId = massage.ticketId,
                Text = massage.massage,
            };

            _ticketRepository.AddTicketMassage(NewMassage);
            SaveChange();
        }

        public void ChangeState(int id)
        {
            _ticketRepository.ChangeState(id);
        }

        public void CreateTickAdmin(AddTicketByAdminViewmodel Viewmodel, string txt, int AdminId)
        {
            var user = _userRepository.GetById(Viewmodel.OwnerId);
            var ticket = new Ticket();
            ticket.Title = Viewmodel.Title;
            ticket.TicketState = Viewmodel.TicketState;
            ticket.TicketSection = Viewmodel.TicketSection;
            ticket.TicketPriority = Viewmodel.TicketPriority;
            ticket.CreateDate = DateTime.Now;
            ticket.Owner = user;

            if (ticket != null)
            {
                _ticketRepository.AddTicketByAdmin(ticket, txt, AdminId);
            }

        }


    }
}
