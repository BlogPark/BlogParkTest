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
        /// <summary>
        /// 根据博文数降序排列会员名（前100名）
        /// </summary>
        /// <returns></returns>
        public DataTable GetMemberUserOrderByBlongCount()
        {
            return dal.GetMemberUserOrderByBlongCount();
        }
        /// <summary>
        /// 得到最新推荐的会员
        /// </summary>
        /// <returns></returns>
        public DataTable GetMaxBlogsMembers()
        {
            return dal.GetMaxBlogsMembers();
        }
    }
}
