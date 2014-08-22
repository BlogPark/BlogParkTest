using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BlogParkTestPro.DAL
{
    /// <summary>
    /// 获取SQL配置
    /// </summary>
    public class SQLConstant
    {
        static object locker = new object();
        static XmlDocument xDoc = null;
        static Dictionary<string, string> rdsConnection = null;
        static Dictionary<string, string> keyConnection = null;

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            if (xDoc == null)
            {
                lock (locker)
                {
                    if (xDoc == null)
                    {
                        string filePath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace(@"file:///", string.Empty) + ".config";
                        xDoc = new XmlDocument();
                        xDoc.Load(filePath);
                    }
                }
            }
            string strConnection = string.Empty;
            try
            {
                strConnection = xDoc.SelectSingleNode(@"/configuration/appSettings/add[@key='" + configName + "']").Attributes["value"].Value;

            }
            catch { }
            return strConnection;
        }


        public static string GetRDSConnectionString(string shopNick)
        {
            if (rdsConnection == null)
            {
                lock (locker)
                {
                    if (rdsConnection == null)
                    {
                        rdsConnection = new Dictionary<string, string>();
                        if (xDoc == null)
                        {
                            string filePath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace(@"file:///", string.Empty) + ".config";
                            xDoc = new XmlDocument();
                            xDoc.Load(filePath);
                        }
                        XmlNodeList nodeList = xDoc.SelectNodes(@"/configuration/appSettings/add");
                        // LieBoRDSShopList  LieBoRDSConnectionString
                        List<XmlNode> nodeRDSShopList = (from f in nodeList.Cast<XmlNode>()
                                                         where f.Attributes["key"].Value.EndsWith("RDSShopList")
                                                         select f).ToList();
                        nodeRDSShopList.ForEach(item =>
                        {
                            string key = item.Attributes["key"].Value;
                            List<string> shopList = (from f in item.Attributes["value"].Value.Split(';')
                                                     where !string.IsNullOrWhiteSpace(f)
                                                     select f).ToList();
                            string exKey = key.Substring(0, key.Length - "RDSShopList".Length) + "RDSConnectionString";
                            string connectionString = (from f in nodeList.Cast<XmlNode>()
                                                       where f.Attributes["key"].Value == exKey
                                                       select f).First().Attributes["value"].Value;
                            shopList.ForEach(shop =>
                            {
                                if (!rdsConnection.ContainsKey(shop))
                                {
                                    rdsConnection.Add(shop, connectionString);
                                }
                            });
                        });
                    }
                }
            }
            return rdsConnection[shopNick];
        }
    }
}
