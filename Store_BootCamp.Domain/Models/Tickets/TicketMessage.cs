using Store_BootCamp.Domain.Models.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store_BootCamp.Domain.Models.Tickets
{
    public class TicketMessage : BaseEntity
    {
        #region properties

        public int TicketId { get; set; }

        public int SenderId { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

        #endregion

        #region relations

        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        #endregion
    }
}
