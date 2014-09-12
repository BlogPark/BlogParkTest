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
        public MemberInfo GetMemberUserforLogin(MemberInfo membermodel)
        {
            string sqltxt = @"SELECT  MemberID ,
        MemberName ,
        MemberEmail ,
        MemberState ,
        LoginPassword,Nickname
FROM    BlogPark.dbo.MemberInfo WITH ( NOLOCK )
WHERE MemberName=@membername AND LoginPassword=@password AND MemberState=1";
            SqlParameter[] paramter = { new SqlParameter("@membername",SqlDbType.NVarChar),
                                          new SqlParameter("@password",SqlDbType.NVarChar)
                                      };
            paramter[0].Value = membermodel.MemberName;
            paramter[1].Value = membermodel.LoginPassword;
           DataTable membertable = help.Query(sqltxt, paramter).Tables[0];
           if (membertable.Rows.Count == 0)
               return null;
           else
           {
               MemberInfo m = new MemberInfo();
               m.MemberName = membertable.Rows[0]["MemberName"].ToString();
               m.MemberID = int.Parse(membertable.Rows[0]["MemberID"].ToString());
               m.MemberEmail = membertable.Rows[0]["MemberEmail"].ToString();
               m.LoginPassword = membertable.Rows[0]["LoginPassword"].ToString();
               m.MemberState = int.Parse(membertable.Rows[0]["MemberState"].ToString());
               m.Nickname = membertable.Rows[0]["Nickname"].ToString();
               return m;
           }
        }
        /// <summary>
        /// 注册新会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertMemberUserforRegistration(MemberInfo model)
        {
            bool issuccessful=true;
            string sqltxt = @"INSERT INTO BlogPark.dbo.MemberInfo
        ( MemberName ,
          Nickname ,
          LoginPassword ,
          MemberEmail ,
          MemberState
        )
VALUES  (
          @MemberName ,
          @Nickname ,
          @LoginPassword ,
          @MemberEmail ,
          1
        )";
            SqlParameter[] paramter = { new SqlParameter("@MemberName",SqlDbType.NVarChar),
                                          new SqlParameter("@Nickname",SqlDbType.NVarChar),
                                          new SqlParameter("@LoginPassword",SqlDbType.NVarChar),
                                          new SqlParameter("@MemberEmail",SqlDbType.NVarChar)
                                      };
            paramter[0].Value = model.MemberName;
            paramter[1].Value = model.Nickname;
            paramter[2].Value = model.LoginPassword;
            paramter[3].Value = model.MemberEmail;
            int k = help.ExecuteSql(sqltxt,paramter);
            if (k > 0)
                issuccessful = true;
            else
                issuccessful = false;
            return issuccessful;
        }
        /// <summary>
        /// 根据博文数降序排列会员名（前100名）
        /// </summary>
        /// <returns></returns>
        public DataTable GetMemberUserOrderByBlongCount()
        {
            string sqltxt = @"SELECT  ROW_NUMBER() OVER( ORDER BY B.con DESC ) AS rowID, 
        A.MemberID , 
        A.MemberName ,
        B.con,
        A.Nickname
FROM    dbo.MemberInfo A WITH ( NOLOCK )
        INNER JOIN ( SELECT COUNT(0) con ,
                            CreaterID
                     FROM   dbo.BlogArticles WITH ( NOLOCK )
                     GROUP BY CreaterID
                   ) B ON A.MemberID = b.CreaterID
ORDER BY B.con DESC";
            return help.Query(sqltxt).Tables[0];
        }
    }
}
