using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BlogParkTestPro.DAL;
using BlogParkTestPro.Model;

namespace BlogParkTestPro.BLL
{
     public class BasicsDataReaderBLL
    {
         BasicsDataReaderDAL dal = new BasicsDataReaderDAL();
         /// <summary>
        /// 得到所有的友情链接
        /// </summary>
        /// <returns></returns>
         public DataTable GetAllFriendLink()
         {
             return dal.GetAllFriendLink();
         }
    }
}
