using Store_BootCamp.Domain.Models.Account;

namespace Store_BootCamp.Application.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);

        int CreateUser(User user);
    }
}
