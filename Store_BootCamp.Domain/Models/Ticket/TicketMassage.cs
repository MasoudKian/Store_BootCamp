using Microsoft.VisualBasic;
using Store_BootCamp.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Domain.Models.Ticket
{
    public class TicketMassage
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Sender")]
        public int? SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("TicketFor")]
        public int? TicketForId { get; set; }
        public Ticket TicketFor { get; set; }

        public string message { get; set; }
        public DataSetDateTime  DateAndTime { get; set; }

    }
}
