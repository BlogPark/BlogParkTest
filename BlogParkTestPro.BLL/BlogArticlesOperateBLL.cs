using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BlogParkTestPro.Model;
using BlogParkTestPro.DAL;

namespace BlogParkTestPro.BLL
{
    public class BlogArticlesOperateBLL
    {
        BlogArticlesOperateDAL dal = new BlogArticlesOperateDAL();
        public bool InsertBlogArticle(BlogArticles model)
        {
            return dal.InsertBlogArticle(model);
        }
    }
}
