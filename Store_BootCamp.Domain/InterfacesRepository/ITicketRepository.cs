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
        public void AddTicket();
        public User GetuserByEmail(string email);

    }
}
