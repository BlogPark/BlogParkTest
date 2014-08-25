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
    /// <summary>
    /// 会员的简单操作 业务逻辑层
    /// </summary>
    public class MemberSimpleOperationBLL
    {
        MemberSimpleOperation dal = new MemberSimpleOperation();
        public MemberInfo CheckMemberCanLogin(MemberInfo model)
        {
            return dal.GetMemberUserforLogin(model);
        }
        /// <summary>
        /// 注册新会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertMemberUserforRegistration(MemberInfo model)
        {
            return dal.InsertMemberUserforRegistration(model);
        }
    }
}
