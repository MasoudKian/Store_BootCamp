using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Infra.Data.Context;

namespace Store_BootCamp.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Constructor

        private readonly StoreDBContext _dbContext;
        public UserRepository(StoreDBContext context)
        {
            _dbContext = context;
        }

        #endregion

        #region CRUD



        #endregion
    }
}
