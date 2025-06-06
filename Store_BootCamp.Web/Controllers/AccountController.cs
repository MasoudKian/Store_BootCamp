﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Convertor;
using Store_BootCamp.Application.Generators;
using Store_BootCamp.Application.Security;
using Store_BootCamp.Application.ViewModels.Account;
using Store_BootCamp.Domain.Models.Account;
using System.Security.Claims;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.Senders;

namespace Store_BootCamp.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Constructor
        private readonly IUserService _userService;
        private readonly IViewRenderService _viewRender;

        public AccountController(IUserService userService,IViewRenderService viewRender)
        {
            _userService = userService;
            _viewRender = viewRender;
        }
        #endregion

        #region Register

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);

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
            _userService.RegisterUser(user);

            #region Send Activation Email

            string body = _viewRender.RenderToStringAsync("_ActiveEmail",user);
            SendEmail.Send(user.Email,"فعال سازی",body);

            #endregion


            return View("SuccessRegister", user);
        }
        #endregion

        #region Login

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userService.LoginUser(login);

            if (user != null)
            {
                var email = _userService.IsEmail(login.Email);
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Email,email.Email),
                        new Claim(ClaimTypes.Name,user.Fullname),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var pricipal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };

                    HttpContext.SignInAsync(pricipal, properties);
                    return Redirect("/Profile");
                }
                else
                {
                    ModelState.AddModelError("Email", " حساب کاربری شما فعال نمی باشد ! ");
                }
            }
            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد ! ");

            return View(login);
        }

        #endregion

        #region Active Account


        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = _userService.ActiveCode(id);
            return View();
        }

        #endregion

        #region Forgot Password

        [HttpGet("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid) return View(forgot);

            var user = _userService.GetUserByEmail(forgot);

            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربر یافت نشد ! ");
            }

            // Send Email
            string bodyEmail = _viewRender.RenderToStringAsync("_ForgotPassword", user);
            SendEmail.Send(user.Email,"بازیابی حساب کاربری",bodyEmail);
            ViewBag.IsSuccess = true;   

            return View();
        }


        #endregion

        #region Reset Password

        
        public IActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordViewModel()
            {
                ActiveCode = id,
            });
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel reset)
        {
            if (!ModelState.IsValid) return View(reset);

            User user = _userService.GetUserByActiveCode(reset.ActiveCode);
            if (user == null) return NotFound();

            string hashNewPass = PasswordHelper.EncodePasswordSha256(reset.Password);
            user.Password = hashNewPass;
            _userService.UpdateUser(user);

            return Redirect("/Login");
        }

        #endregion

        #region Logout

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion
    }
}
