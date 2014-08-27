using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BlogParkTestPro.Model;
using BlogParkTestPro.BLL;

namespace BlogParkTestPro.WebUI.Controllers
{
    public class BlogArtcleController : Controller
    {
        BlogArticlesOperateBLL bll = new BlogArticlesOperateBLL();
        CategoryOperateBLL categorybll = new CategoryOperateBLL();
        public ActionResult AddBlogArtcle()
        {
            BlogArticles model = new BlogArticles();
            if (Request.Cookies["loginid"] != null)
            {
                List<EssayCategory> ca = categorybll.GetEssayCategoryByMemberid(int.Parse(Request.Cookies["loginid"].Value.ToString()));
                List<SelectListItem> listClass = new List<SelectListItem>();
                foreach (EssayCategory item in ca)
                {
                    SelectListItem se = new SelectListItem();
                    se.Text = item.EssayCategoryName;
                    se.Value = item.ID.ToString();
                    listClass.Add(se);
                }
                
                ViewData.Model = new SelectList(listClass, "ID", "EssayCategoryName", "---请选择---");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlogArtcle(BlogArticles model)
        {
            if (Request.Cookies["loginid"] != null)
            { model.CreaterID = int.Parse(Request.Cookies["loginid"].Value.ToString()); }
            if (Request.Cookies["loginuser"] != null)
            { model.CreaterName = HttpUtility.UrlDecode(Request.Cookies["loginuser"].Value.ToString()); }
            bool issuccess = bll.InsertBlogArticle(model);
            return View(model);
        }
    }
}
