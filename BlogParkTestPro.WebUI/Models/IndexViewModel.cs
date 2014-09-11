using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BlogParkTestPro.WebUI.Models
{
    public class IndexViewModel
    {
        /// <summary>
        /// 首页顶部菜单
        /// </summary>
        public DataTable TopMenutable { get; set; }
        /// <summary>
        /// 首页选项卡菜单
        /// </summary>
        public DataTable TabMenutable { get; set; }
        /// <summary>
        /// 首页博文列表
        /// </summary>
        public DataTable BlogArtcleList { get; set; }
    }
}