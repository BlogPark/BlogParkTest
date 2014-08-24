using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogParkTestPro.Model;
using BlogParkTestPro.BLL;

namespace BlogParkTestPro.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        CategoryOperateBLL bll = new CategoryOperateBLL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryList4()
        {
            List<LogCategory> models = bll.GetMinCategory();
            return PartialView("_CategoryList", models);
        }
    }
}
