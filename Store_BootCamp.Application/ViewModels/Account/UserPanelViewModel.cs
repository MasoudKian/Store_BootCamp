using System.ComponentModel.DataAnnotations;

namespace Store_BootCamp.Application.ViewModels.Account
{
    public class InformationUserProfileViewModel
    {

        public string Fullname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

        public int Wallet { get; set; }
    }
}
