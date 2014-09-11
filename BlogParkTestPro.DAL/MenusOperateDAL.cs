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
    /// <summary>
    /// 系统菜单操作类
    /// </summary>
    public class MenusOperateDAL
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到某页面某处的菜单列表
        /// </summary>
        /// <param name="pageid">页面ID</param>
        /// <param name="positionid">位置ID</param>
        /// <returns></returns>
        public DataTable GetMenuListByPagePosition(int pageid, int positionid)
        {
            string sqltxt = @"SELECT  MenuID ,
        MenuName ,
        ISEnable ,
        PositionID ,
        WebPageID ,
        ActionName ,
        ControllerName ,
        GotoAddress
FROM    dbo.WebMenuOrder WITH(NOLOCK)
WHERE webpageid=@pageid AND positionid=@positionid";
            SqlParameter[] paramter = { 
                                          new SqlParameter("@pageid",SqlDbType.Int),
                                          new SqlParameter("@positionid",SqlDbType.Int)
                                      };
            paramter[0].Value = pageid;
            paramter[1].Value = positionid;
            return helper.Query(sqltxt, paramter).Tables[0];
        }
    }
}
