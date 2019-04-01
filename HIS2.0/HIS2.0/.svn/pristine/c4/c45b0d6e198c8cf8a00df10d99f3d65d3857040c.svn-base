using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using System.Security;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace ts_Mzghsf_Tj
{
    public partial class FrmMzghsfghyrjbd : Form
    {
        protected GridppReport rptMain = new GridppReport();
        protected GridppReport ReportXJ = new GridppReport();
        protected GridppReport ReportYHK = new GridppReport();
        protected GridppReport ReportQTZF = new GridppReport();

        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;

        public FrmMzghsfghyrjbd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuTag"></param>
        /// <param name="chineseName"></param>
        /// <param name="mdiParent"></param>
        public FrmMzghsfghyrjbd(MenuTag menuTag, string chineseName, Form mdiParent)
        {

            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMzghsfghyrjbd_Load(object sender, EventArgs e)
        {
            this.dtp1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            ////载入报表模板数据
            //rptMain.LoadFromFile(@"D:\工作目录\HIS\报表\grid++\mzgh_rjbb.grf");
            //this.myGridPP.Report = rptMain;

            ////子报表部件框的报表对象关联一个外部报表对象，以便响应报表事件
            //ReportXJ = rptMain.ControlByName("ReportXJ").AsSubReport.Report;
            //ReportYHK = rptMain.ControlByName("ReportYHK").AsSubReport.Report;
            //ReportQTZF = rptMain.ControlByName("ReportQTZF").AsSubReport.Report;
            
            DbComboYQ();

            //ReportXJ.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportXJFetchRecord);
            //ReportYHK.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportYHKFetchRecord);
            //ReportQTZF.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportQTZFFetchRecord);
            //this.myGridPP.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTj_Click(object sender, EventArgs e)
        {
            this.myGridPP.Stop();
            int Ghy = 0;
            Ghy = Convert.ToInt32(Convertor.IsNull(txtSFY.Tag, "0"));
            if (Ghy==0)
            {
                MessageBox.Show("请先选择收费员进行后，再进行统计！");
                txtSFY.Focus();
                return;
                
            }
            //载入报表模板数据
           // rptMain.LoadFromFile(@"report\mzgh_rjbb.grf");
            rptMain.LoadFromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"report\mzgh_rjbb.grf"));
            this.myGridPP.Report = rptMain;

            //子报表部件框的报表对象关联一个外部报表对象，以便响应报表事件
            ReportXJ = rptMain.ControlByName("ReportXJ").AsSubReport.Report;
            ReportYHK = rptMain.ControlByName("ReportYHK").AsSubReport.Report;
            ReportQTZF = rptMain.ControlByName("ReportQTZF").AsSubReport.Report;
            this.rptMain.Initialize += Report_Initialize_Main;
            ReportXJ.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportXJFetchRecord);
            ReportYHK.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportYHKFetchRecord);
            ReportQTZF.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportQTZFFetchRecord);

            
            
            //this.myGridPP.Report = rptMain;
            //this.myGridPP.ResizeColumnToFitPage();

            this.myGridPP.Start();
            
           
            

            
        }

        /// <summary>
        /// 界面报表中参数的传值
        /// </summary>
        private void Report_Initialize_Main()
        {  
            this.rptMain.ParameterByName("OperatorName").AsString = InstanceForm.BCurrentUser.Name;
            string strFromTime = dtp1.Value.ToString("yyyy-MM-dd");
            string strEndTime = dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            
            string strYQName = comboBox1.Text.Trim();
            // string stryqname3=comb

            this.ReportXJ.ParameterByName("OperatorName").AsString = InstanceForm.BCurrentUser.Name;
            this.ReportXJ.ParameterByName("FromTime").AsString = strFromTime;
            this.ReportXJ.ParameterByName("ToTime").AsString = strEndTime;
            this.ReportXJ.ParameterByName("YqName").AsString = strYQName;

            this.ReportYHK.ParameterByName("OperatorName").AsString = InstanceForm.BCurrentUser.Name;
            this.ReportYHK.ParameterByName("FromTime").AsString = strFromTime;
            this.ReportYHK.ParameterByName("ToTime").AsString = strEndTime;
            this.ReportYHK.ParameterByName("YqName").AsString = strYQName;

            this.ReportQTZF.ParameterByName("OperatorName").AsString = InstanceForm.BCurrentUser.Name;
            this.ReportQTZF.ParameterByName("FromTime").AsString = strFromTime;
            this.ReportQTZF.ParameterByName("ToTime").AsString = strEndTime;
            this.ReportQTZF.ParameterByName("YqName").AsString = strYQName;
        }

      

        //从DataReader中载入数据 
        //现金支付方式的数据绑定
        private void ReportXJFetchRecord()
        {
            string strFromTime = dtp1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string strEndTime = dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            int Ghy = 0;
            Ghy = Convert.ToInt32(Convertor.IsNull(txtSFY.Tag, "0"));
            string stringYQ = comboBox1.SelectedValue.ToString();

            DataTable dt = Utility.GetInfo_Ghyjk_XJ(strFromTime, strEndTime, Ghy,stringYQ, InstanceForm.BDatabase);

            Utility.FillRecordToReport(ReportXJ, dt);
        }

        /// <summary>
        /// 银行卡的数据绑定
        /// </summary>
        private void ReportYHKFetchRecord()
        {
            string strFromTime = dtp1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string strEndTime = dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            int Ghy = 0;           
            Ghy = Convert.ToInt32(Convertor.IsNull(txtSFY.Tag, "0"));
            string stringYQ = comboBox1.SelectedValue.ToString();
            DataTable dt =  Utility.GetInfo_Ghyjk_YHK(strFromTime, strEndTime, Ghy, InstanceForm.BDatabase);

            Utility.FillRecordToReport(ReportYHK, dt);
        }

        /// <summary>
        /// 其他支付的数据绑定
        /// </summary>
        private void ReportQTZFFetchRecord()
        {
            string strFromTime = dtp1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string strEndTime = dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            
            int Ghy = 0;
            Ghy = Convert.ToInt32(Convertor.IsNull(txtSFY.Tag, "0"));
            string stringYQ = comboBox1.SelectedValue.ToString();
           /* try
            {
                Ghy = Convert.ToInt32(txtSFY.Tag.ToString());
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }*/
            DataTable dt = Utility.GetInfo_Ghyjk_QTZF(strFromTime, strEndTime, Ghy, InstanceForm.BDatabase);

            Utility.FillRecordToReport(ReportQTZF, dt);
        }

        /// <summary>
        /// 绑定院区的数据
        /// </summary>
        private void DbComboYQ()
        {

            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("id");
            DataColumn dc2 = new DataColumn("name");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            DataRow dr1 = dt.NewRow();
            dr1["id"] = "1001";
            dr1["name"] = "南院";

            DataRow dr2 = dt.NewRow();
            dr2["id"] = "1002";
            dr2["name"] = "后湖";

            DataRow dr3 = dt.NewRow();
            dr3["id"] = "1003";
            dr3["name"] = "花桥";

            DataRow dr4 = dt.NewRow();
            dr4["id"] = "1004";
            dr4["name"] = "谌家矶";

            DataRow dr5 = dt.NewRow();
            dr5["id"] = "0";
            dr5["name"] = "全院";

            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);
            dt.Rows.Add(dr5);

            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
            
        }

        /// <summary>
        /// 在弹出的界面进行自动完成选择院区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYQ_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        /// <summary>
        /// 在弹出的界面根据选择的院区进行查询收费员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSFY_KeyUp1(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = ""; control.Tag = "0";
            }
            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { } else { return; }

            try
            {
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);

                string[] GrdMappingName = new string[] { "EmployeeId", "NAME", "PYM", "WBM" };
                int[] GrdWidth = new int[] { 30, 100, 60, 50 };
                string[] sfield = new string[] { "Name", "PY_CODE", "Employee_Id", "", "" };//此处5个检索条件不要删除

                string ssql = string.Format(@"select Employee_Id AS EmployeeId,NAME,PY_CODE,WB_CODE 
                                            from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID 
                                            in (select Employee_Id from Pub_User where id in (
                                            select User_Id from Pub_Group_User where Group_Id =38 or Group_Id =39))   ");
                //string strYQID = comboBox1.SelectedValue.ToString();
                //if (strYQID != "0")
                //{
                //    ssql += " WHERE 1=1 AND c.YQID='" + strYQID + "' ";
                //}

                TrasenFrame.Forms.Fshowcard f = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "收费员录入";
                f.Width = 500;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    (sender as Control).Tag = row["EmployeeId"].ToString();
                    txtSFY.Text = row["NAME"].ToString();
                    txtSFY.Tag = row["EmployeeId"].ToString();
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        private void txtSFY_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = ""; control.Tag = "0";
            }
            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { } else { return; }

            try
            {
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);

                string[] GrdMappingName = new string[] { "EmployeeId", "NAME", "PYM", "WBM", "YQNAME" };
                int[] GrdWidth = new int[] { 30, 100, 60, 50, 50 };
                string[] sfield = new string[] { "a.NAME", "a.PY_CODE", "a.Employee_Id", "", "" };//此处5个检索条件不要删除

                string ssql = string.Format(@"select distinct a.Employee_Id AS EmployeeId ,a.NAME AS NAME,a.PY_CODE AS PYM,a.WB_CODE AS WBM,
                    (CASE C.YQID WHEN '1001' THEN '南院' WHEN '1002' THEN '后湖'  WHEN '1003' THEN '花桥'  WHEN '1004' THEN '谌家矶' 
                     WHEN '0' THEN '全院' END) AS YQNAME
                    from 
                    (select Employee_Id,NAME,PY_CODE,WB_CODE 
                    from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID 
                    in (select Employee_Id from Pub_User where id in (
                    select User_Id from Pub_Group_User where Group_Id =38 or Group_Id =39))
                     ) a
                    left join JC_EMP_DEPT_ROLE b on a.EMPLOYEE_ID = b.EMPLOYEE_ID 
                    left join JC_DEPT_PROPERTY c on b.DEPT_ID = c.DEPT_ID ");
                string strYQID = comboBox1.SelectedValue.ToString();
                if (strYQID != "0")
                {
                    ssql += " WHERE 1=1 AND c.YQID='" + strYQID + "' ";
                }

                TrasenFrame.Forms.Fshowcard f = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "收费员录入";
                f.Width = 500;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    (sender as Control).Tag = row["EmployeeId"].ToString();
                    txtSFY.Text = row["NAME"].ToString();
                    txtSFY.Tag = row["EmployeeId"].ToString();
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }
        /// <summary>
        /// 界面退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            this.myGridPP.Start();
            //this.myGridPP.PostColumnLayout();
            this.rptMain.PrintPreviewEx(GRPrintGenerateStyle.grpgsPreviewAll, true, true);
        }



      /*  private void dispose()
        {
            dtp1.Dispose();
            dtp2.Dispose();
            txtSFY.Dispose();
            comboBox1.Dispose();

        }*/






    }
}