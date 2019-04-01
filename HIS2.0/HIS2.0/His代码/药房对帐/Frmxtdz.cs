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
namespace ts_yf_xtdz
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmxtdz : System.Windows.Forms.Form
	{
		private int _year;
		private int _month;

        private System.Windows.Forms.Label label1;
        public DateTimePicker dtpendrq;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblscscrq;
        public Button butsc;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cmbyear;
		private System.Windows.Forms.ComboBox cmbmonth;
        private System.Windows.Forms.Button butquit;
        public Button butok;
		private System.Windows.Forms.TextBox txtbz;
		private System.Windows.Forms.Label lblbz;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        private SystemCfg cfg8058 = new SystemCfg(8058); 

        bool bpcgl = false; //是否进行批次管理

		public Frmxtdz(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.dtp1.Enabled=false;
			//this.dtp2.Enabled=false;
			if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_ymjz")
			{
				this.lblbz.Visible=true;
				this.txtbz.Visible=true;
				this.label1.Text="																						"+ "系统在月结前会自动进行对帐操作,并将上次月结到当前日期内所产生的数据进行汇总结帐。 ";
				this.Text="月未结账";
			}

			if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_unymjz")
			{
				this.label1.Text="	   																				    "+ "注意:取消上次月结后您不能再对其数据进行恢复，在取消前请慎重考虑! ";
				this.Text="取消本次月结";
			}

			this.groupBox2.Text="第二步:"+this.Text;

            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
			
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmxtdz));
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpendrq = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butsc = new System.Windows.Forms.Button();
            this.lblscscrq = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.butquit = new System.Windows.Forms.Button();
            this.butok = new System.Windows.Forms.Button();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.lblbz = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightYellow;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(16, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "本次上传日期";
            // 
            // dtpendrq
            // 
            this.dtpendrq.Location = new System.Drawing.Point(104, 54);
            this.dtpendrq.Name = "dtpendrq";
            this.dtpendrq.Size = new System.Drawing.Size(112, 21);
            this.dtpendrq.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butsc);
            this.groupBox1.Controls.Add(this.lblscscrq);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpendrq);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 88);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "第一步 :上传发药记录";
            // 
            // butsc
            // 
            this.butsc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butsc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butsc.Location = new System.Drawing.Point(264, 48);
            this.butsc.Name = "butsc";
            this.butsc.Size = new System.Drawing.Size(96, 32);
            this.butsc.TabIndex = 19;
            this.butsc.Text = "开始上传(&U)";
            this.butsc.Click += new System.EventHandler(this.butsc_Click);
            // 
            // lblscscrq
            // 
            this.lblscscrq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblscscrq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblscscrq.Location = new System.Drawing.Point(104, 23);
            this.lblscscrq.Name = "lblscscrq";
            this.lblscscrq.Size = new System.Drawing.Size(227, 24);
            this.lblscscrq.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "上次上传日期 ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 199);
            this.panel2.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbyear);
            this.groupBox2.Controls.Add(this.cmbmonth);
            this.groupBox2.Controls.Add(this.butquit);
            this.groupBox2.Controls.Add(this.butok);
            this.groupBox2.Controls.Add(this.txtbz);
            this.groupBox2.Controls.Add(this.lblbz);
            this.groupBox2.Controls.Add(this.dtp2);
            this.groupBox2.Controls.Add(this.dtp1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(0, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 111);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ggg";
            // 
            // cmbyear
            // 
            this.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbyear.Location = new System.Drawing.Point(232, 80);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(56, 20);
            this.cmbyear.TabIndex = 23;
            this.cmbyear.Visible = false;
            this.cmbyear.SelectedIndexChanged += new System.EventHandler(this.cmbyear_SelectedIndexChanged);
            // 
            // cmbmonth
            // 
            this.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbmonth.Location = new System.Drawing.Point(288, 80);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(48, 20);
            this.cmbmonth.TabIndex = 22;
            this.cmbmonth.Visible = false;
            this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
            // 
            // butquit
            // 
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butquit.Location = new System.Drawing.Point(376, 32);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(96, 32);
            this.butquit.TabIndex = 21;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.button2_Click);
            // 
            // butok
            // 
            this.butok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butok.Location = new System.Drawing.Point(264, 32);
            this.butok.Name = "butok";
            this.butok.Size = new System.Drawing.Size(96, 32);
            this.butok.TabIndex = 20;
            this.butok.Text = "开始(&B)";
            this.butok.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbz
            // 
            this.txtbz.Enabled = false;
            this.txtbz.Location = new System.Drawing.Point(104, 79);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(128, 21);
            this.txtbz.TabIndex = 19;
            // 
            // lblbz
            // 
            this.lblbz.ForeColor = System.Drawing.Color.Black;
            this.lblbz.Location = new System.Drawing.Point(32, 81);
            this.lblbz.Name = "lblbz";
            this.lblbz.Size = new System.Drawing.Size(80, 16);
            this.lblbz.TabIndex = 18;
            this.lblbz.Text = "会计区间名:";
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(104, 48);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(140, 21);
            this.dtp2.TabIndex = 17;
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(104, 16);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(141, 21);
            this.dtp1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(40, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "当前日期:";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "上次月结日期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frmxtdz
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(511, 271);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmxtdz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统对帐";
            this.Load += new System.EventHandler(this.Frmxtdz_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>

		private void Frmxtdz_Load(object sender, System.EventArgs e)
		{
			//上次上传的日期
			string rq=ApiFunction.GetIniString("SERVER","发药上传日期",Environment.CurrentDirectory+"\\Server.ini");
			string ssql="select * from yp_yjks where deptid="+InstanceForm.BCurrentDept.DeptId+"";
			DataTable tbyjks=InstanceForm.BDatabase.GetDataTable(ssql);
			if (tbyjks.Rows.Count!=0)
			this.lblscscrq.Text=tbyjks.Rows[0]["cfscrq"].ToString().Trim();

//			this.dtpendrq.Visible=true;

//			if (_menuTag.Function_Name.Trim()!="Fun_ts_yf_xtdz")
//			{
//				this.dtpendrq.Visible=false;
//			}

			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
			dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			dtpendrq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

			ssql="select * from yp_kjqj where deptid="+InstanceForm.BCurrentDept.DeptId+" order by kjnf desc ,kjyf desc";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
            {
                ssql = "select * from yp_yjks where deptid=" + InstanceForm.BCurrentDept.DeptId + " and qybz=1 ";
                DataTable tbks = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbks.Rows.Count == 0) { MessageBox.Show("错误，科室可能没有启用"); return; }

                dtp1.Value = Convert.ToDateTime(tbks.Rows[0]["qysj"]);
                dtp2.Value = Convert.ToDateTime(sDate);

                _year = Convert.ToDateTime(sDate).Year;
                _month = Convert.ToDateTime(sDate).Month;

                txtbz.Text = _year.ToString() + "年" + _month.ToString() + "月";

                if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_xtdz")
                {
                    cmbyear.Visible = true;
                    cmbmonth.Visible = true;
                    cmbyear.Text = Convert.ToString(_year);
                    cmbmonth.Text = Convert.ToString(_month);
                }

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_unymjz")
                    butok.Enabled = false;
                //return;
            }
            else
            {
                dtp1.Value = Convert.ToDateTime(tb.Rows[0]["jsrq"]);
                dtp2.Value = Convert.ToDateTime(sDate); ;
                dtpendrq.Value = Convert.ToDateTime(sDate); ;

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
             ssql = "select top 1 djsj from yf_pdtemp where deptid=" + InstanceForm.BCurrentDept.DeptId + " and bdelete=0  order by id desc";
            DataTable tbtemp = InstanceForm.BDatabase.GetDataTable(ssql);

            SystemCfg s = new SystemCfg(8014);
            if (s.Config == "1" && tbtemp.Rows.Count>0)
            {
                if (Convert.ToDateTime(tbtemp.Rows[0]["djsj"]) > dtp1.Value)
                    Pd_shsj = tbtemp.Rows[0]["djsj"].ToString();
                else
                    Pd_shsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            }
            else
                Pd_shsj = sDate;
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
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_unymjz" && tb.Rows.Count > 0)
            {
                dtp1.Value = Convert.ToDateTime(tb.Rows[0]["ksrq"]);
                dtp2.Value = Convert.ToDateTime(tb.Rows[0]["jsrq"]);
                this._year = Convert.ToInt32(tb.Rows[0]["kjnf"]);
                this._month = Convert.ToInt32(tb.Rows[0]["kjyf"]) ;
                label2.Text = "开始时间";
                label3.Text = "结束时间";
                dtp2.Enabled = false;

                txtbz.Text = _year.ToString() + "年" + _month.ToString() + "月";
            }

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            if (Yp.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == true)
			{
				MessageBox.Show("您现在进入的是药房系统，请核实您当前登陆的科室是否正确","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
            }

            #region 先上传发药明细
            butsc_Click(sender, e);
            #endregion

            string stext = "";
            if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_unymjz")
            {
                #region 系统对账

                
                //系统对账
                this.Text = "正在进行系统对账.....";
                try
                {
                    this.Cursor = PubStaticFun.WaitCursor();

                    ParameterEx[] parameters = new ParameterEx[2];
                    parameters[0].Text = "@jsrq";
                    parameters[1].Text = "@deptid";
                    parameters[0].Value = dtp1.Value.ToString();// dtp1.Value.ToShortDateString();
                    parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                    DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_XTDZ", parameters, 60);
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

                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_xtdz")
                    {
                        MessageBox.Show("系统对帐完成");
                        this.Text = stext;
                        this.Close();
                        return;
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("出错" + err.Message);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }

                #endregion
            }

			#region 取消上次月结

			//取消上次月结
			if( _menuTag.Function_Name.Trim()=="Fun_ts_yf_unymjz" 
                && MessageBox.Show("您确定要取消 ["+ txtbz.Text +"] 这次月结吗 ？","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{
				this.Cursor=PubStaticFun.WaitCursor();
				this.Text="正在取消上次月结.....";
			
				try
				{
					int err_code=-1;
					string err_text="";

					InstanceForm.BDatabase.BeginTransaction();

					ParameterEx[] parameters=new ParameterEx[5];
					parameters[0].Text="@deptid";
					parameters[0].Value=InstanceForm.BCurrentDept.DeptId;

					parameters[1].Text="@djsj";
					parameters[1].Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

					parameters[2].Text="@djy";
					parameters[2].Value=InstanceForm.BCurrentUser.EmployeeId;
				
					parameters[3].Text="@err_code";
					parameters[3].ParaDirection=ParameterDirection.Output;
					parameters[3].DataType=System.Data.DbType.Int32;
					parameters[3].ParaSize=100;

					parameters[4].Text="@err_text";
					parameters[4].ParaDirection=ParameterDirection.Output;
					parameters[4].ParaSize=100;


                    InstanceForm.BDatabase.DoCommand("sp_Yf_unymjc", parameters, 60);
					err_code=Convert.ToInt32(parameters[3].Value);
					err_text=Convert.ToString(parameters[4].Value);

					if (err_code!=0) throw new Exception(err_text);
					InstanceForm.BDatabase.CommitTransaction();

					this.Text=stext;

                    #region 日志记录
                    string str_old = "";
                    str_old = InstanceForm.BCurrentUser.Name + "取消月结.上次月结时间是" + dtp1.Value.ToString() +" 到:"+dtp2.Value.ToString() ;
                    SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "取消月结", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                    systemLog.Save();
                    systemLog = null;
                    #endregion 

                    MessageBox.Show(err_text);
					this.Close();
					return;

				}
				catch(System.Exception err)
				{
					InstanceForm.BDatabase.RollbackTransaction();
					this.butok.Enabled=true;
					MessageBox.Show(err.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
			
				}
				finally
				{
					this.Cursor=Cursors.Arrow;
				}
				
			}
			#endregion 

			#region 月未结账

            if ( _menuTag.Function_Name.Trim() != "Fun_ts_yf_ymjz" )
                return;


			//月未结帐
			this.Text="正在进行月未结帐.....";
		
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

                butok.Enabled = false;
				this.Cursor=PubStaticFun.WaitCursor();
				int err_code=-1;
				string err_text="";
				
				InstanceForm.BDatabase.BeginTransaction();

				ParameterEx[] parameters=new ParameterEx[9];
				parameters[0].Text="@year";
				parameters[0].Value=_year;

				parameters[1].Text="@month";
				parameters[1].Value=_month;

				parameters[2].Text="@deptid";
				parameters[2].Value=InstanceForm.BCurrentDept.DeptId;

				parameters[3].Text="@ksrq";
                parameters[3].Value = dtp1.Value.ToString();//dtp1.Value.ToShortDateString();;

				parameters[4].Text="@jsrq";
                parameters[4].Value = dtp2.Value.ToString(); //dtp2.Value.ToShortDateString();

				parameters[5].Text="@djsj";
				parameters[5].Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

				parameters[6].Text="@djy";
				parameters[6].Value=InstanceForm.BCurrentUser.EmployeeId;
				
				parameters[7].Text="@err_code";
				parameters[7].ParaDirection=ParameterDirection.Output;
				parameters[7].DataType=System.Data.DbType.Int32;
				parameters[7].ParaSize=100;

				parameters[8].Text="@err_text";
				parameters[8].ParaDirection=ParameterDirection.Output;
				parameters[8].ParaSize=100;


                InstanceForm.BDatabase.DoCommand("sp_YF_ymjc", parameters, 60);
				err_code=Convert.ToInt32(parameters[7].Value);
				err_text=Convert.ToString(parameters[8].Value);


				if (err_code!=0) throw new System.Exception(err_text);
				
				InstanceForm.BDatabase.CommitTransaction();

                YMJC ymjc = new YMJC( InstanceForm.BDatabase );
                string message = "";
                bool bOk = ymjc.GenerateDetailData( InstanceForm.BCurrentDept.DeptId , _year , _month , out message );
                if ( !bOk )
                {
                    this.Text = stext;
                    MessageBox.Show( "月结成功，但生成中间表数据失败，请联系管理员处理" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    butok.Enabled = true;
                    this.Close();
                    return;
                }

			    this.Text=stext;
				MessageBox.Show(err_text);
                butok.Enabled = true;
				this.Close();

			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				this.butok.Enabled=true;
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
			#endregion

		}

		
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmbmonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			_month=Convert.ToInt32(cmbmonth.Text);
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
			_year=Convert.ToInt32(cmbyear.Text);
			txtbz.Text=_year.ToString()+"年"+_month.ToString()+"月";
		}

		private void butsc_Click(object sender, System.EventArgs e)
		{
            if (Yp.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == true)
			{
				MessageBox.Show("您现在进入的是药房系统，请核实您当前登陆的科室是否正确","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			#region 上传发药明细表的数据
			string stext=this.Text.Trim();
			//上传发药明细表的数据
			//this.Cursor =Cursors.WaitCursor;
			this.Text="正在上传处方发药明细.....";
			
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				int err_code=-1;
				string err_text="";
			
				InstanceForm.BDatabase.BeginTransaction();

				string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
				ParameterEx[] parameters=new ParameterEx[8];
				parameters[0].Text="@djrq";
				parameters[0].Value=Convert.ToDateTime(sDate).ToShortDateString();

				parameters[1].Text="@djsj";
				parameters[1].Value=Convert.ToDateTime(sDate).ToLongTimeString();

				parameters[2].Text="@djy";
				parameters[2].Value=InstanceForm.BCurrentUser.EmployeeId;

				parameters[3].Text="@deptid";
				parameters[3].Value=InstanceForm.BCurrentDept.DeptId;

				parameters[4].Text="@endrq";
				parameters[4].Value=dtpendrq.Value.ToShortDateString();
				
				parameters[5].Text="@err_code";
				parameters[5].ParaDirection=ParameterDirection.Output;
				parameters[5].DataType=System.Data.DbType.Int32;
				parameters[5].ParaSize=100;

				parameters[6].Text="@err_text";
				parameters[6].ParaDirection=ParameterDirection.Output;
				parameters[6].ParaSize=100;

                parameters[7].Text = "@jgbm";
                parameters[7].Value = InstanceForm._menuTag.Jgbm;


                InstanceForm.BDatabase.DoCommand("SP_YF_fymx_dj", parameters, 30);
				err_code=Convert.ToInt32(parameters[5].Value);
				err_text=Convert.ToString(parameters[6].Value);

				//更新处方上传日期
				string rq=this.dtpendrq.Value.ToShortDateString()+" "+System.DateTime.Now.ToLongTimeString();
				string ssql="update yp_yjks set cfscrq='"+rq+"' where deptid="+InstanceForm.BCurrentDept.DeptId+"";
				InstanceForm.BDatabase.DoCommand(ssql);


				InstanceForm.BDatabase.CommitTransaction();

				this.lblscscrq.Text=rq.Trim();
                this.Text = "上传处方记录成功";
				//MessageBox.Show("上传处方记录成功");

			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show("在上传发药明细时发生错误"+err.Message);
				return;
			}	
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
			#endregion 
		}


	}
}
