using System.ComponentModel.DataAnnotations;

namespace Store_BootCamp.Application.ViewModels.ContactUs
{
    public class ReplyViewModel
    {
        public int ContactUsId { get; set; }

        public string Email { get; set; }

        [Display(Name = "پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ResponseMessage { get; set; }
    }

}
