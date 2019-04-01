using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;

namespace ClsWsMzTy
{
    public class HisFunctions
    {
        /// <summary>
        /// 将XML转换为dataset
        /// </summary>
        /// <param name="poststring"></param>
        /// <returns></returns>
        public static DataSet ConvertXmlToDataSet(string poststring)
        {
            string strHead = "<?xml version=\"1.0\" encoding=\"gb2312\" ?> ";
            string xml = strHead + poststring;
            DataSet ds = new DataSet();
            StringReader StrStream = null;
            XmlTextReader Xmlrdr = null;
            //读取文件中的字符流       
            StrStream = new StringReader(xml);
            //获取StrStream中的数据                     
            Xmlrdr = new XmlTextReader(StrStream);
            //ds获取Xmlrdr中的数据            
            ds.ReadXml(Xmlrdr);
            return ds;
        }
    }
}
