using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogParkTestPro.WebUI.Models;
using BlogParkTestPro.Model;
using BlogParkTestPro.BLL;

namespace BlogParkTestPro.WebUI.Controllers
{
    public class HomeController : Controller
    {
        MemberSimpleOperationBLL memberbll = new MemberSimpleOperationBLL();
        public ActionResult Index()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            UserModels model = new UserModels { username = "赵玉珍", password = "1234" };
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(UserModels model)
        {
            MemberInfo memberinfo = new MemberInfo();
            memberinfo.MemberName = model.username;
            memberinfo.LoginPassword = model.password;
            bool ischeck = memberbll.CheckMemberCanLogin(memberinfo);
            if (ischeck)
                return RedirectToAction("Index");
            else
            {
                model.password = "";
                return View(model); 
            }
        }
        protected override void HandleUnknownAction(string actionName)
        {
            Redirect("/Home/Login");
        }
    }
}
