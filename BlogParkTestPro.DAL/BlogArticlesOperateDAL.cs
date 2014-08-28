using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BlogParkTestPro.Model;

namespace BlogParkTestPro.DAL
{
    public class BlogArticlesOperateDAL
    {
        DbHelperSQL help = new DbHelperSQL();
        /// <summary>
        /// 插入博文
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertBlogArticle(BlogArticles model)
        {
            string sqltxt = @"INSERT INTO BlogPark.dbo.BlogArticles
        ( Title ,
          CreaterID ,
          CreaterName ,
          ArticleTags ,
          UserCategoryID ,
          BlogContent ,
          CreateTime ,
          BrowseCount ,
          ReviewCount ,
          RecommendCount ,
          OppositionCount ,
          Statenum ,
          LastUpdateTime
        )
VALUES  ( @Title,
          @CreaterID,
          @CreaterName,
          @ArticleTags,
          @UserCategoryID,
          @BlogContent,
          GETDATE(),
          0 ,
          0 ,
          0 , 
          0 ,
          10 ,
          GETDATE()
        )";
            SqlParameter[] paramter = { 
                                          new SqlParameter("@Title",SqlDbType.NVarChar),
                                          new SqlParameter("@CreaterID",SqlDbType.Int),
                                          new SqlParameter("@CreaterName",SqlDbType.NVarChar),
                                          new SqlParameter("@ArticleTags",SqlDbType.NVarChar),
                                          new SqlParameter("@UserCategoryID",SqlDbType.Int),
                                          new SqlParameter("@BlogContent",SqlDbType.Text)
                                      };
            paramter[0].Value = model.Title;
            paramter[1].Value = model.CreaterID;
            paramter[2].Value = model.CreaterName;
            paramter[3].Value = model.ArticleTags;
            paramter[4].Value = model.UserCategoryID;
            paramter[5].Value = model.BlogContent;
            int k = help.ExecuteSql(sqltxt, paramter);
            if (k > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 分页查询博文
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetBlogArticleByPage(BlogArticles model)
        {
            string sqltxt = @"SELECT  IDENTITY( INT,1,1 ) AS rowid ,
        ID = ID * 1
INTO    #t
FROM    BlogPark.dbo.BlogArticles A WITH ( NOLOCK )
WHERE Statenum=10  ";
            if (model.LogCategotyFatherID.HasValue)
            {
                sqltxt += @" AND LogCategotyFatherID=@LogCategotyFatherID ";
            }
            if (model.LogCategorySubID.HasValue)
            {
                sqltxt += @" AND LogCategorySubID=@LogCategorySubID  ";
            }
            string sql = @"DECLARE @total INT =@@ROWCOUNT
SELECT  @total AS totalcount,
        B.ID,
        B.Title ,
        B.BlogContent ,
        B.CreaterName ,
        B.CreateTime
FROM    #t A
        INNER JOIN BlogPark.dbo.BlogArticles B WITH ( NOLOCK ) ON A.id = B.id
                                                              AND A.rowid > ( @pagesize
                                                              * ( @pageindex
                                                              - 1 ) )
                                                              AND A.rowid < ( @pagesize
                                                              * @pageindex )+1";
            SqlParameter[] paramter = { new SqlParameter("@LogCategotyFatherID",SqlDbType.Int),
                          new SqlParameter("@LogCategorySubID",SqlDbType.Int),
                          new SqlParameter("@pagesize",SqlDbType.Int),
                          new SqlParameter("@pageindex",SqlDbType.Int)};
            paramter[0].Value = model.LogCategotyFatherID;
            paramter[1].Value = model.LogCategorySubID;
            paramter[2].Value = model.PageSize;
            paramter[3].Value = model.PageIndex;
            return help.Query(sqltxt + sql, paramter).Tables[0];
        }
    }
}
