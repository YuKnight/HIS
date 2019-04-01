using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Diagnostics;
using System.Xml;
using System.Reflection;
using System.Diagnostics;
namespace Ts_Hlyy_Interface
{
    class DTnew_HlyyClass:HlyyInterface
    {
      //  private EventHandler<EventArgs> callbackCompleted; 
         private delegate void  Invkoe(object ob) ;
          //private EventHandler<EventArgs> callbackCompleted;
        private static YWSUI.YWS yws;

        private bool IsInstall()
        {
            Process[] process = Process.GetProcesses();
            foreach (Process p in process)
            {
                if (p.ProcessName.Contains("YWSUpdateService"))
                    return true;
            }
            return false;
        }

        #region HlyyInterface 成员

        int HlyyInterface.RegisterServer_fun(object[] _values)
        {

            if (IsInstall() == false)
                return 1;
            if (yws == null)
                yws = new YWSUI.YWS();
          
            string ss = "";
            try
            {
                Doctor doctor = new Doctor(FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.Database); ;
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + doctor.TypeID + "</type><type_name>" + doctor.ZcjbMc + "</type_name ></doct></base_xml>";
            }
            catch
            {
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + "" + "</type><type_name>" + "" + "</type_name ></doct></base_xml>";
            }
            string refss = "";
            yws.YWS_UI(1, ss, "", ref refss);

            //RelationalDatabase Database = new MsSqlServer();
            //Database.Initialize(FrmMdiMain.Database.ConnectionString);
            //Doctor doctor = new Doctor(FrmMdiMain.CurrentUser.EmployeeId, Database);
            //Database.Close();
            //Database.Dispose();
            // Invkoe d = new Invkoe(RegisterServer);
            //    AsyncCallback d1 = new AsyncCallback(ht);
            //    IAsyncResult hh = d.BeginInvoke(doctor,d1,null );
              
            return 1;
        }
         private void ht(IAsyncResult result)
         {}
        private void RegisterServer (object ob)
        {
            if (IsInstall() == false)
                return ;
              if (yws == null)
                yws = new YWSUI.YWS();
           
            string ss ="";
            try
            {
                Doctor doctor = (Doctor)ob;
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + doctor.TypeID + "</type><type_name>" + doctor.ZcjbMc + "</type_name ></doct></base_xml>";
            }
            catch
            {
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + "" + "</type><type_name>" + "" + "</type_name ></doct></base_xml>";
            }
            string refss="";
            yws.YWS_UI(1, ss, "", ref refss);
           
        }
        void HlyyInterface.UNRegisterServer()
        {
            if (IsInstall() == false)
                return;
            if (yws == null)
                yws = new YWSUI.YWS();
          
            string ss ="";
            try
            {
                Doctor doctor = new Doctor(FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.Database);
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + doctor.TypeID + "</type><type_name>" + doctor.ZcjbMc + "</type_name ></doct></base_xml>";
            }
            catch
            {
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + "" + "</type><type_name>" + "" + "</type_name ></doct></base_xml>";
            }
            string refss = "";
            yws.YWS_UI(3, ss, "<details_xml></details_xml>", ref refss);
        }

        void HlyyInterface.Refresh()
        {
            if (IsInstall() == false)
                return;
            if (yws == null)
                yws = new YWSUI.YWS();
           
            string ss = "";
            try
            {
                Doctor doctor = new Doctor(FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.Database);
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + doctor.TypeID + "</type><type_name>" + doctor.ZcjbMc + "</type_name ></doct></base_xml>";
            }
            catch
            {
               
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + "" + "</type><type_name>" + "" + "</type_name ></doct></base_xml>";
            }
            string refss = "";
            yws.YWS_UI(4, ss, "<details_xml></details_xml>", ref refss);
        }
        /// <summary>
        /// 显示药点提示
        /// </summary>
        /// <param name="sb"></param>
        void HlyyInterface.ShowPoint(StringBuilder sb)
        {
            if (IsInstall() == false)
                return;
            int offset = 0;
            string str = "";
         
               // StackTrace st = new StackTrace();
               // StackFrame frame = new StackFrame(offset++);
               //int kk=st.GetFrames().Length;
               // for (int i = 0; i <kk ; i++)
               // {
               //    if( st.GetFrames()[i].GetMethod().Name.Trim()=="GetCardData")
               //        return ;
               // }

                //   if (frame.GetMethod() == null) break;
                // str += frame.GetMethod().Name + "\r\n";
                //如果偏移位置没有函数时,则GetMethod方法返回null

             
           
            if (yws == null)
                yws = new YWSUI.YWS();
         
            string ss = "";
            try
            {
                Doctor doctor = new Doctor(FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.Database);
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + doctor.TypeID + "</type><type_name>" + doctor.ZcjbMc + "</type_name ></doct></base_xml>";
            }
            catch
            {
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + "" + "</type><type_name>" + "" + "</type_name ></doct></base_xml>";
            }
            string refss = "";
            yws.YWS_UI(5, ss, sb.ToString(), ref refss);
        }

        void HlyyInterface.ClosePoint(StringBuilder sb)
        {
            //throw new Exception("The method or operation is not implemented.cc");
        }
        /// <summary>
        /// 结果分析
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="ZyOrMz"></param>
        /// <returns></returns>
        int HlyyInterface.DrugAnalysis(StringBuilder sb, int ZyOrMz)
        {
            int offset = 0;
            StackTrace st = new StackTrace();
            StackFrame frame = new StackFrame(offset++);
            int kk = st.GetFrames().Length;
            string ss1 = "";
            for (int ix = 0; ix < kk; ix++)
            {
                if (st.GetFrames()[ix].GetMethod().Name.Trim() == "FrmYZGL_Load")
                     return 0;
            }
            if (IsInstall() == false)
                return 0;
            if (yws == null)
                yws = new YWSUI.YWS();
            
            string ss = "";
            try
            {
                Doctor doctor = new Doctor(FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.Database);
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + doctor.TypeID + "</type><type_name>" + doctor.ZcjbMc + "</type_name ></doct></base_xml>";
            }
            catch
            {
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + "" + "</type><type_name>" + "" + "</type_name ></doct></base_xml>";
            }
            string refss = "";

            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(sb.ToString());
                XmlNode xmlnoe = xdoc.SelectSingleNode("//diagnose");

                // 创建节点
                xmlnoe.Attributes[0].Value = "2";
                sb = new StringBuilder(xdoc.OuterXml);
            }
            catch { }
            int i = Convert.ToInt32(yws.YWS_UI(6, ss, "<?xml version='1.0' ?>" + sb.ToString(), ref refss));
           
           return i;
        }

        int HlyyInterface.SaveDrug(StringBuilder sb, int ZyOrMz)
        {
            if (IsInstall() == false)
                return 0;
            if (yws == null)
                yws = new YWSUI.YWS();
            
            string ss = "";
            try
            {
                Doctor doctor = new Doctor(FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.Database);
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + doctor.TypeID + "</type><type_name>" + doctor.ZcjbMc + "</type_name ></doct></base_xml>";
            }
            catch
            {
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + "" + "</type><type_name>" + "" + "</type_name ></doct></base_xml>";
            }
            string refss = "";
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(sb.ToString());
                XmlNode xmlnoe = xdoc.SelectSingleNode("//diagnose");

                // 创建节点
                xmlnoe.Attributes[0].Value = "2";
                sb = new StringBuilder(xdoc.OuterXml);
            }
            catch { }
            int i= Convert.ToInt32( yws.YWS_UI(8, ss, "<?xml version='1.0' ?>" + sb.ToString(), ref refss));
            //5-	0.无问题	1.其他问题2.一般问题严重问
            if (i == 1 || i == 2)
                i = 1;
            //3是有严重问题
            if (i == 3)
                i = 2;
            
            if (i == 8)
                i = 2;
            return i;
        }

        void HlyyInterface.SaveXml(StringBuilder sb)
        {
            if (IsInstall() == false)
                return;
            if (yws == null)
                yws = new YWSUI.YWS();
          
            string ss = "";
            try
            {
                Doctor doctor = new Doctor(FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.Database);
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + doctor.TypeID + "</type><type_name>" + doctor.ZcjbMc + "</type_name ></doct></base_xml>";
            }
            catch
            {
                ss = "<?xml version='1.0' ?><base_xml><source>HIS</source><hosp_code>" + FrmMdiMain.Jgbm + "</hosp_code><dept_code>" + FrmMdiMain.CurrentDept.DeptId + "</dept_code><dept_name>" + FrmMdiMain.CurrentDept.DeptName + "</dept_name><doct><code>" + FrmMdiMain.CurrentUser.EmployeeId + "</code><name>" + FrmMdiMain.CurrentUser.Name + "</name><type>" + "" + "</type><type_name>" + "" + "</type_name ></doct></base_xml>";
            }
            string refss = "";
             yws.YWS_UI(11, ss, "<?xml version='1.0' ?>" + sb.ToString(), ref refss);
        }

        int HlyyInterface.Gmsgl(object[] _valuues)
        {
            //throw new Exception("The method or operation is not implemented.1");
            return 0;
        }

        void HlyyInterface.GetYpjgxx(TrasenClasses.GeneralControls.DataGridEx mydatagrid)
        {
            //throw new Exception("The method or operation is not implemented.2");
        }

        int HlyyInterface.recipe_check(int aitem, TrasenClasses.GeneralControls.DataGridEx[] mydatagrid, DateTime dt, int type, ref CfInfo[] cfinfo, int curindex)
        {
           // throw new Exception("The method or operation is not implemented.3");
            return 0;
        }

        int HlyyInterface.Pub_function(int commandno, string ss)
        {
            //throw new Exception("The method or operation is not implemented.4");
            return 0;
        }

        int HlyyInterface.GetCszt(int commandno, string ss)
        {
            return 0;
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
