using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
namespace BlogParkTestPro.Model
{
    [DataContract]
    public class WebMenuOrder
    {
        /// <summary>
        /// MenuID
        /// </summary>
        [DataMember]
        public int MenuID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DataMember]
        public string MenuName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public int ISEnable { get; set; }
        /// <summary>
        /// PositionID
        /// </summary>
        [DataMember]
        public int PositionID { get; set; }
        /// <summary>
        /// 所属页面
        /// </summary>
        [DataMember]
        public int WebPageID { get; set; }
        /// <summary>
        /// Action名称
        /// </summary>
        [DataMember]
        public string ActionName { get; set; }
        /// <summary>
        /// Controller名称
        /// </summary>
        [DataMember]
        public string ControllerName { get; set; }
        /// <summary>
        /// 目标地址
        /// </summary>
        [DataMember]
        public string GotoAddress { get; set; }

    }

    public enum WebPositionEnum
    {
        /// <summary>
        /// 上菜单栏
        /// </summary>
       TopMenuBar=1,
        /// <summary>
        /// 左侧菜单
        /// </summary>
        LeftMenuBar=2,
        /// <summary>
        /// 右侧菜单
        /// </summary>
        RightMenuBar=3,
        /// <summary>
        /// 选项卡列表
        /// </summary>
        TabList=4
    }
}