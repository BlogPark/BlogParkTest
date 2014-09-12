using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BlogParkTestPro.Model;

namespace BlogParkTestPro.WebUI.Models
{
    public class RightMenuViewModel
    {
        /// <summary>
        /// 博文类别
        /// </summary>
        public List<LogCategory> CategoryList { get; set; }
        /// <summary>
        /// 博客排行
        /// </summary>
        public DataTable TopMemberUserTable { get; set; }
    }
}