using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_yg_interface
{
    public class JudgeorderYg
    {
        TrasenClasses.DatabaseAccess.RelationalDatabase Database;
        public JudgeorderYg(TrasenClasses.DatabaseAccess.RelationalDatabase _Database)
        {
            Database = _Database;
        }
        public JudgeorderYg()
        {
            Database = TrasenFrame.Forms.FrmMdiMain.Database;
        }

        public void CheckYgInfo(string zyh, int empNo, out string msg, out string url)
        {
            url = "";
            msg = "";
            try
            {
                string strHead = "<?xml version=\"1.0\" encoding=\"utf-8\" ?> ";

                strHead += string.Format(@"<params><cmd>getInfo1</cmd><inpno>{0}</inpno></params>", zyh);

                WsXlYg.QueryDbToWebsService wsYg = new ts_yg_interface.WsXlYg.QueryDbToWebsService();
                wsYg.Url = @"http://192.168.100.126/DataHandling/services/QueryDbToWebs";

                string outxml = wsYg.getInfo1(strHead);

                //StringBuilder sb = new StringBuilder();
                //sb.Append(outxml);
                //sb.Append(" <root> ");
                //sb.Append(postString);
                //sb.Append(" </root> ");
                XmlDocument xx = new XmlDocument();
                xx.LoadXml(outxml);//加载xml

                XmlNodeList xxList = xx.SelectNodes("/DATAS"); //取得节点名为DATAS的XmlNode集合

                XmlNode ret = xxList[0].SelectSingleNode("//DATA");
                string isInfected = "";
                if (ret != null)
                {
                    isInfected = ret.InnerText;   //这边就可以获得节点的值了
                }
                //string message = (xxList[0].SelectSingleNode("//message")).InnerText;   //这边就可以获得节点的值了


                if (isInfected.Trim().Equals("1"))
                {
                    msg = "";

                    string ssql = string.Format("select D_CODE from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID='{0}' ", empNo);
                    string dCodeEmp = Convertor.IsNull(Database.GetDataResult(ssql),"").ToString();
                    
                    url = string.Format(@"http://192.168.100.126/nis/cdc?userid={0}&patientid={1}&visitid=1", dCodeEmp, zyh);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
