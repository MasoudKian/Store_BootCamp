using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Domain.Models.Tickets;
using Store_BootCamp.Infra.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.ViewModels.Ticket
{
    public class TicketDetailsViewModel
    {
        public int ticketId { get; set; }
        public string title { get; set; }
        public int OwnerId { get; set; }
        public DateTime Date { get; set; }
        public string email { get; set; }
        public string massage { get; set; }
        public int SenderId { get; set; }
        public TicketState TicketState { get; set; }
        public ICollection<TicketMessage> ticketMessages { get; set; }
    }
}
