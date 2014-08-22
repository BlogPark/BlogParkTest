using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace BlogParkTestPro.Model
{
    [DataContract]
    public class MemberInfo
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        [DataMember]
        public int MemberID { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        [DataMember]
        public string MemberName { get; set; }
        /// <summary>
        /// 会员昵称（显示名称）
        /// </summary>
        [DataMember]
        public string Nickname { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string TruethName { get; set; }
        /// <summary>
        /// 会员性别（1 男  2女）
        /// </summary>
        [DataMember]
        public int MemberSex { get; set; }
        /// <summary>
        /// 婚姻状态（ 单身1 热恋 2 订婚 3 已婚 4 离异 5）
        /// </summary>
        [DataMember]
        public int MarryState { get; set; }
        /// <summary>
        /// 故乡地址
        /// </summary>
        [DataMember]
        public string FamilyAddress { get; set; }
        /// <summary>
        /// 现居地
        /// </summary>
        [DataMember]
        public string NewAddress { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        [DataMember]
        public string JobName { get; set; }
        /// <summary>
        /// 工作状态（1 学生 2 在职 3 待业 4 其他）
        /// </summary>
        [DataMember]
        public int JobState { get; set; }
        /// <summary>
        ///  自我介绍
        /// </summary>
        [DataMember]
        public string ShelfIntroduction { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        [DataMember]
        public string QQNumber { get; set; }
        /// <summary>
        /// MSN
        /// </summary>
        [DataMember]
        public string MSNNumber { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        [DataMember]
        public string LoginPassword { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [DataMember]
        public string MemberEmail { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

    }
}