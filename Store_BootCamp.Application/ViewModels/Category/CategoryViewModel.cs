using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }

    }
    public enum State {
    Success,
    failed
    }
}
