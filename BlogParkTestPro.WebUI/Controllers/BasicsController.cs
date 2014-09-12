using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BlogParkTestPro.Model;
using BlogParkTestPro.WebUI.Models;
using BlogParkTestPro.BLL;

namespace BlogParkTestPro.WebUI.Controllers
{
    /// <summary>
    /// 此控制器获取网站基础数据
    /// </summary>
    public class BasicsController : Controller
    {
        /// <summary>
        /// 得到友情链接
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowFriendLink()
        {
            return PartialView("");
        }
    }
}
