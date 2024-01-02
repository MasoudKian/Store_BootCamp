using Store_BootCamp.Application.Interfaces;
using Store_BootCamp.Domain.InterfacesRepository;

namespace Store_BootCamp.Application.Services.Impelementations
{
    
    public class UserService : IUserService
    {
        #region Constructor

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        public bool IsExistEmail(string email)
        {
            var emailExist = _userRepository.GetAll().Where(e=>e.Email == email);
            return emailExist.Any();
        }

        public bool IsExistUserName(string userName)
        {
            var usernameExist = _userRepository.GetAll().Where(e => e.UserName == userName);
            return usernameExist.Any();
        }
    }
}
