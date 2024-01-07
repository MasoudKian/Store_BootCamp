using Microsoft.EntityFrameworkCore;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Domain.Models.Contacts;
using Store_BootCamp.Domain.Models.Ticket;

namespace Store_BootCamp.Infra.Data.Context
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base (options)
        {
                
        }

        #region Dbset

        #region Account
        public DbSet<User> Users { get; set; }
        #endregion

        #region Contact Us
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<ContactUsResponse>  ContactUsResponses { get; set; }

        #endregion

        public DbSet<Ticket> tickets { get; set; }
        public DbSet<TicketMassage> ticketsMassage{ get; set; }

        #endregion
    }
}
