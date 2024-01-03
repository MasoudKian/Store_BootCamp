using Store_BootCamp.Domain.Models.Account;

namespace Store_BootCamp.Domain.InterfacesRepository
{
    public interface IUserRepository
    {

        
        User GetById(int id);

        int AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        IEnumerable<User> GetAll();

        User GetUserByEmail(string email);

        User GetUserByActiveCode(string activeCode);

        void SaveChange();
    }
}
