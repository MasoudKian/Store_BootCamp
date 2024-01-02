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
            var isEmail = _userRepository.GetAll().SingleOrDefault(e=>e.Email == email);
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

        public User LoginUser(LoginViewModel loginUser)
        {
            string hashPassword = PasswordHelper.EncodePasswordSha256(loginUser.Password);
            string email = loginUser.Email;

            var user = _userRepository.GetAll()
                .SingleOrDefault(u => u.Email == email && u.Password == hashPassword);

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


        #region User Panel

        public InformationUserProfileViewModel GetInformationUser(string email)
        {
            InformationUserProfileViewModel information = new();
            var user = _userRepository.GetUserByEmail(email);

            information.Fullname = user.Fullname;
            information.Email = user.Email;
            information.UserName = user.UserName;
            information.Wallet = 0;
            information.CreateDate = user.CreateDate;

            return information;
        }

        #endregion
    }
}
