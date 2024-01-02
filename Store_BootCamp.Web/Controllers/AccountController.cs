using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Convertor;
using Store_BootCamp.Application.Generators;
using Store_BootCamp.Application.Interfaces;
using Store_BootCamp.Application.Security;
using Store_BootCamp.Application.ViewModels.Account;
using Store_BootCamp.Domain.Models.Account;

namespace Store_BootCamp.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Constructor
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if(!ModelState.IsValid)
                return View(register);

            //if (_userService.IsExistEmail(FixedText.FixedEmail(register.Email)) 
            //    || _userService.IsExistUserName(FixedText.FixedUserName(register.UserName)))
            //{
            //    ModelState.AddModelError("Email", "ایمیل یا نام کاربری وارد شده معتبر نمی باشد");
            //}

            if (_userService.IsExistEmail(FixedText.FixedEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده معتبر نمی باشد");
                return View(register);
            }


            User user = new()
            {
                Fullname = register.Fullname,
                UserName = FixedText.FixedUserName(register.UserName),
                Email = FixedText.FixedEmail(register.Email),
                Password = PasswordHelper.EncodePasswordSha256(register.Password),
                ActiveEmailCode = NameGenerator.GenerateUniqEmailCode(),
                UserImage = "Defualt.png"


            };
            _userService.CreateUser(user);

            // Activation Email


            return View("SuccessRegister", user);
        }
    }
}
