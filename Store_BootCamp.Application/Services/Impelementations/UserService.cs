using Store_BootCamp.Application.Interfaces;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;

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

        public int CreateUser(User user)
        {
            var newUser= _userRepository.AddUser(user);
            return newUser;

        }
    }
}
