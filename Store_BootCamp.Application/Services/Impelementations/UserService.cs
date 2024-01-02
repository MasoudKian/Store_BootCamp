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
    }
}
