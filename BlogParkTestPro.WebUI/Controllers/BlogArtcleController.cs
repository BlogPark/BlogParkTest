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
        public ActionResult AddBlogArtcle()
        {
            BlogArticles model = new BlogArticles();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlogArtcle(BlogArticles model)
        {
            string a = model.BlogContent;
            return View(model);
        }
    }
}
