using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BlogParkTestPro.Model;
using BlogParkTestPro.BLL;
using Webdiyer.WebControls.Mvc;

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
                ViewData["UserCategoryID"] = new SelectList(ca, "ID", "EssayCategoryName","-请选择-");
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlogArtcle(BlogArticles model)
        {
            if (Request.Cookies["loginid"] != null)
            {
                model.CreaterID = int.Parse(Request.Cookies["loginid"].Value.ToString());
                List<EssayCategory> ca = categorybll.GetEssayCategoryByMemberid(int.Parse(Request.Cookies["loginid"].Value.ToString()));
                ViewData["UserCategoryID"] = new SelectList(ca, "ID", "EssayCategoryName", "-请选择-");
            }
            if (Request.Cookies["loginuser"] != null)
            { model.CreaterName = HttpUtility.UrlDecode(Request.Cookies["loginuser"].Value.ToString()); }
            bool issuccess = bll.InsertBlogArticle(model);
            return View(model);
        }

        public ActionResult BlogList(int id = 1)
        {
            BlogArticles model = new BlogArticles();
            model.PageSize = 5;
            model.PageIndex = id;
            DataTable tbl = new DataTable("Articles");
            tbl = bll.GetBlogArticleByPage(model);
            int totalItems = (int)tbl.Rows[0]["totalcount"]; //要分页的总记录数
            //PagedList构造函数
            PagedList<DataRow> arts = new PagedList<DataRow>(tbl.Select(), id, 5, totalItems);
            return View(arts);
        }
        public ActionResult GetBlogInfo(int id)
        {

            return View();
        }
    }
}
