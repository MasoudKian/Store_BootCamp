using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.ViewModels.Account
{
    public class UserViewmodel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string img { get; set; }
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
    }
}
