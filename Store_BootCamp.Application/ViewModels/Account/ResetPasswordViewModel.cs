using System.ComponentModel.DataAnnotations;

namespace Store_BootCamp.Application.ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        public string ActiveCode { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "لطفا کلمه عبور یکسان وارد کنید")]
        public string RePassword { get; set; }
    }
}
