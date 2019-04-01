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

namespace ts_yk_tjbb
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmjhpm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton rdosl;
		private System.Windows.Forms.RadioButton rdoje;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.TextBox txtnum;
		private System.Windows.Forms.Button buttj;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbyplx;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.RadioButton rdojhje;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
        private ComboBox cmbyjks;
        private Label label6;
        private ComboBox cmbck;
        private Label lblck;
        private Button butexcel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmjhpm(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.lblck = new System.Windows.Forms.Label();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdojhje = new System.Windows.Forms.RadioButton();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoje = new System.Windows.Forms.RadioButton();
            this.rdosl = new System.Windows.Forms.RadioButton();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.butexcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butexcel);
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.lblck);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rdojhje);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtnum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdoje);
            this.groupBox1.Controls.Add(this.rdosl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Location = new System.Drawing.Point(274, 16);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(123, 20);
            this.cmbck.TabIndex = 36;
            // 
            // lblck
            // 
            this.lblck.Location = new System.Drawing.Point(221, 21);
            this.lblck.Name = "lblck";
            this.lblck.Size = new System.Drawing.Size(67, 16);
            this.lblck.TabIndex = 35;
            this.lblck.Text = "仓库名称";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(85, 17);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(130, 20);
            this.cmbyjks.TabIndex = 30;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(22, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "药剂科室";
            // 
            // rdojhje
            // 
            this.rdojhje.Location = new System.Drawing.Point(597, 13);
            this.rdojhje.Name = "rdojhje";
            this.rdojhje.Size = new System.Drawing.Size(115, 24);
            this.rdojhje.TabIndex = 14;
            this.rdojhje.Text = "按进货金额排名";
            // 
            // cmbyplx
            // 
            this.cmbyplx.Location = new System.Drawing.Point(85, 46);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(129, 20);
            this.cmbyplx.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "药品类型";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(852, 39);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(72, 32);
            this.butquit.TabIndex = 11;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(780, 39);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(72, 32);
            this.butprint.TabIndex = 10;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(700, 39);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(78, 32);
            this.buttj.TabIndex = 9;
            this.buttj.Text = "统计(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(595, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "名的药品";
            // 
            // txtnum
            // 
            this.txtnum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtnum.ForeColor = System.Drawing.Color.Blue;
            this.txtnum.Location = new System.Drawing.Point(554, 46);
            this.txtnum.Name = "txtnum";
            this.txtnum.Size = new System.Drawing.Size(42, 23);
            this.txtnum.TabIndex = 7;
            this.txtnum.Text = "10";
            this.txtnum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtnum_KeyUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(539, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "前";
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(408, 46);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(112, 21);
            this.dtp2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(388, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(274, 46);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(109, 21);
            this.dtp1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(222, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "日期从";
            // 
            // rdoje
            // 
            this.rdoje.Location = new System.Drawing.Point(486, 13);
            this.rdoje.Name = "rdoje";
            this.rdoje.Size = new System.Drawing.Size(115, 24);
            this.rdoje.TabIndex = 1;
            this.rdoje.Text = "按零售金额排名";
            // 
            // rdosl
            // 
            this.rdosl.Checked = true;
            this.rdosl.Location = new System.Drawing.Point(403, 13);
            this.rdosl.Name = "rdosl";
            this.rdosl.Size = new System.Drawing.Size(87, 24);
            this.rdosl.TabIndex = 0;
            this.rdosl.TabStop = true;
            this.rdosl.Text = "按数量排名";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(944, 23);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 1000;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 422);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "排名情况";
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
            this.myDataGrid1.Size = new System.Drawing.Size(938, 402);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn10});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "排名";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "厂家";
            this.dataGridTextBoxColumn5.Width = 80;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "进价";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 70;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "批发价";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "零售价";
            this.dataGridTextBoxColumn7.Width = 70;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "数量";
            this.dataGridTextBoxColumn8.Width = 70;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "单位";
            this.dataGridTextBoxColumn4.Width = 40;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "进货金额";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 90;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "批发金额";
            this.dataGridTextBoxColumn11.Width = 0;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "零售金额";
            this.dataGridTextBoxColumn9.Width = 90;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "进零差额";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 80;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "货号";
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(780, 5);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(72, 32);
            this.butexcel.TabIndex = 41;
            this.butexcel.Text = "导出(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // Frmjhpm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmjhpm";
            this.Text = "进货排名统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmxspm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>


		private void txtnum_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (Convertor.IsNumeric(txtnum.Text)==false) txtnum.Text="";
		}

		private void Frmxspm_Load(object sender, System.EventArgs e)
		{
			try
			{
				dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);;
				dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				

				//初始化
				DataTable myTb=new DataTable();
				myTb.TableName="Tb";
				for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
				{	
					if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,typeof(bool));
					else
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText="";
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
				}
				this.myDataGrid1.DataSource=myTb;
				this.myDataGrid1.TableStyles[0].MappingName ="Tb";

                Yp.AddCmbYjks(false, InstanceForm.BCurrentDept.DeptId, cmbyjks, InstanceForm.BDatabase);
                //Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbyplx, InstanceForm.BDatabase);

			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}


		}

		private void buttj_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Convert.ToInt32(Convertor.IsNull(txtnum.Text,"0"))==0){MessageBox.Show("请输入排名");return;}
				int ntype=0;
				if (rdosl.Checked==true) ntype=0;
				if (rdoje.Checked==true) ntype=1;
				if (rdojhje.Checked==true) ntype=2;

				ParameterEx[] parameters=new ParameterEx[7];
				parameters[0].Value=ntype;
				parameters[1].Value=Convert.ToInt32(cmbyplx.SelectedValue);
				parameters[2].Value=dtp1.Value.ToShortDateString();
				parameters[3].Value=dtp2.Value.ToShortDateString();
				parameters[4].Value=Convert.ToInt32(Convertor.IsNull(txtnum.Text,"0"));
                parameters[5].Value = Convert.ToInt32(cmbyjks.SelectedValue);

				parameters[0].Text="@type";
				parameters[1].Text="@yplx";
				parameters[2].Text="@dtp1";
				parameters[3].Text="@dtp2";
				parameters[4].Text="@mc";
				parameters[5].Text="@deptid";
                parameters[6].Text = "@deptid_ck";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));

				DataTable tb=InstanceForm.BDatabase.GetDataTable("SP_YK_tj_jhpmtj",parameters,30);
				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;

				decimal sumjhje=0;
				decimal sumpfje=0;
				decimal sumlsje=0;
				decimal sumplce=0;
				decimal sumjlce=0;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					sumjhje=sumlsje+Convert.ToDecimal(tb.Rows[i]["进货金额"]);
					sumpfje=sumpfje+Convert.ToDecimal(tb.Rows[i]["批发金额"]);
					sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["零售金额"]);
				}
				sumplce=sumlsje-sumpfje;
				sumjlce=sumlsje-sumjhje;
				this.statusBar1.Panels[0].Text="进货金额 "+sumjhje.ToString("0.00");
				this.statusBar1.Panels[1].Text="零售金额 "+sumlsje.ToString("0.00");
				this.statusBar1.Panels[2].Text="进零差额 "+sumjlce.ToString("0.00");;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string yplx=cmbyplx.Text.Trim();
				string rq1=dtp1.Value.ToShortDateString();
				string rq2=dtp2.Value.ToShortDateString();
				string pmlx="";
				if (rdosl.Checked==true) pmlx=rdosl.Text.Trim();
				if (rdoje.Checked==true) pmlx=rdoje.Text.Trim();
				if (rdojhje.Checked==true) pmlx=rdojhje.Text.Trim();
				string pmws=txtnum.Text.Trim();

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset1 Dset=new ts_Yk_ReportView.Dataset1();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.进出货排名统计.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["排名"]);
					myrow["ypspm"]=Convert.ToString(tb.Rows[i]["品名"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
					myrow["pfj"]=Convert.ToDecimal(tb.Rows[i]["批发价"]);
					myrow["lsj"]=Convert.ToDecimal(tb.Rows[i]["零售价"]);
					myrow["ypsl"]=Convert.ToDecimal(tb.Rows[i]["数量"]);
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
					myrow["jhje"]=Convert.ToString(tb.Rows[i]["进货金额"]);
					myrow["pfje"]=Convert.ToString(tb.Rows[i]["批发金额"]);
					myrow["lsje"]=Convert.ToString(tb.Rows[i]["零售金额"]);
					myrow["plce"]=Convert.ToDecimal(tb.Rows[i]["零售金额"])-Convert.ToDecimal(tb.Rows[i]["批发金额"]);
					myrow["jlce"]=Convert.ToDecimal(tb.Rows[i]["零售金额"])-Convert.ToDecimal(tb.Rows[i]["进货金额"]);
					myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
					Dset.进出货排名统计.Rows.Add(myrow);

				}
				ParameterEx[] parameters=new ParameterEx[7];
				parameters[0].Text="yplx";
				parameters[0].Value=yplx.Trim();
				parameters[1].Text="rq1";
				parameters[1].Value=rq1.Trim();
				parameters[2].Text="rq2";
				parameters[2].Value=rq2.Trim();
				parameters[3].Text="pmlx";
				parameters[3].Value=pmlx.Trim();
				parameters[4].Text="pmws";
				parameters[4].Value=pmws.Trim();
				parameters[5].Text="TITLETEXT";
				parameters[5].Value=TrasenFrame.Classes.Constant.HospitalName+"("+cmbyjks.Text.Trim()+")"+this.Text;
                parameters[6].Text = "ckmc";
                parameters[6].Value = cmbck.Text.Trim();

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.进出货排名统计 ,Constant.ApplicationDirectory+"\\Report\\YK_进货排名统计.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbyplx, InstanceForm.BDatabase);


            Yp.AddCmbYjks_ck(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbck, InstanceForm.BDatabase);
            if (cmbck.Items.Count == 1)
            {
                cmbck.Visible = false;
                lblck.Visible = false;
            }
            else
            {
                cmbck.Visible = true;
                lblck.Visible = true;
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                #region 简单打印

                this.butexcel.Enabled = false;
                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string title = "排名方式:";
                if (rdoje.Checked == true)
                    title = title + "按金额排名";
                if (rdosl.Checked == true)
                    title = title + "按数量排名";
                if (rdojhje.Checked == true)
                    title = title + "按进货金额排名";
                string where1 = "";


                where1 = "药剂科室:" + cmbyjks.Text.Trim() + " 仓库名称:" + cmbck.Text.Trim();
                where1 = where1 + " 日期:" + dtp1.Value.ToShortDateString() + " 到:" + dtp2.Value.ToShortDateString() + "";
                where1 = where1 + " 药品类型:" + cmbyplx.Text + "  ";
                where1 = where1 + title;

                //写入行头
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = tb.Columns.Count;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    myExcel.Cells[5, 1 + j] = tb.Columns[j].ColumnName;

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        myExcel.Cells[6 + i, 1 + j] = "" + tb.Rows[i][j].ToString();
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "进货排名统计";
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3, 1] = where1.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //让Excel文件可见
                myExcel.Visible = true;
                this.butexcel.Enabled = true;
                #endregion
            }
            catch (System.Exception err)
            {
                this.butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
        }



	}
}
