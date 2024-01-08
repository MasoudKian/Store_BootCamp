using Store_BootCamp.Domain.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.ViewModels.Ticket
{
    public class TicketViewModel
    {
        public string Title { get; set; }
        public DateTime dateTime { get; set; }
        public TicketSection TicketSection { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketState TicketState { get; set; }
    }
}
