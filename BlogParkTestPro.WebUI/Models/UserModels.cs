using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlogParkTestPro.WebUI.Models
{
    public class UserModels
    {
        [Required(ErrorMessage="用户名必填")]
        public string username { get; set; }
        [Required(ErrorMessage="密码必填")]
        public string password { get; set; }
        [Required(ErrorMessage="请再次确认密码")]
        [Compare("password",ErrorMessage="两次输入密码不一致")]
        public string confirmpassword { get; set; }
        public string email { get; set; }
        public bool isnextautologin { get; set; }
    }
}