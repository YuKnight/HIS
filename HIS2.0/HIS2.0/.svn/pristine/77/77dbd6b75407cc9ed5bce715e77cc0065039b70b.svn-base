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
namespace ts_yf_tjbb
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmcffy_jy : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rdosl;
		private System.Windows.Forms.RadioButton rdoje;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Button buttj;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
        private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private ComboBox cmbyjks;
        private Label label4;
        private Label label6;
        private TextBox txtdm;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        public Frmcffy_jy(MenuTag menuTag, string chineseName, Form mdiParent)
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rdosl = new System.Windows.Forms.RadioButton();
            this.rdoje = new System.Windows.Forms.RadioButton();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
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
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtdm);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdosl);
            this.groupBox1.Controls.Add(this.rdoje);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "药品代码";
            // 
            // txtdm
            // 
            this.txtdm.Location = new System.Drawing.Point(345, 44);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(109, 21);
            this.txtdm.TabIndex = 25;
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(437, 12);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(115, 20);
            this.cmbyjks.TabIndex = 24;
            this.cmbyjks.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(382, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "药剂科室";
            this.label4.Visible = false;
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(685, 33);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(65, 32);
            this.butquit.TabIndex = 11;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(621, 33);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(64, 32);
            this.butprint.TabIndex = 10;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(558, 33);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(63, 32);
            this.buttj.TabIndex = 9;
            this.buttj.Text = "统计(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(171, 44);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(109, 21);
            this.dtp2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(153, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "到";
            this.label2.Visible = false;
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(41, 44);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(109, 21);
            this.dtp1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "日期";
            // 
            // rdosl
            // 
            this.rdosl.Checked = true;
            this.rdosl.Location = new System.Drawing.Point(99, 14);
            this.rdosl.Name = "rdosl";
            this.rdosl.Size = new System.Drawing.Size(85, 24);
            this.rdosl.TabIndex = 0;
            this.rdosl.TabStop = true;
            this.rdosl.Text = "按药品汇总";
            this.rdosl.CheckedChanged += new System.EventHandler(this.rdoje_CheckedChanged);
            // 
            // rdoje
            // 
            this.rdoje.Location = new System.Drawing.Point(14, 14);
            this.rdoje.Name = "rdoje";
            this.rdoje.Size = new System.Drawing.Size(88, 24);
            this.rdoje.TabIndex = 1;
            this.rdoje.Text = "按金额汇总";
            this.rdoje.CheckedChanged += new System.EventHandler(this.rdoje_CheckedChanged);
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
            this.groupBox2.Location = new System.Drawing.Point(0, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 420);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计情况";
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
            this.myDataGrid1.Size = new System.Drawing.Size(938, 400);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1,
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn13});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "病区";
            this.dataGridTextBoxColumn14.Width = 120;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "货号";
            this.dataGridTextBoxColumn12.Width = 60;
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
            this.dataGridTextBoxColumn3.HeaderText = "商品名";
            this.dataGridTextBoxColumn3.Width = 120;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "规格";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "厂家";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "数量";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "单位";
            this.dataGridTextBoxColumn8.Width = 40;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "金额";
            this.dataGridTextBoxColumn13.Width = 70;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "序号";
            this.dataGridTextBoxColumn4.Width = 40;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "病区";
            this.dataGridTextBoxColumn9.Width = 150;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "单据张数";
            this.dataGridTextBoxColumn10.Width = 0;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "金额";
            this.dataGridTextBoxColumn11.Width = 140;
            // 
            // Frmcffy_jy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmcffy_jy";
            this.Text = "住院领药汇总统计";
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


		private void Frmxspm_Load(object sender, System.EventArgs e)
		{
			try
			{
				dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);


				//初始化
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

                Yp.AddcmbYjks(cmbyjks, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

                if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase) != DeptType.未知)
                {
                    cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    cmbyjks.Enabled = false;
                }
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
				this.Cursor=PubStaticFun.WaitCursor();
				this.buttj.Enabled=false;
				ParameterEx[] parameters=new ParameterEx[5];
                parameters[0].Value = dtp1.Value.ToShortDateString();
                parameters[1].Value = dtp2.Value.ToShortDateString();
                parameters[2].Value = InstanceForm.BCurrentDept.DeptId;
                parameters[3].Value = Convert.ToInt32(Convertor.IsNull(txtdm.Tag,"0"));
                parameters[4].Value = this.rdoje.Checked == true ? 1 : 0;

				parameters[0].Text= "@dtp1";
                parameters[1].Text = "@dtp2";
				parameters[2].Text="@deptid";
				parameters[3].Text="@cjid";
                parameters[4].Text = "@type";


                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_tj_zyjytj", parameters, 30);
				FunBase.AddRowtNo(tb);
				if (this.rdosl.Checked==true)
					tb.TableName="Tb";
				else
					tb.TableName="Tb1";
				this.myDataGrid1.DataSource=tb;

				decimal sumlsje=0;
				decimal sumzs=0;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (rdoje.Checked==true) 
                        sumzs=sumzs+Convert.ToDecimal(tb.Rows[i]["单据张数"]);
                    else
                        sumzs = sumzs + Convert.ToDecimal(tb.Rows[i]["数量"]);
					sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["金额"]);
				}
                if (rdoje.Checked == true) this.statusBar1.Panels[0].Text = "总张数 " + sumzs.ToString("0"); else this.statusBar1.Panels[0].Text = "总数量 " + sumzs.ToString("0.00") ;
				this.statusBar1.Panels[1].Text="总金额 "+sumlsje.ToString("0.00");
				this.buttj.Enabled=true;
			}
			catch(System.Exception err)
			{
				this.buttj.Enabled=true;
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
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
				string where1="日期:"+dtp1.Value.ToShortDateString();
				where1=where1+" 到:"+dtp2.Value.ToShortDateString();

                if (rdosl.Checked == true && Convert.ToInt32(Convertor.IsNull(txtdm.Tag, "0")) != 0)
                    where1 = where1 + "  药品名称:"+txtdm.Text.Trim();

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();

				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.药品汇总统计.NewRow();
					if (this.rdoje.Checked==true)
					{
						myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
						myrow["wardname"]=Convert.ToString(tb.Rows[i]["病区"]);
						myrow["DJZS"]=Convert.ToDecimal(tb.Rows[i]["单据张数"]);
						myrow["djje"]=Convert.ToDecimal(tb.Rows[i]["金额"]);
					}
					else
					{
						myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
						myrow["wardname"]=Convert.ToString(tb.Rows[i]["病区"]);
						myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
						myrow["yppm"]=Convert.ToString(tb.Rows[i]["品名"]);
						myrow["ypspm"]=Convert.ToString(tb.Rows[i]["商品名"]);
						myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
						myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
						myrow["ypsl"]=Convert.ToDecimal(tb.Rows[i]["数量"]);
						myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
						myrow["lsje"]=Convert.ToDecimal(tb.Rows[i]["金额"]);
						
					}
					Dset.药品汇总统计.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[3];
				parameters[0].Text="where1";
				parameters[0].Value=where1.Trim();
				parameters[1].Text="where2";
				parameters[1].Value="";
				parameters[2].Text="title";
                parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + cmbyjks.Text.Trim() + ")" + "借药汇总统计";
				if (rdoje.Checked==true)
				{
					
					TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.药品汇总统计,Constant.ApplicationDirectory+"\\Report\\YF_药品领药按单据汇总统计.rpt",parameters);
					if (f.LoadReportSuccess) f.Show();else  f.Dispose();
				}
				else
				{
					
					TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.药品汇总统计,Constant.ApplicationDirectory+"\\Report\\YF_药品领药按药品汇总统计.rpt",parameters);
					if (f.LoadReportSuccess) f.Show();else  f.Dispose();
				}
	
				
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}

		private void rdoje_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.rdosl.Checked==true)
			{
                //this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                //this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
//				this.dtp1.Enabled=false;
                //Yp.AddcmbWardDept(cmbks,1,"");
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");
				this.label2.Visible=false;
                this.txtdm.Enabled = true;
//				this.dtp2.Visible=false;
//				this.butprint.Enabled=false;
			}
			else
			{
				this.dtp1.Enabled=true;
                //this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                //this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                //Yp.AddcmbWardDept(cmbks,1,"");
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[1],"Tb1");
				this.label2.Visible=true;
				this.dtp2.Visible=true;
				this.butprint.Enabled=true;
                this.txtdm.Enabled = false;
			}
		}


        //输入框控制事件
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105)  || nkey == 32  || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            {

            }
            else
            {
                return;
            }

            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            DataRow row;

            Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
            switch (control.TabIndex)
            {
                case 25:
                    if (control.Text.Trim() == "") return;
                    GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                    GrdWidth = new int[] { 0, 0, 50, 200, 100, 100, 40, 0, 60, 60, 70 };
                    sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                    ssql = "select a.ggid,cjid,0  rowno,yppm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_Yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + " ";
                    TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql);
                    f2.Location = point;
                    f2.Width = 700;
                    f2.Height = 300;
                    f2.ShowDialog(this);
                    row = f2.dataRow;
                    if (row != null)
                    {
                        this.txtdm.Text = row["yppm"].ToString();
                        this.txtdm.Tag = row["cjid"].ToString();
                    }
                    break;

            }

        }





	}
}
