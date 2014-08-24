using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BlogParkTestPro.DAL
{
    public class CategoryOperateDAL
    {
        DbHelperSQL help = new DbHelperSQL();
        /// <summary>
        /// 得到主分类
        /// </summary>
        /// <returns></returns>
        public DataTable GetMainCategory()
        {
            string sqltxt = @"SELECT CategoryID,CategoryName  FROM dbo.LogCategory WITH(NOLOCK)WHERE FatherID=-1";
            return help.Query(sqltxt).Tables[0];
        }
        /// <summary>
        /// 按照fatherid得到子分类
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public DataTable GetSubCategory(int fatherid)
        {
            string sqltxt = @"SELECT CategoryID,CategoryName  FROM dbo.LogCategory WITH(NOLOCK)WHERE FatherID=@fatherid";
            SqlParameter[] paramter = { new SqlParameter("@fatherid",SqlDbType.Int)};
            paramter[0].Value = fatherid;
            return help.Query(sqltxt, paramter).Tables[0];
        }
    }
}
