using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Infra.Data.Context;
using System;
using System.Collections.Generic;
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
        public void AddTicket()
        {

        }

        public User GetuserByEmail(string email)
        {
            var currentUser=_dbContext.Users.FirstOrDefault(x => x.Email == email);
            return currentUser;
        }
    }
}
