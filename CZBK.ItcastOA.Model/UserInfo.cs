using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Model
{
    public class UserInfo
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20)]
        [Required]
        public string UserName { get; set; }
        [MaxLength(100)]
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsDelete { get; set; }

    }
}
