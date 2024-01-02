using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.Account;
using Store_BootCamp.Domain.InterfacesRepository;

namespace Store_BootCamp.Application.Services.Impelementations
{
    public class UserPanelService : IUserPanelService
    {
        #region Constructor

        private readonly IUserRepository _userRepository;
        public UserPanelService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        public ProfileInformationUserViewModel GetInformationUser(string email)
        {
            var user = _userRepository.GetUserByEmail(email);

            ProfileInformationUserViewModel information = new();
            information.Fullname = user.Fullname;
            information.UserName = user.UserName;
            information.Email = email;
            information.CreateDate = user.CreateDate;
             
            return information;

        }
    }
}
