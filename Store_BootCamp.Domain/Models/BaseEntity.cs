using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("تاریخ ثبت نام")]
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
