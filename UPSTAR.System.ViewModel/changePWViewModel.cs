using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSTAR.System.ViewModel
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public class changePWViewModel
    {
        [Required(ErrorMessage = "原密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "原密码")]
        public string oldPw { get; set; }

        [Required(ErrorMessage = "新密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        [MinLength(6, ErrorMessage = "最小长度6位")]
        [MaxLength(20, ErrorMessage = "最大长度6位")]
        public string newPw { get; set; }

        [Required(ErrorMessage = "确认密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "确　认")]
        [Compare("newPw", ErrorMessage = "密码必须一致")]
        [MinLength(6, ErrorMessage = "最小长度6位")]
        [MaxLength(20, ErrorMessage = "最大长度6位")]
        public string confirmPw { get; set; }
    }
}
