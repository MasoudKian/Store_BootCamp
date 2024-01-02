using Store_BootCamp.Application.ViewModels.Account;

namespace Store_BootCamp.Application.Services.Interfaces
{
    public interface IUserPanelService
    {
        ProfileInformationUserViewModel GetInformationUser(string email);
    }
}
