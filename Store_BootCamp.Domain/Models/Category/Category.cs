using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Domain.Models.Category
{
    public class Category
    {
        public int id   { get; set; }
        [Required(ErrorMessage ="عنوان دسته بندی خالی است")]
        public string Title { get; set; }

        public int? ParentsId { get; set; }
    }
    public enum state { 
    success,
    failed,
    }
}
