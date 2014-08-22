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
        public bool CheckMemberCanLogin(MemberInfo model)
        {
            return dal.GetMemberUserforLogin(model);
        }
    }
}
