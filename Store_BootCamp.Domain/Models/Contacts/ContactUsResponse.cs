using Store_BootCamp.Domain.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace Store_BootCamp.Domain.Models.Contacts
{
    public class ContactUsResponse : BaseEntity
    {
        [Display(Name = "پیغام جوابیه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ResponseMessage { get; set; }

        #region Relations
        public ContactUs ContactUs { get; set; }
        #endregion
    }
}
