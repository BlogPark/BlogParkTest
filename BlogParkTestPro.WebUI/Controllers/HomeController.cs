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
            UserModels model = new UserModels();
            if (Request.Cookies["lastVisit"] != null)
                model.username = Request.Cookies["lastVisit"].Value.ToString();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(UserModels model)
        {
            if (model.isnextautologin)
            {
                HttpCookie aCookie = new HttpCookie("lastVisit");
                aCookie.Value = model.username;
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);
            }
            else
            {
                HttpCookie aCookie = new HttpCookie("lastVisit");
                aCookie.Value = "";
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }
            MemberInfo memberinfo = new MemberInfo();
            memberinfo.MemberName = model.username;
            memberinfo.LoginPassword = model.password;
            MemberInfo ischeck = memberbll.CheckMemberCanLogin(memberinfo);
            if (ischeck != null)
            {
                System.Web.HttpContext.Current.Session["loguser"] = ischeck;
                HttpCookie aCookie = new HttpCookie("loginid");
                aCookie.Value = ischeck.MemberID.ToString();
                aCookie.Expires = DateTime.Now.AddHours(1);
                HttpCookie bCookie = new HttpCookie("loginuser");
                bCookie.Value = HttpUtility.UrlEncode( ischeck.Nickname.ToString());
                bCookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(aCookie);
                Response.Cookies.Add(bCookie);
                return RedirectToAction("Index");
            }
            else
            {
                model.password = "";
                return View(model);
            }
        }
        /// <summary>
        /// 注册页
        /// </summary>
        /// <returns></returns>
        public ActionResult RegistrationPage()
        {
            UserModels model = new UserModels();
            return View(model);
        }
        /// <summary>
        /// 注册页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RegistrationPage(UserModels model)
        {
            if (ModelState.IsValid)
            {
                MemberInfo usermodel = new MemberInfo();
                usermodel.MemberName = model.username;
                usermodel.MemberEmail = model.email;
                usermodel.LoginPassword = model.confirmpassword;
                usermodel.Nickname = model.nickname;
                if (memberbll.InsertMemberUserforRegistration(usermodel))
                    return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("username", "注册失败");
                    return View(model);
                }
            }
            else
                return View(model);
        }
        protected override void HandleUnknownAction(string actionName)
        {
            Redirect("/Home/Login");
        }
    }
}
