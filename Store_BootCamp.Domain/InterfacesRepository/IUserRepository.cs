using Store_BootCamp.Domain.Models.Account;

namespace Store_BootCamp.Domain.InterfacesRepository
{
    public interface IUserRepository
    {
        #region CRUD
        
        User GetById(int id);

        User GetUserByEmail(string email);

        int AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        IEnumerable<User> GetAll();

        #endregion

        void SaveChange();
    }
}
