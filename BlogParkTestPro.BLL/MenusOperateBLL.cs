using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BlogParkTestPro.Model;
using BlogParkTestPro.DAL;

namespace BlogParkTestPro.BLL
{
    public class MenusOperateBLL
    {
        MenusOperateDAL dal = new MenusOperateDAL();
         /// <summary>
        /// 得到某页面某处的菜单列表
        /// </summary>
        /// <param name="pageid">页面ID</param>
        /// <param name="positionid">位置ID</param>
        /// <returns></returns>
        public DataTable GetMenuListByPagePosition(int pageid, int positionid)
        {
            return dal.GetMenuListByPagePosition(pageid,positionid);
        }
    }
}
