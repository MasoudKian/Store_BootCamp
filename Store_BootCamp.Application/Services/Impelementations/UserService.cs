using Store_BootCamp.Application.Convertor;
using Store_BootCamp.Application.Generators;
using Store_BootCamp.Application.Security;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.Account;
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
            var emailExist = _userRepository.GetAll().Where(e => e.Email == email);
            return emailExist.Any();
        }

        public User IsEmail(string email)
        {
            var isEmail = _userRepository.GetAll().Single(e=>e.Email == email);
            return isEmail;
        }
        public bool IsExistUserName(string userName)
        {
            var usernameExist = _userRepository.GetAll().Where(e => e.UserName == userName);
            return usernameExist.Any();
        }

        public int RegisterUser(User user)
        {

            var newUser = _userRepository.AddUser(user);
            return newUser;

        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public User LoginUser(LoginViewModel loginUser)
        {
            string hashPassword = PasswordHelper.EncodePasswordSha256(loginUser.Password);
            string email = loginUser.Email;

            var user = _userRepository.GetAll()
                .SingleOrDefault(u => u.Email == email && u.Password == hashPassword);

            return user;
        }

        public User GetUserByEmail(ForgotPasswordViewModel forgot)
        {
            string fixedEmail = FixedText.FixedEmail(forgot.Email);
            User user = _userRepository.GetUserByEmail(fixedEmail);

            return user;

        }

        public bool ActiveCode(string activeCode)
        {
            var user = _userRepository.GetAll()
                .SingleOrDefault(u=>u.ActiveEmailCode == activeCode);

            if (user == null || user.IsActive)
                return false;

            user.IsActive = true;
            user.ActiveEmailCode = NameGenerator.GenerateUniqEmailCode();
            _userRepository.SaveChange();

            return true;
        }

        public User GetUserByActiveCode(string activeCode)
        {
            var user = _userRepository.GetUserByActiveCode(activeCode);
            return user;
        }
    }
}
