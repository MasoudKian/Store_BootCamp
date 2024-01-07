using Store_BootCamp.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Domain.InterfacesRepository
{
    public interface ITicketRepository
    {
        public void AddTicket(int id,string time);
        public void closeTicket(int ticketId);
        public void deleteTicket(int ticketId);
        public User getUserById(int Id);

    }
}
