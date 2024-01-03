using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;
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

        #region CRUD User 

        public User GetById(int id)
        {
            var userId = _dbContext.Users.Find(id);
            return userId;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _dbContext.Users.ToList();
            return users;
        }

        public User GetUserByEmail(string email)
        {
            var emailUser = _dbContext.Users.SingleOrDefault(u => u.Email == email);
            return emailUser;
        }
        public int AddUser(User user)
        {
            _dbContext.Add(user);
            user.CreateDate = DateTime.Now;
            _dbContext.SaveChanges();
            return user.Id;
        }
        public void UpdateUser(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges(true);
        }

        public void DeleteUser(int id)
        {
            User user = GetById(id);
            user.IsDelete = true;
            UpdateUser(user);
        }

        #endregion

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}
