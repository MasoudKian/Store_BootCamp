using Microsoft.VisualBasic;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Domain.Models.Ticket;
using Store_BootCamp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Infra.Data.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly StoreDBContext _dbContext;
        public TicketRepository(StoreDBContext storeDBContext)
        {
            _dbContext = storeDBContext;
        }
        public void AddTicket(int id)
        {
            var Ticket=new Ticket();
            var user = getUserById(id);
            if (user != null){
              Ticket.Owner = user;
            }
        }

        public User getUserById(int Id)
        {
            var user= _dbContext.Users.FirstOrDefault(x => x.Id == Id);
            return user;
        }
    }
}
