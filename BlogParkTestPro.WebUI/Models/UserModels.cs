using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlogParkTestPro.WebUI.Models
{
    public class UserModels
    {
        [Required(ErrorMessage = "用户名必填")]
        public string username { get; set; }
        [Required(ErrorMessage = "密码必填")]
        public string password { get; set; }

        //[Compare("password",ErrorMessage="两次输入密码不一致")]
        public string confirmpassword { get; set; }

        //[EmailAddressAttribute(ErrorMessage="邮箱地址不正确")]
        public string email { get; set; }
        public bool isnextautologin { get; set; }

        //[StringLength(20,MinimumLength=5,ErrorMessage="昵称必须大于五个字符")]
        public string nickname { get; set; }
        [Required(ErrorMessage = "验证码必填")]
        public string Verification { get; set; }
    }
}