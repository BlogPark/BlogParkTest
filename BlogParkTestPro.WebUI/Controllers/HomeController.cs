using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogParkTestPro.WebUI.Models;
using BlogParkTestPro.Model;
using BlogParkTestPro.BLL;
using BlogParkTestPro.Common;

namespace BlogParkTestPro.WebUI.Controllers
{
    public class HomeController : Controller
    {
        MemberSimpleOperationBLL memberbll = new MemberSimpleOperationBLL();
        MenusOperateBLL menubll = new MenusOperateBLL();

        public ActionResult Index()
        {
            ViewBag.Message = "";
            IndexViewModel model = new IndexViewModel();
            model.TopMenutable = menubll.GetMenuListByPagePosition(1, (int)WebPositionEnum.TopMenuBar);
            model.TabMenutable = menubll.GetMenuListByPagePosition(1, (int)WebPositionEnum.TabList);
            return View(model);
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
        //[AllowAnonymous]
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
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
        [AllowAnonymous]
        public ActionResult Login(UserModels model)
        {
            if (model.Verification != Session["ValidateCode"].ToString())
            {
                ModelState.AddModelError("Verification", "验证码不正确");
                return View(model);
            }
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
            if (ModelState.IsValid)
            {
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
                    bCookie.Value = HttpUtility.UrlEncode(ischeck.Nickname.ToString());
                    bCookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(aCookie);
                    Response.Cookies.Add(bCookie);
                    ischeck = (MemberInfo)Session["loguser"];
                    return RedirectToAction("Index");
                }
                else
                {
                    model.password = "";
                    return View(model);
                }
            }
            else
                return View(model);
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
        [ValidateAntiForgeryToken]
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
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadImg()
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files["file1"];
            if (file != null && file.ContentLength > 0)
            {
                string fileName = file.FileName;
                //判断文件名字是否包含路径名，如果有则提取文件名
                if (fileName.LastIndexOf("\\") > -1)
                {
                    fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                }
                //判断文件格式，这里要求是JPG格式
                if (fileName.LastIndexOf('.') > -1)//&& fileName.Substring(fileName.LastIndexOf('.')).ToUpper() == ".JPG"))
                {
                    string path = Server.MapPath("~/Upload/");
                    try
                    {
                        file.SaveAs(path + fileName);
                        ViewBag.message = "/Upload/" + fileName; 
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                else
                {
                    ViewBag.message = "上传的文件格式不符合要求！";
                }
            }
            else
            {
                ViewBag.message = "上传的文件是空文件！";
            }
            return View("Index");
        }

        public ActionResult Upload(HttpPostedFileBase Filedata)
        {
            // 如果没有上传文件
            if (Filedata == null ||
                string.IsNullOrEmpty(Filedata.FileName) ||
                Filedata.ContentLength == 0)
            {
                return this.HttpNotFound();
            }

            // 保存到 ~/photos 文件夹中，名称不变
            string filename = System.IO.Path.GetFileName(Filedata.FileName);
            string virtualPath =
                string.Format("~/Upload/{0}", filename);
            // 文件系统不能使用虚拟路径
            string path = this.Server.MapPath(virtualPath);

            Filedata.SaveAs(path);
            ViewBag.message =virtualPath; 
            return this.Json(new { });
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var name = HttpContext.User.Identity.Name;
            base.OnActionExecuted(filterContext);
            ViewBag.Relationship = menubll.GetMenuListByPagePosition(1, (int)WebPositionEnum.TopMenuBar);
        }
    }
}
