using System.ComponentModel.DataAnnotations;

namespace Store_BootCamp.Domain.Models.Contacts
{
    public class ContactUsResponse : BaseEntity
    {
        [Display(Name = "جواب پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ResponseMessage { get; set; }

        #region Relations
        public ContactUs ContactUs { get; set; }
        #endregion
    }
}
