using System.ComponentModel.DataAnnotations;

namespace Store_BootCamp.Application.ViewModels.ContactUs
{
    public class ReplyViewModel
    {
        public int? UserId { get; set; }

        public string? UserEmail { get; set; }

        [Display(Name = "عنوان پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? ReplyTitle { get; set; }

        [Display(Name = "متن پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? ReplyMessage { get; set; }
    }

}
