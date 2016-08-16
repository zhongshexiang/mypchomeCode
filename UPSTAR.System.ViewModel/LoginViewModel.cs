using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSTAR.System.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name = "用户名")]
        [MaxLength(100, ErrorMessage = "最大长度100")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Required(ErrorMessage = "验证码不能为空")]
        [Display(Name = "验证码")]
        public string CheckCode { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }

        public string IP { get; set; }

        public string City { get; set; }
    }
}
