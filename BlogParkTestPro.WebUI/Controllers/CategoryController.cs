using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogParkTestPro.Model;
using BlogParkTestPro.BLL;
using BlogParkTestPro.WebUI.Models;

namespace BlogParkTestPro.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        CategoryOperateBLL bll = new CategoryOperateBLL();
        MemberSimpleOperationBLL memberbll = new MemberSimpleOperationBLL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryList()
        {
            RightMenuViewModel model = new RightMenuViewModel();
            model.CategoryList = bll.GetAllCategory();//读取类别
            model.TopMemberUserTable = memberbll.GetMemberUserOrderByBlongCount();//读取排行
            return PartialView("_CategoryList", model);
        }
        public ActionResult GetSubCategoryList(int id)
        {
            List<LogCategory> models = bll.GetSubCategory(id);
            return PartialView("_CategoryList", models);
        }
        public ActionResult GetEssayCategoryListByUser(int userid)
        {
            List<EssayCategory> goery = bll.GetEssayCategoryByMemberid(userid);
            return Json(goery);
        }
    }
}
