using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;

namespace ts_MzcfdySocket
{
    internal partial class Utility
    {

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="appKey"></param>
        /// <returns></returns>
        internal static string ReadConfig(string appKey, string configName)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configName));
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 修改配置文件
        /// </summary>
        /// <param name="AppKey"></param>
        /// <param name="AppValue"></param>
        internal static void SetConfig(string AppKey, string AppValue, string configName)//"bysSercive.exe.config"
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configName));
            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            if (xElem1 != null)
            {
                xElem1.SetAttribute("value", AppValue);
            }
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", AppKey);
                xElem2.SetAttribute("value", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configName));
        }

        ///<summary> 
        ///返回＊.exe.config文件中appSettings配置节的value项 
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<returns></returns> 
        internal static string GetAppConfig(string strKey)
        {
            foreach (string key in System.Configuration.ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }

        ///<summary> 
        ///在＊.exe.config文件中appSettings配置节增加一对键、值对 
        ///</summary> 
        ///<param name="newKey"></param> 
        ///<param name="newValue"></param> 
        internal static void UpdateAppConfig(string newKey, string newValue)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == newKey)
                {
                    isModified = true;
                }
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isModified)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


       

    }
}
