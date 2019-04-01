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
namespace ts_yp_xtwh
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmkcsxx : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		public myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtdm;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butquit;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox chkall;
        private ComboBox cmbyjks;
        private Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


		public Frmkcsxx(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;
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
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 462);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(827, 23);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 300;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "查找药品时,请输入内容后回车";
            this.statusBarPanel2.Width = 1001;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(821, 378);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 80;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "批发价";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "零售价";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "库存量";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 70;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "单位";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 40;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "上限";
            this.dataGridTextBoxColumn9.Width = 60;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "下限";
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "货号";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 60;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "cjid";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "kcsxxid";
            this.dataGridTextBoxColumn13.Width = 0;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "nypdw";
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "dwbl";
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butsave);
            this.groupBox1.Controls.Add(this.txtdm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkall);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 398);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 64);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // chkall
            // 
            this.chkall.Location = new System.Drawing.Point(348, 22);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(96, 24);
            this.chkall.TabIndex = 6;
            this.chkall.Text = "所有药品";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "根据销售量更新上下限(&V)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(718, 16);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(96, 32);
            this.butquit.TabIndex = 4;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(614, 16);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(96, 32);
            this.butsave.TabIndex = 2;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // txtdm
            // 
            this.txtdm.Location = new System.Drawing.Point(230, 24);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(112, 21);
            this.txtdm.TabIndex = 1;
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdm_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(199, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(827, 398);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存上下限设置";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(60, 22);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(117, 20);
            this.cmbyjks.TabIndex = 11;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "药剂科室";
            // 
            // Frmkcsxx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(827, 485);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar1);
            this.Name = "Frmkcsxx";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmsccj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void Frmsccj_Load(object sender, System.EventArgs e)
		{
			try
			{
				//初始化
				DataTable myTb=new DataTable();
			
				for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
				{	
					if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
					else
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText="";
				}

				this.myDataGrid1.DataSource=myTb;
				this.myDataGrid1.TableStyles[0].MappingName ="Tb";

                if (_menuTag.Function_Name == "Fun_ts_yp_xtwh_kcsxx")
                    Yp.AddcmbYjks(cmbyjks, DeptType.药库, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                else
                    Yp.AddcmbYjks(cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

                if (InstanceForm.BCurrentUser.IsAdministrator == false) { cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId; cmbyjks.Enabled = false; }
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		public  void AddData(string ss,myDataGrid.myDataGrid mydataGrid)
		{
			DataTable myTb=new DataTable();
			string ssql="";
			ssql="select kslx from yp_yjks where deptid="+Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue,"0"))+"";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
            {

                MessageBox.Show("设置库存上下限时,请以药房药库身份登陆","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
			string tablename="";
            string kslx = "";
            if (tb.Rows.Count > 0)
                kslx = tb.Rows[0]["kslx"].ToString().Trim();
			if (kslx=="药房") tablename="yf_kcmx";else tablename="yk_kcmx";
			if (chkall.Checked==false)
			{
				ssql="select 0 序号,yppm 品名,ypgg 规格,s_sccj 厂家,pfj 批发价,lsj 零售价,cast(kcl/dwbl as float) 库存量,"+
                    " dbo.fun_yp_ypdw(ypdw) 单位,(case when kcsx=0  then null else kcsx end) 上限,(case when kcxx=0  then null else kcxx end) 下限,shh 货号,a.cjid,c.id kcsxxid,ypdw nypdw,1 dwbl " +
                    " from " + tablename.Trim() + " a inner join vi_yp_ypcd b on a.cjid=b.cjid and a.bdelete=0 and a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) +
                    " left join (select * from yp_kcsxx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) + ") c on b.cjid=c.cjid " +
                    "where a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) + "";
				if (ss.Trim()!="")
					ssql=ssql+" and A.ggid in(select ggid from yp_ypbm where upper(pym) like '"+ss.Trim().ToUpper()+"%'  or ypbm like '%"+ss.Trim()+"%')";
			}
			else
			{
				//if (tb.Rows[0]["kslx"].ToString().Trim()=="药房") tablename="yf_kcmx";else tablename="yk_kcmx";
				ssql="select 0 序号,yppm 品名,ypgg 规格,s_sccj 厂家,pfj 批发价,lsj 零售价,cast(kcl/dwbl as float) 库存量,"+
                    " dbo.fun_yp_ypdw(ypdw) 单位,(case when kcsx=0  then null else kcsx end) 上限,(case when kcxx=0  then null else kcxx end) 下限,shh 货号,a.cjid,c.id kcsxxid,ypdw nypdw,1 dwbl " +
                    " from " + tablename.Trim() + " a inner join vi_yp_ypcd b on a.cjid=b.cjid and a.bdelete=0 and a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) +
                    " left join (select * from yp_kcsxx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) + ") c on b.cjid=c.cjid " +
					" where a.ggid>0 ";
				if (ss.Trim()!="")
					ssql=ssql+" and A.ggid in(select ggid from yp_ypbm where upper(pym) like '"+ss.Trim().ToUpper()+"%'  or ypbm like '%"+ss.Trim()+"%')";

				ssql=ssql+"  union all select 0 序号,yppm 品名,ypgg 规格,s_sccj 厂家,pfj 批发价,lsj 零售价,0 库存量,"+
                    " dbo.fun_yp_ypdw(ypdw) 单位,(case when kcsx=0  then null else kcsx end) 上限,(case when kcxx=0  then null else kcxx end) 下限,shh 货号,a.cjid,coalesce(B.id,0) kcsxxid,ypdw nypdw,1 dwbl " +
                    " from vi_yp_ypcd a left join (select * from yp_kcsxx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) + ") b on a.cjid=b.cjid " +
                    "where  a.ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) + ") and a.cjid not in(select cjid  from " + tablename.Trim() + " where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) + ")  ";
				if (ss.Trim()!="")
					ssql=ssql+" and A.ggid in(select ggid from yp_ypbm where upper(pym) like '"+ss.Trim().ToUpper()+"%' or ypbm like '%"+ss.Trim()+"%')";
			}


			myTb=InstanceForm.BDatabase.GetDataTable(ssql);
			FunBase.AddRowtNo(myTb);
			myTb.TableName="Tb";
			mydataGrid.DataSource=myTb;
			mydataGrid.TableStyles[0].MappingName ="Tb";

		}

		private void txtdm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if (Convert.ToInt32(e.KeyCode)==13)
				{
					this.AddData(txtdm.Text.Trim(),this.myDataGrid1);
				
					this.txtdm.Focus();
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butsave_Click(object sender, System.EventArgs e)
		{


			try
			{
				this.butsave.Enabled=false;
				InstanceForm.BDatabase.BeginTransaction();

				string ssql="";
				int cjid=0;decimal kcsx=0;decimal kcxx=0;int nypdw=0;int ydwbl=0;long kcsxxid=0;

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{

					cjid=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["cjid"],"0"));
					kcsx=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["上限"],"0"));
					kcxx=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["下限"],"0"));
					nypdw=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["nypdw"],"0"));
					ydwbl=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["dwbl"],"0"));
					kcsxxid=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["kcsxxid"],"0"));

					if (kcsxxid==0)
					{
                        ssql = "insert into yp_kcsxx(cjid,kcsx,kcxx,nypdw,ydwbl,deptid) values(" + cjid + "," + kcsx + "," + kcxx + "," + nypdw + "," + ydwbl + "," + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) + ") ";
					}
					else
					{
                        ssql = "update yp_kcsxx set kcsx=" + kcsx + ",kcxx=" + kcxx + ",nypdw=" + nypdw + ",ydwbl=" + ydwbl + " where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")) + " and cjid=" + cjid + "";
					}
						InstanceForm.BDatabase.DoCommand(ssql);
				}

				InstanceForm.BDatabase.CommitTransaction();
				MessageBox.Show("保存成功");
				this.butsave.Enabled=true;
				this.AddData("",this.myDataGrid1);
			}
			catch(System.Exception err)
			{
				this.butsave.Enabled=true;
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Frmkcsxx1 f=new Frmkcsxx1(_menuTag,_chineseName,_mdiParent,Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue,"0")));
			Point point=new Point(160,75 );
			f.Location=point;
			f.ShowDialog();
			this.AddData("",this.myDataGrid1);
		}

        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.AddData("", this.myDataGrid1);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


	}
}
