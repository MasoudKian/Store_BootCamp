using Store_BootCamp.Domain.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace Store_BootCamp.Domain.Models.Tickets
{
    public class TicketMessage : BaseEntity
    {
        #region properties

        public long TicketId { get; set; }

        public long SenderId { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

        #endregion

        #region relations

        public Ticket Ticket { get; set; }

        public User Sender { get; set; }

        #endregion
    }
}
