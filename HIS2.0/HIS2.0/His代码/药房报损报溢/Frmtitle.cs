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

namespace ts_yf_bsby
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmtitle : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.Button butnew;
		private System.Windows.Forms.Button butclose;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.CheckBox chkdjsj;
		private System.Windows.Forms.TextBox txtdjh;
		private System.Windows.Forms.CheckBox chkdjh;
		private System.Windows.Forms.Button butref;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.Button butsh;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private MenuTag _menuTag;
		private string _chineseName;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private Form _mdiParent;

		public Frmtitle(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=chineseName;
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.myDataGrid1 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel4 = new System.Windows.Forms.Panel();
			this.butsh = new System.Windows.Forms.Button();
			this.butclose = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.butnew = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dtp2 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.dtp1 = new System.Windows.Forms.DateTimePicker();
			this.chkdjsj = new System.Windows.Forms.CheckBox();
			this.txtdjh = new System.Windows.Forms.TextBox();
			this.chkdjh = new System.Windows.Forms.CheckBox();
			this.butref = new System.Windows.Forms.Button();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.panel3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(832, 485);
			this.panel1.TabIndex = 0;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.myDataGrid1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(0, 72);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(832, 357);
			this.panel5.TabIndex = 3;
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid1.CaptionVisible = false;
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.ReadOnly = true;
			this.myDataGrid1.Size = new System.Drawing.Size(832, 357);
			this.myDataGrid1.TabIndex = 0;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
			this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn7});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "序号";
			this.dataGridTextBoxColumn1.MappingName = "";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 50;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "单据号";
			this.dataGridTextBoxColumn2.MappingName = "";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 80;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "单据日期";
			this.dataGridTextBoxColumn3.MappingName = "";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "批发金额";
			this.dataGridTextBoxColumn10.MappingName = "";
			this.dataGridTextBoxColumn10.Width = 65;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "零售金额";
			this.dataGridTextBoxColumn9.MappingName = "";
			this.dataGridTextBoxColumn9.Width = 65;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "登记时间";
			this.dataGridTextBoxColumn5.MappingName = "";
			this.dataGridTextBoxColumn5.NullText = "";
			this.dataGridTextBoxColumn5.ReadOnly = true;
			this.dataGridTextBoxColumn5.Width = 120;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "登记员";
			this.dataGridTextBoxColumn6.MappingName = "";
			this.dataGridTextBoxColumn6.NullText = "";
			this.dataGridTextBoxColumn6.ReadOnly = true;
			this.dataGridTextBoxColumn6.Width = 75;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "原因";
			this.dataGridTextBoxColumn4.MappingName = "";
			this.dataGridTextBoxColumn4.NullText = "";
			this.dataGridTextBoxColumn4.ReadOnly = true;
			this.dataGridTextBoxColumn4.Width = 150;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "备注";
			this.dataGridTextBoxColumn7.MappingName = "";
			this.dataGridTextBoxColumn7.NullText = "";
			this.dataGridTextBoxColumn7.ReadOnly = true;
			this.dataGridTextBoxColumn7.Width = 75;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.butsh);
			this.panel4.Controls.Add(this.butclose);
			this.panel4.Controls.Add(this.statusBar1);
			this.panel4.Controls.Add(this.butnew);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 429);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(832, 56);
			this.panel4.TabIndex = 2;
			// 
			// butsh
			// 
			this.butsh.Location = new System.Drawing.Point(532, 6);
			this.butsh.Name = "butsh";
			this.butsh.Size = new System.Drawing.Size(88, 24);
			this.butsh.TabIndex = 5;
			this.butsh.Text = "查看(&E)";
			this.butsh.Click += new System.EventHandler(this.butsh_Click);
			// 
			// butclose
			// 
			this.butclose.Location = new System.Drawing.Point(622, 6);
			this.butclose.Name = "butclose";
			this.butclose.Size = new System.Drawing.Size(88, 24);
			this.butclose.TabIndex = 3;
			this.butclose.Text = "关闭(&Q)";
			this.butclose.Click += new System.EventHandler(this.butclose_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 32);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(832, 24);
			this.statusBar1.TabIndex = 1;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Width = 200;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Width = 1000;
			// 
			// butnew
			// 
			this.butnew.Location = new System.Drawing.Point(440, 6);
			this.butnew.Name = "butnew";
			this.butnew.Size = new System.Drawing.Size(88, 24);
			this.butnew.TabIndex = 0;
			this.butnew.Text = "新单据(&N)";
			this.butnew.Click += new System.EventHandler(this.butnew_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.groupBox1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(832, 72);
			this.panel3.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(832, 72);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "查询";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dtp2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.dtp1);
			this.panel2.Controls.Add(this.chkdjsj);
			this.panel2.Controls.Add(this.txtdjh);
			this.panel2.Controls.Add(this.chkdjh);
			this.panel2.Controls.Add(this.butref);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 17);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(826, 52);
			this.panel2.TabIndex = 2;
			// 
			// dtp2
			// 
			this.dtp2.Enabled = false;
			this.dtp2.Location = new System.Drawing.Point(216, 12);
			this.dtp2.Name = "dtp2";
			this.dtp2.Size = new System.Drawing.Size(110, 21);
			this.dtp2.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(204, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "到";
			// 
			// dtp1
			// 
			this.dtp1.Enabled = false;
			this.dtp1.Location = new System.Drawing.Point(92, 12);
			this.dtp1.Name = "dtp1";
			this.dtp1.Size = new System.Drawing.Size(111, 21);
			this.dtp1.TabIndex = 9;
			// 
			// chkdjsj
			// 
			this.chkdjsj.Location = new System.Drawing.Point(20, 12);
			this.chkdjsj.Name = "chkdjsj";
			this.chkdjsj.Size = new System.Drawing.Size(80, 22);
			this.chkdjsj.TabIndex = 8;
			this.chkdjsj.Text = "登记时间";
			this.chkdjsj.CheckedChanged += new System.EventHandler(this.chkshdh_CheckedChanged);
			// 
			// txtdjh
			// 
			this.txtdjh.Enabled = false;
			this.txtdjh.Location = new System.Drawing.Point(392, 12);
			this.txtdjh.Name = "txtdjh";
			this.txtdjh.Size = new System.Drawing.Size(64, 21);
			this.txtdjh.TabIndex = 7;
			this.txtdjh.Text = "";
			// 
			// chkdjh
			// 
			this.chkdjh.Location = new System.Drawing.Point(336, 12);
			this.chkdjh.Name = "chkdjh";
			this.chkdjh.Size = new System.Drawing.Size(73, 22);
			this.chkdjh.TabIndex = 6;
			this.chkdjh.Text = "单据号";
			this.chkdjh.CheckedChanged += new System.EventHandler(this.chkshdh_CheckedChanged);
			// 
			// butref
			// 
			this.butref.Location = new System.Drawing.Point(688, 8);
			this.butref.Name = "butref";
			this.butref.Size = new System.Drawing.Size(88, 24);
			this.butref.TabIndex = 4;
			this.butref.Text = "刷新(&R)";
			this.butref.Click += new System.EventHandler(this.butref_Click);
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "进货金额";
			this.dataGridTextBoxColumn8.MappingName = "";
			this.dataGridTextBoxColumn8.NullText = "";
			this.dataGridTextBoxColumn8.Width = 65;
			// 
			// Frmtitle
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(832, 485);
			this.Controls.Add(this.panel1);
			this.Location = new System.Drawing.Point(200, 600);
			this.Name = "Frmtitle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "药品报损";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Frmtitle_Load);
			this.Activated += new System.EventHandler(this.Frmtitle_Activated);
			this.panel1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.panel3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void butnew_Click(object sender, System.EventArgs e)
		{
            if (YpConfig.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == true)
            {
                MessageBox.Show("您的登陆科室是药库,但进入了药房系统", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


			Frmypbsby f=new Frmypbsby(_menuTag,_chineseName,_mdiParent);
			Point point=new Point(160,75 );
			f.Location=point;
			f.MdiParent=_mdiParent;
			f.Show();
		}

		private void chkshdh_CheckedChanged(object sender, System.EventArgs e)
		{
			this.txtdjh.Enabled=chkdjh.Checked==true?true:false;
			this.dtp1.Enabled=chkdjsj.Checked==true?true:false;
			this.dtp2.Enabled=chkdjsj.Checked==true?true:false;
		}

		private void Frmtitle_Load(object sender, System.EventArgs e)
		{
			this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.chkdjsj.Checked=true;
			//初始化
			DataTable myTb=new DataTable();
			myTb.TableName="Tb";
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
		}

		private void butref_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtdjh.Text.Trim()=="" && txtdjh.Enabled==true) {MessageBox.Show("请输入单据号");return;}
				ParameterEx[] parameters=new ParameterEx[11];
				parameters[0].Value=_menuTag.FunctionTag.Trim();
				parameters[1].Value=0;
				parameters[2].Value=chkdjsj.Checked==true?dtp1.Value.ToShortDateString():"";
				parameters[3].Value=chkdjsj.Checked==true?dtp2.Value.ToShortDateString():"";
				parameters[4].Value=chkdjh.Checked==true?Convert.ToInt64(Convertor.IsNull(txtdjh.Text,"0")):0;
				parameters[5].Value="";
				parameters[6].Value="";
				parameters[7].Value=1;
				parameters[8].Value=InstanceForm.BCurrentDept.DeptId;
				parameters[9].Value=_menuTag.Function_Name;
                parameters[10].Value = 0;

				parameters[0].Text="@ywlx";
				parameters[1].Text="@wldw";
				parameters[2].Text="@dtp1";
				parameters[3].Text="@dtp2";
				parameters[4].Text="@djh";
				parameters[5].Text="@fph";
				parameters[6].Text="@shdh";
				parameters[7].Text="@shbz";
				parameters[8].Text="@deptid";
				parameters[9].Text="@functionname";
                parameters[10].Text = "@P_deptid";
				DataTable tb=InstanceForm.BDatabase.GetDataTable("sp_yf_selectDj",parameters,30);
				FunBase.AddRowtNo(tb);

				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
				FunBase.myGridSelect(this.myDataGrid1,this.myDataGrid1.TableStyles[0].GridColumnStyles);
				this.dataGridTableStyle1.ForeColor=System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString());
			}

		}

		private void butsh_Click(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (tb.Rows.Count==0) return;
				Frmypbsby f=new  Frmypbsby(_menuTag,_chineseName,_mdiParent);
				Point point=new Point(160,75 );
				f.Location=point;
				f.MdiParent=_mdiParent;
				f.Show();
				f.FillDj(new Guid(tb.Rows[nrow]["id"].ToString()),true);
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}

		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void rdo2_CheckedChanged(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
		}

		private void Frmtitle_Activated(object sender, System.EventArgs e)
		{
		  this.butref_Click(sender,e);
		}

		private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			butsh_Click(sender,e);
		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{

			this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);
		}

	}
}
