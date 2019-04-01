using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Xml;
using System.Diagnostics;
namespace Ts_Hlyy_Interface
{
    public class DT2_Hlyy : HlyyInterface
    {
        [DllImport("CRMS_UI.dll", EntryPoint = "CRMS_UI")]
        public static extern int CRMS_UI(int nMsg,string lpszBaseXml,string lpszDetailsXml,  ref string pBstrResults);

        private string getBasexml()
        {
            string ss = "";
            string hosp_code = "";
            try
            {
                //Modify By Tany 2016-01-08 合理用药的hosp_code读取ini配置
                hosp_code = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("hlyy", "hosp_code", System.Windows.Forms.Application.StartupPath + "\\Hlyy.ini");
                Doctor doctor = new Doctor(FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.Database);
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + hosp_code + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + doctor.TypeID + "</type><type_name>" + doctor.ZcjbMc + "</type_name ></doct></base_xml>";
            }
            catch
            {
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + hosp_code + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + "" + "</type><type_name>" + "" + "</type_name ></doct></base_xml>";
            }
             
            return ss;
        }
        #region HlyyInterface 成员

        int HlyyInterface.RegisterServer_fun(object[] _values)
        {
          
            string detailxml="<details_xml><doct_pwd>"+FrmMdiMain.CurrentUser.Password+"</doct_pwd></details_xml>";
            string returnxml = "";
            return CRMS_UI(1, getBasexml(), detailxml, ref returnxml);
        }

        void HlyyInterface.UNRegisterServer()
        {
            string detailxml = "<details_xml></details_xml>";
            string returnxml = "";
             CRMS_UI(2, getBasexml(), detailxml, ref returnxml);

        }

        void HlyyInterface.Refresh()
        {
            string detailxml = "<details_xml></details_xml>";
            string returnxml = "";
           CRMS_UI(3, getBasexml(), detailxml, ref returnxml);
        }

        void HlyyInterface.ShowPoint(StringBuilder sb)
        {
            int offset = 0;
            string str = "";

            StackTrace st = new StackTrace();
            StackFrame frame = new StackFrame(offset++);
            int kk = st.GetFrames().Length;
            for (int i = 0; i < kk; i++)
            {
                if (st.GetFrames()[i].GetMethod().Name.Trim() == "GetCardData" || st.GetFrames()[i].GetMethod().Name.Trim() == "cellChanged")
                    return;
            }
            string detailxml = sb.ToString();
            string returnxml = "";
            //去掉空格
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(detailxml);
            XmlNode xmlnoe = xdoc.SelectSingleNode("//his_code");
            xmlnoe.InnerText = xmlnoe.InnerText.ToString().Trim();
  
            CRMS_UI(5, getBasexml(), xdoc.InnerXml, ref returnxml);
         

        }
        void writelog(string ss)
        {
             
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter("合理用药.txt",true);
                sw.WriteLine(ss);
                sw.Close();
            }
            catch { }
        }
        void HlyyInterface.ClosePoint(StringBuilder sb)
        {
          //  throw new Exception("The method or operation is not implemented.");
        }

        int HlyyInterface.DrugAnalysis(StringBuilder sb, int ZyOrMz)
        {
             
            string detailxml = sb.ToString();
            string returnxml = "";
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(detailxml);
            XmlNode xmlnoe = xdoc.SelectSingleNode("details_xml");
            // 创建节点
            XmlNode attrCount = xdoc.CreateNode(XmlNodeType.Attribute, "is_upload", null);

            attrCount.Value = "0";

            xdoc.FirstChild.Attributes.SetNamedItem(attrCount);
            string ss = xdoc.OuterXml.ToString();
            //性别
            if (ZyOrMz == 1)
            {
                xdoc = new XmlDocument();
                xdoc.LoadXml(ss);
                xmlnoe=xdoc.SelectSingleNode("//sex");
                if (xmlnoe.InnerText.Trim() == "1")
                    xmlnoe.InnerText = "男";
                else
                    xmlnoe.InnerText = "女";
                
                xdoc.LoadXml(xdoc.OuterXml.ToString().Replace("<hosp_flag>ip</hosp_flag>","<hosp_flag>op</hosp_flag>"));
                xmlnoe = xdoc.SelectSingleNode("//id");
                if (xmlnoe.InnerText==Guid.Empty.ToString())
                       xmlnoe.InnerText = Guid.NewGuid().ToString();
                   ss = xdoc.OuterXml.ToString();
            }

            int i = CRMS_UI(6, getBasexml(), ss, ref returnxml);
            writelog(getBasexml() + ss);
            return i;
        }

        int HlyyInterface.SaveDrug(StringBuilder sb, int ZyOrMz)
        {
            string detailxml = sb.ToString();
            string returnxml = "";
           
           
           XmlDocument xdoc = new XmlDocument();
           xdoc.LoadXml(detailxml);
           XmlNode xmlnoe = xdoc.SelectSingleNode("details_xml");
           // 创建节点
           XmlNode attrCount = xdoc.CreateNode(XmlNodeType.Attribute, "is_upload", null);
            
            attrCount.Value = "1";

           xdoc.FirstChild.Attributes.SetNamedItem(attrCount);
           string ss = xdoc.OuterXml.ToString();
          int i=  CRMS_UI(6, getBasexml(), xdoc.OuterXml.ToString(), ref returnxml);
          if (i == 2)
              i =1;
          if (i == 3)
              i = 2;
            return i;
        }

        void HlyyInterface.SaveXml(StringBuilder sb)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        int HlyyInterface.Gmsgl(object[] _valuues)
        {
            return 0;
           // throw new Exception("The method or operation is not implemented.");
        }

        void HlyyInterface.GetYpjgxx(TrasenClasses.GeneralControls.DataGridEx mydatagrid)
        {
           // throw new Exception("The method or operation is not implemented.");
        }

        int HlyyInterface.recipe_check(int aitem, TrasenClasses.GeneralControls.DataGridEx[] mydatagrid, DateTime dt, int type, ref CfInfo[] cfinfo, int curindex)
        {
            return 0;
          //  throw new Exception("The method or operation is not implemented.");
        }

        int HlyyInterface.Pub_function(int commandno, string ss)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int HlyyInterface.GetCszt(int commandno, string ss)
        {
            return 0;
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
