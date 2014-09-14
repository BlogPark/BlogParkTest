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
        /// <summary>
        /// 分页查询博文
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetBlogArticleByPage(BlogArticles model)
        {
            return dal.GetBlogArticleByPage(model);
        }
        /// <summary>
        /// 得到博问明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetBlogArticInfoByid(int id)
        {
            return dal.GetBlogArticInfoByid(id);
        }
    }
}
