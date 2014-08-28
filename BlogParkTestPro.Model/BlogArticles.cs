using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace BlogParkTestPro.Model
{
    [DataContract]
    public class BlogArticles
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int? ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [DataMember]
        public int? CreaterID { get; set; }
        /// <summary>
        /// 创建人昵称
        /// </summary>
        [DataMember]
        public string CreaterName { get; set; }
        /// <summary>
        /// 文章标签
        /// </summary>
        [DataMember]
        public string ArticleTags { get; set; }
        /// <summary>
        /// 用户自定义分类ID
        /// </summary>
        [DataMember]
        public int? UserCategoryID { get; set; }
        /// <summary>
        /// 博文内容
        /// </summary>
        [DataMember]
        public string BlogContent { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        [DataMember]
        public int? BrowseCount { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        [DataMember]
        public int? ReviewCount { get; set; }
        /// <summary>
        /// 推荐数
        /// </summary>
        [DataMember]
        public int? RecommendCount { get; set; }
        /// <summary>
        /// 反对数
        /// </summary>
        [DataMember]
        public int? OppositionCount { get; set; }
        /// <summary>
        /// 文档状态（10 正常 20 删除  30 待发表）
        /// </summary>
        [DataMember]
        public int? Statenum { get; set; }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }
        /// <summary>
        /// 每页显示数
        /// </summary>
        [DataMember]
        public int? PageSize { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        [DataMember]
        public int? PageIndex { get; set; }
        /// <summary>
        /// 主类别ID
        /// </summary>
        [DataMember]
        public int? LogCategotyFatherID { get; set; }
        /// <summary>
        /// 子类别ID
        /// </summary>
        [DataMember]
        public int? LogCategorySubID { get; set; }

    }
}