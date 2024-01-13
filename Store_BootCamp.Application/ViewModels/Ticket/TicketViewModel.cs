using Store_BootCamp.Domain.Models.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.ViewModels.Ticket
{
    public class TicketViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public DateTime dateTime { get; set; }
        public TicketSection TicketSection { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketState TicketState { get; set; }
        public int OwnerId { get; set; }
        public string Text { get; set; }
    }

    public enum AddTicketResult {
    Success,
    Failed,

    }

}
