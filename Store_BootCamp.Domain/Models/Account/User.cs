﻿using Store_BootCamp.Domain.Models.Contacts;
using System.ComponentModel.DataAnnotations;

namespace Store_BootCamp.Domain.Models.Account
{
    public class User : BaseEntity
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Fullname { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? UserName { get; set; }

        [Display(Name = "عکس کاربر")]
        public string? UserImage { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده معتبر نمی باشد")]
        public string? Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Password { get; set; }

        [Display(Name = "کد فعال سازی")]
        public string? ActiveEmailCode { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "ادمین است / ادمین نیست")]
        public bool IsAdmin { get; set; }


        #region Relations

        public ICollection<ContactUs> ContactUs { get; set; }

        #endregion

    }
}
