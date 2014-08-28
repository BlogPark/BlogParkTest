using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace BlogParkTestPro.Model
{
    [DataContract]
    public class EssayCategory
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int? ID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        [DataMember]
        public string EssayCategoryName { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        [DataMember]
        public int? MemberID { get; set; }
        /// <summary>
        /// 是否在用
        /// </summary>
        [DataMember]
        public int? IsUsed { get; set; }

    }
}