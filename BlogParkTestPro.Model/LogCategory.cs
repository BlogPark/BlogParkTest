using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace BlogParkTestPro.Model
{
    //LogCategory
    [DataContract]
    public class LogCategory
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        [DataMember]
        public int CategoryID { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        [DataMember]
        public string CategoryName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public int IsAvailable { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [DataMember]
        public int CreateUser { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        [DataMember]
        public string CreateUsername { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        [DataMember]
        public int FatherID { get; set; }

    }
}
