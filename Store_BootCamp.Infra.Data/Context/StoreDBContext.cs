using Microsoft.EntityFrameworkCore;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Domain.Models.Category;
using Store_BootCamp.Domain.Models.Contacts;
using Store_BootCamp.Domain.Models.Tickets;

namespace Store_BootCamp.Infra.Data.Context
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        #region Dbset

        #region Account
        public DbSet<User> Users { get; set; }
        #endregion

        #region Contact Us
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<ContactUsResponse> ContactUsResponses { get; set; }

        #endregion
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        public DbSet<Category> categories { get; set; }



        #endregion
    }

}
