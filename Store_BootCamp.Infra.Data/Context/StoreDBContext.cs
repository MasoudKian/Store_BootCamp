using Microsoft.EntityFrameworkCore;
using Store_BootCamp.Domain.Models.Account;

namespace Store_BootCamp.Infra.Data.Context
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base (options)
        {
                
        }

        #region Dbset

        public DbSet<User> Users { get; set; }

        #endregion
    }
}
