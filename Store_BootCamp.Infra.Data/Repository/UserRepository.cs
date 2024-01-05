using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Infra.Data.Context;

namespace Store_BootCamp.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Constructor

        private readonly string wwwrootDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads");
        private readonly StoreDBContext _dbContext;
        public UserRepository(StoreDBContext context)
        {
            _dbContext = context;
        }


        #endregion


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
            //var  imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(user.UserImage.FileName);
            //user.UserImage.AddImageToServer(imageName, PathTool.ProductImageUploadPath, null, null);

            _dbContext.Add(user);
            user.CreateDate = DateTime.Now;
            _dbContext.SaveChanges();
            return user.Id;
        }
        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
        }

        public void DeleteUser(int id)
        {
            User user = GetById(id);
            user.IsDelete = true;
            UpdateUser(user);
        }

        public User GetUserByActiveCode(string activeCode)
        {
            var userActiveCode = _dbContext.Users.SingleOrDefault(u => u.ActiveEmailCode == activeCode);
            return userActiveCode;
        }


        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public void FullDeletUser(int id)
        {
            var user = GetById(id);
            _dbContext.Users.Remove(user);
        }

        public void EditUser(User user)
        {
         

            _dbContext.Users.Update(user);
        }

      
    }
}
