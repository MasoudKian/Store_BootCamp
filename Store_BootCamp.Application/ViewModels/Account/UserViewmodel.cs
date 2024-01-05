using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.ViewModels.Account
{
    public class UserViewmodel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "ایمیل خالی است")]
        public string email { get; set; }
        [Required(ErrorMessage = "نام کاربری خالی است")]

        public string username { get; set; }
        [Required(ErrorMessage = "نام و نام خانوادگی خالی است")]

        public string fullname { get; set; }

        public bool IsAdmin { get; set; }


        public string img { get; set; }

        public bool isActive { get; set; }
        [Required(ErrorMessage = "رمز عبور خالی است")]

        public string password { get; set; }
        [Required(ErrorMessage = "تکرار عبور خالی است")]

        [Compare("password",ErrorMessage = "تکرار رمز عبور اشتباهاست")]
        public string ConfirmPassword { get; set; }

    }
}
