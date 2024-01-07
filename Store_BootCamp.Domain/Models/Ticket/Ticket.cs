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
    public class Ticket
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public User Owner { get; set; }

        public bool IsClosed { get; set; }
        public string  dateTime { get; set; }

        public ICollection<TicketMassage> massages { get; set; }
    }

}
