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
    /// <summary>
    /// 简单的对会员信息的操作类
    /// </summary>
    public class MemberSimpleOperation
    {
        DbHelperSQL help=new DbHelperSQL();
        /// <summary>
        /// 按照会员名和密码查询是否允许登陆
        /// </summary>
        /// <param name="membermodel"></param>
        /// <returns></returns>
        public bool GetMemberUserforLogin(MemberInfo membermodel)
        {
            string sqltxt = @"SELECT  1
FROM    BlogPark.dbo.MemberInfo WITH ( NOLOCK )
WHERE MemberName=@membername AND LoginPassword=@password AND MemberState=1";
            SqlParameter[] paramter = { new SqlParameter("@membername",SqlDbType.NVarChar),
                                          new SqlParameter("@password",SqlDbType.NVarChar)
                                      };
            paramter[0].Value = membermodel.MemberName;
            paramter[1].Value = membermodel.LoginPassword;
            object obj = help.GetSingle(sqltxt, paramter);
            if (obj == null)
                return false;
            else
                return true;
        }
    }
}
