using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
namespace ts_yk_xtdz
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class Frmxtdz : System.Windows.Forms.Form
    {
        private int _year;
        private int _month;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblbz;
        private System.Windows.Forms.TextBox txtbz;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butok;
        private System.Windows.Forms.ComboBox cmbmonth;
        private System.Windows.Forms.ComboBox cmbyear;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        private SystemCfg cfg8056 = new SystemCfg(8056);
        private SystemCfg cfg8058 = new SystemCfg(8058);

        public Frmxtdz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.label1.Text = _chineseName;

            this.dtp1.Enabled = false;
            ;
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_ymjz")
            {
                this.lblbz.Visible = true;
                this.txtbz.Visible = true;
                //this.label1.Text="																						"+ "系统在月结前会自动进行对帐操作,并将上次月结到当前日期内所产生的数据进行汇总结帐。 ";
                this.Text = "月末结账";


            }

            if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_unymjz")
            {
                //this.label1.Text="	   																				    "+ "注意:取消上次月结后您不能再对其数据进行恢复，在取消前请慎重考虑! ";
                this.Text = "取消上次月结";
            }
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";

        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.butquit = new System.Windows.Forms.Button();
            this.butok = new System.Windows.Forms.Button();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.lblbz = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightYellow;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "系统对帐";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbyear);
            this.panel1.Controls.Add(this.cmbmonth);
            this.panel1.Controls.Add(this.pb);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.butok);
            this.panel1.Controls.Add(this.txtbz);
            this.panel1.Controls.Add(this.lblbz);
            this.panel1.Controls.Add(this.dtp2);
            this.panel1.Controls.Add(this.dtp1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 146);
            this.panel1.TabIndex = 1;
            // 
            // cmbyear
            // 
            this.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbyear.Items.AddRange(new object[] {
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cmbyear.Location = new System.Drawing.Point(256, 67);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(56, 22);
            this.cmbyear.TabIndex = 11;
            this.cmbyear.Visible = false;
            this.cmbyear.SelectedIndexChanged += new System.EventHandler(this.cmbyear_SelectedIndexChanged);
            // 
            // cmbmonth
            // 
            this.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmonth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbmonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbmonth.Location = new System.Drawing.Point(315, 67);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(48, 22);
            this.cmbmonth.TabIndex = 10;
            this.cmbmonth.Visible = false;
            this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(11, 138);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(145, 10);
            this.pb.TabIndex = 8;
            this.pb.Visible = false;
            // 
            // butquit
            // 
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butquit.Location = new System.Drawing.Point(169, 100);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(96, 32);
            this.butquit.TabIndex = 7;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.button2_Click);
            // 
            // butok
            // 
            this.butok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butok.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butok.Location = new System.Drawing.Point(65, 100);
            this.butok.Name = "butok";
            this.butok.Size = new System.Drawing.Size(96, 32);
            this.butok.TabIndex = 6;
            this.butok.Text = "开始(&B)";
            this.butok.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbz
            // 
            this.txtbz.Enabled = false;
            this.txtbz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbz.Location = new System.Drawing.Point(111, 66);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(143, 23);
            this.txtbz.TabIndex = 5;
            this.txtbz.Visible = false;
            // 
            // lblbz
            // 
            this.lblbz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbz.Location = new System.Drawing.Point(44, 70);
            this.lblbz.Name = "lblbz";
            this.lblbz.Size = new System.Drawing.Size(80, 16);
            this.lblbz.TabIndex = 4;
            this.lblbz.Text = "月份区间";
            this.lblbz.Visible = false;
            // 
            // dtp2
            // 
            this.dtp2.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(111, 39);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(143, 21);
            this.dtp2.TabIndex = 3;
            // 
            // dtp1
            // 
            this.dtp1.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(110, 12);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(144, 21);
            this.dtp1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(44, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "当前日期";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(32, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "上次月结日期:";
            // 
            // Frmxtdz
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(368, 191);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmxtdz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统对帐";
            this.Load += new System.EventHandler(this.Frmxtdz_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>

        private void Frmxtdz_Load(object sender, System.EventArgs e)
        {

            txtbz.Visible = true;
            dtp1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            string ssql = "select * from yp_kjqj where deptid=" + InstanceForm.BCurrentDept.DeptId +
                " or deptid in(select deptid from yp_yjks_gx where p_deptid=" + InstanceForm.BCurrentDept.DeptId + ") " +
                " order by kjnf desc,kjyf desc";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
            {
                ssql = "select * from yp_yjks where deptid=" + InstanceForm.BCurrentDept.DeptId + " and qybz=1 ";
                DataTable tbks = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbks.Rows.Count == 0)
                {
                    ssql = "select djsj qysj from yp_yjks_gx where p_deptid=" + InstanceForm.BCurrentDept.DeptId + "  ";
                    tbks = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tbks.Rows.Count == 0) { butok.Enabled = false; return; }
                }


                dtp1.Value = Convert.ToDateTime(tbks.Rows[0]["qysj"]);
                dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                _year = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Year;
                _month = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Month;

                txtbz.Text = _year.ToString() + "年" + _month.ToString() + "月";

                if (_menuTag.Function_Name.Trim() != "Fun_ts_yk_xtdz")
                {
                    cmbyear.Visible = true;
                    cmbmonth.Visible = true;
                    cmbyear.Text = Convert.ToString(_year);
                    cmbmonth.Text = Convert.ToString(_month);
                }

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_unymjz")
                    butok.Enabled = false;

                //return;
            }
            else
            {
                dtp1.Value = Convert.ToDateTime(tb.Rows[0]["jsrq"]);
                dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                if (tb.Rows[0]["kjyf"].ToString() == "12")
                {
                    this._year = Convert.ToInt32(tb.Rows[0]["kjnf"]) + 1;
                    this._month = 1;
                }
                else
                {
                    this._year = Convert.ToInt32(tb.Rows[0]["kjnf"]);
                    this._month = Convert.ToInt32(tb.Rows[0]["kjyf"]) + 1;
                }
                txtbz.Text = _year.ToString() + "年" + _month.ToString() + "月";
            }

            //如果参数80014(盘点审核做帐时间为帐存表生成时间)
            string Pd_shsj = "";
            ssql = "select top 1 djsj from yf_pdtemp where deptid=" + InstanceForm.BCurrentDept.DeptId +
                " or deptid in(select deptid from yp_yjks_gx where p_deptid=" + InstanceForm.BCurrentDept.DeptId + ") " +
                " order by id desc";
            DataTable tbtemp = InstanceForm.BDatabase.GetDataTable(ssql);

            SystemCfg s = new SystemCfg(8014);
            if (s.Config == "1" && tbtemp.Rows.Count > 0)
            {
                if (Convert.ToDateTime(tbtemp.Rows[0]["djsj"]) > dtp1.Value)
                    Pd_shsj = tbtemp.Rows[0]["djsj"].ToString();
                else
                    Pd_shsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            }
            else
                Pd_shsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            dtp2.Value = Convert.ToDateTime(Pd_shsj);

            //Modify by : jchl 06-29(由于有月结和无月结的影响，只能取_year, _month 作为需要 年月)
            if (!cfg8058.Config.Equals("0"))
            {
                int daysInMonth = DateTime.DaysInMonth(_year, _month);
                int yjDay = int.Parse(cfg8058.Config);
                dtp2.Value = yjDay >= daysInMonth ? new DateTime(_year, _month, daysInMonth, 23, 59, 59) : new DateTime(_year, _month, yjDay, 23, 59, 59);

                //Modify by : jchl 06-29
                dtp2.Enabled = false;//武汉二医院版本必须月底最后时间，并且不让修改
                //dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            }

            //如果为取消月结
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_unymjz" && tb.Rows.Count > 0)
            {
                dtp1.Value = Convert.ToDateTime(tb.Rows[0]["ksrq"]);
                dtp2.Value = Convert.ToDateTime(tb.Rows[0]["jsrq"]);
                this._year = Convert.ToInt32(tb.Rows[0]["kjnf"]);
                this._month = Convert.ToInt32(tb.Rows[0]["kjyf"]);
                label2.Text = "开始时间";
                label3.Text = "结束时间";
                dtp2.Enabled = false;
                txtbz.Text = _year.ToString() + "年" + _month.ToString() + "月";
            }


        }

        //系统对账 月末结存
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (_menuTag.Function_Name.Trim() != "Fun_ts_yk_unymjz")
            {
                #region 系统对账
                //系统对账
                this.Text = "正在进行系统对账.....";
                try
                {
                    ParameterEx[] parameters = new ParameterEx[2];
                    parameters[0].Text = "@jsrq";
                    parameters[0].Value = dtp1.Value.ToString();

                    parameters[1].Text = "@deptid";
                    parameters[1].Value = InstanceForm.BCurrentDept.DeptId;

                    DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YK_XTDZ", parameters, 30);
                    tb.TableName = "myTb";

                    if (tb.Rows.Count > 0)
                    {
                        this.Close();
                        Frmxtdzmx f = new Frmxtdzmx(_menuTag, _chineseName, _mdiParent);
                        f.MdiParent = _mdiParent;
                        f.Show();
                        f.FillData(tb);
                        return;
                    }

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_xtdz")
                    {
                        MessageBox.Show("系统对帐完成");
                        this.Text = _chineseName.Trim();
                        this.Close();
                        return;
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("出错" + err.Message);
                    return;
                }

                #endregion
            }

            #region 取消上次月结
            //取消上次月结
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yk_unymjz" && MessageBox.Show("您确定要取消 [" + txtbz.Text + "] 这次月结吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Text = "正在取消上次月结.....";
                try
                {
                    int err_code = -1;
                    string err_text = "";

                    InstanceForm.BDatabase.BeginTransaction();

                    ParameterEx[] parameters = new ParameterEx[5];
                    parameters[0].Text = "@deptid";
                    parameters[0].Value = InstanceForm.BCurrentDept.DeptId;

                    parameters[1].Text = "@djsj";
                    parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                    parameters[2].Text = "@djy";
                    parameters[2].Value = InstanceForm.BCurrentUser.EmployeeId;

                    parameters[3].Text = "@err_code";
                    parameters[3].ParaDirection = ParameterDirection.Output;
                    parameters[3].DataType = System.Data.DbType.Int32;
                    parameters[3].ParaSize = 100;

                    parameters[4].Text = "@err_text";
                    parameters[4].ParaDirection = ParameterDirection.Output;
                    parameters[4].ParaSize = 100;


                    InstanceForm.BDatabase.DoCommand("sp_yk_UNymjc", parameters, 30);
                    err_code = Convert.ToInt32(parameters[3].Value);
                    err_text = Convert.ToString(parameters[4].Value);


                    if (err_code != 0) throw new System.Exception(err_text);

                    InstanceForm.BDatabase.CommitTransaction();

                    this.Text = _chineseName.Trim();

                    #region 日志记录
                    string str_old = "";
                    str_old = InstanceForm.BCurrentUser.Name + "取消月结.上次月结时间是" + dtp1.Value.ToString() + " 到:" + dtp2.Value.ToString();
                    SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "取消月结", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                    systemLog.Save();
                    systemLog = null;
                    #endregion


                    MessageBox.Show(err_text);
                    this.Close();
                    return;

                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    this.butok.Enabled = true;
                    MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            #endregion

            #region 月未结账

            if (_menuTag.Function_Name.Trim() != "Fun_ts_yk_ymjz") return;
            //月未结帐
            this.Text = "正在进行月未结帐.....";

            try
            {
                if (dtp2.Value < dtp1.Value)
                {
                    MessageBox.Show("月结止日期不能小于开始日期", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtp2.Value > DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase))
                {
                    MessageBox.Show("月结止日期不能大于系统当前时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.butok.Enabled = false;
                int err_code = -1;
                string err_text = "";

                InstanceForm.BDatabase.BeginTransaction();

                string ssql = "select dept_id,name from jc_dept_property  where  dept_id in(select deptid from yp_yjks_gx where p_deptid=" + InstanceForm.BCurrentDept.DeptId + ")";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count == 0)
                    ssql = "select dept_id,name from jc_dept_property  where dept_id=" + InstanceForm.BCurrentDept.DeptId + " ";
                tb = InstanceForm.BDatabase.GetDataTable(ssql);

                for (int xxx = 0; xxx <= tb.Rows.Count - 1; xxx++)
                {
                    #region 执行月结
                    int _deptID = Convert.ToInt32(tb.Rows[xxx]["dept_id"]);
                    ParameterEx[] parameters = new ParameterEx[9];
                    parameters[0].Text = "@year";
                    parameters[0].Value = _year;

                    parameters[1].Text = "@month";
                    parameters[1].Value = _month;

                    parameters[2].Text = "@deptid";
                    parameters[2].Value = _deptID;

                    parameters[3].Text = "@ksrq";
                    parameters[3].Value = dtp1.Value.ToString();// dtp1.Value.ToShortDateString();

                    parameters[4].Text = "@jsrq";
                    parameters[4].Value = dtp2.Value.ToString();// dtp2.Value.ToShortDateString();

                    parameters[5].Text = "@djsj";
                    parameters[5].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                    parameters[6].Text = "@djy";
                    parameters[6].Value = InstanceForm.BCurrentUser.EmployeeId;

                    parameters[7].Text = "@err_code";
                    parameters[7].ParaDirection = ParameterDirection.Output;
                    parameters[7].DataType = System.Data.DbType.Int32;
                    parameters[7].ParaSize = 100;

                    parameters[8].Text = "@err_text";
                    parameters[8].ParaDirection = ParameterDirection.Output;
                    parameters[8].ParaSize = 100;


                    InstanceForm.BDatabase.DoCommand("sp_Yk_ymjc", parameters, 30);
                    err_code = Convert.ToInt32(parameters[7].Value);
                    err_text = Convert.ToString(parameters[8].Value);


                    if (err_code != 0) throw new System.Exception(err_text);
                    #endregion
                }
                InstanceForm.BDatabase.CommitTransaction();

                YMJC ymjc = new YMJC( InstanceForm.BDatabase );
                string message = "";
                for ( int xxx = 0 ; xxx <= tb.Rows.Count - 1 ; xxx++ )
                {
                    #region 生成月结中间表数据
                    int _deptID = Convert.ToInt32( tb.Rows[xxx]["dept_id"] );
                    string _name = tb.Rows[xxx]["name"].ToString().Trim();
                    if(  ymjc.GenerateDetailData( _deptID , _year , _month , out message ) == false )
                        MessageBox.Show( _name + "月结成功，但生成中间表数据失败，请联系管理员处理" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );                                            
                    #endregion
                }
                

                this.Text = _chineseName.Trim();
                MessageBox.Show(err_text);
                butok.Enabled = true;
                this.Close();

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butok.Enabled = true;
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            #endregion


        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        
        private void cmbmonth_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _month = Convert.ToInt32(cmbmonth.Text);
            txtbz.Text = _year.ToString() + "年" + _month.ToString() + "月";

            try
            {

                //Modify by : jchl 06-29(由于有月结和无月结的影响，只能取_year, _month 作为需要 年月)
                if (!cfg8058.Config.Equals("0"))
                {
                    int daysInMonth = DateTime.DaysInMonth(_year, _month);
                    int yjDay = int.Parse(cfg8058.Config);
                    dtp2.Value = yjDay >= daysInMonth ? new DateTime(_year, _month, daysInMonth, 23, 59, 59) : new DateTime(_year, _month, yjDay, 23, 59, 59);

                    //Modify by : jchl 06-29
                    dtp2.Enabled = false;//武汉二医院版本必须月底最后时间，并且不让修改
                    //dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                }
            }
            catch { }
        }

        private void cmbyear_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _year = Convert.ToInt32(cmbyear.Text);
            txtbz.Text = _year.ToString() + "年" + _month.ToString() + "月";
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (checkBox1.Checked==true)
            //{
            //    this.dtptime2.Visible=true;
            //    dtptime2.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToLongTimeString());
            //}
            //else
            //    this.dtptime2.Visible=false;
        }
    }
}
