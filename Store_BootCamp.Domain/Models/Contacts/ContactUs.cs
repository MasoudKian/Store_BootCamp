using Store_BootCamp.Domain.Models.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store_BootCamp.Domain.Models.Contacts
{
    public class ContactUs : BaseEntity
    {
        #region properties
        public int? UserId { get; set; }

        [Display(Name = "IP کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? UserIp { get; set; }

        public int? ResponseId { get; set; } 

        [Display(Name = "موضوع تیکت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Title { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Email { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Phone { get; set; }

        [Display(Name = "متن تیکت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? Description { get; set; }

        [Display(Name ="فایل")]
        public string? FileTicket { get; set; }

        #endregion

        #region Relations

        public User User { get; set; }

        public ContactUsResponse Response { get; set; }

        #endregion
    }
}
