using Store_BootCamp.Application.ViewModels.Account;
using Store_BootCamp.Domain.Models.Account;

namespace Store_BootCamp.Application.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        User IsEmail(string email);
        int RegisterUser(User user);
        User LoginUser(LoginViewModel loginUser);
        bool ActiveCode(string activeCode);
    }
}
