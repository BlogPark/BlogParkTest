using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogParkTestPro.Model;
using System.Data;
using System.Data.SqlClient;

namespace BlogParkTestPro.DAL
{
    public class BasicsDataReaderDAL
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到需置顶新闻列表
        /// </summary>
        /// <param name="topcount"></param>
        /// <returns></returns>
        public DataTable GetNewsListsByTopCount(int topcount)
        {
            string sqltxt = @"SELECT TOP (@tcount)
        NewsID ,
        NewsTitle ,
        ReleaseTime ,
        ReleaseUserName ,
        NewsContext ,
        SupportCount ,
        AgainstCount ,
        AlwaysTop ,
        EditerRecommend
FROM    BlogPark.dbo.ParkNews WITH ( NOLOCK )
WHERE   AlwaysTop = 1
ORDER BY ReleaseTime DESC";
            SqlParameter[] paramter = { new SqlParameter("@tcount", SqlDbType.Int) };
            paramter[0].Value = topcount;
            return helper.Query(sqltxt, paramter).Tables[0];
        }
        /// <summary>
        /// 分页得到新闻列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewsList(int pageindex,int pagesize)
        {
            string sqltxt = @"SELECT  IDENTITY( INT,1,1 ) AS rowid ,
        NewsID=NewsID*1
INTO    #t
FROM    BlogPark.dbo.ParkNews A WITH ( NOLOCK )
WHERE   AlwaysTop = 0
DECLARE @total INT =@@ROWCOUNT
SELECT  @total AS totalcount,
        B.NewsID ,
        B.NewsTitle ,
        B.ReleaseTime ,
        B.ReleaseUserName ,
        B.NewsContext ,
        B.SupportCount ,
        B.AgainstCount ,
        B.AlwaysTop ,
        B.EditerRecommend
FROM    #t A
        INNER JOIN BlogPark.dbo.ParkNews B WITH ( NOLOCK ) ON A.NewsID = B.NewsID
                                                              AND A.rowid > ( @pagesize
                                                              * ( @pageindex
                                                              - 1 ) )
                                                              AND A.rowid < ( @pagesize
                                                              * @pageindex)+1";
            SqlParameter[] paramter = { new SqlParameter("@pagesize", SqlDbType.Int),
                                      new SqlParameter("@pageindex",SqlDbType.Int)};
            paramter[0].Value = pagesize;
            paramter[1].Value = pageindex;
            return helper.Query(sqltxt).Tables[0];
        }
    }
}
