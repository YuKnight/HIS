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
namespace ts_yp_pdlr
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
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.Button butnew;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.Button butclose;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.CheckBox chkdjsj;
		private System.Windows.Forms.RadioButton rdo2;
		private System.Windows.Forms.RadioButton rdo1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button butsh;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private MenuTag _menuTag;
		private string _chineseName;
        private Button butdel;
        private ComboBox cmbck;
        private Label label3;
        private DataGridTextBoxColumn dataGridTextBoxColumn10;
		private Form _mdiParent;

        //private bool bpcgl = false; //是否进行批次管理
        //private string pcfs = "0";
        public YpConfig ypconfig;
		public Frmtitle(MenuTag menuTag,string chineseName,Form mdiParent)
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
			this.MdiParent=_mdiParent;
            Yp.AddcmbCk(true, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);
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
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.butdel = new System.Windows.Forms.Button();
            this.butsh = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.butnew = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.chkdjsj = new System.Windows.Forms.CheckBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.panel3.SuspendLayout();
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
            this.panel5.Location = new System.Drawing.Point(0, 64);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(832, 365);
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
            this.myDataGrid1.Size = new System.Drawing.Size(832, 365);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 50;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "仓库名称";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "单据号";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "登记时间";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "登记员";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 60;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "审核时间";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 150;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "审核员";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "审核单据号";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "备注";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "id";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.butdel);
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
            // butdel
            // 
            this.butdel.Location = new System.Drawing.Point(176, 6);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(88, 24);
            this.butdel.TabIndex = 5;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butsh
            // 
            this.butsh.Location = new System.Drawing.Point(450, 6);
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size(88, 24);
            this.butsh.TabIndex = 4;
            this.butsh.Text = "查看(&H)";
            this.butsh.Click += new System.EventHandler(this.butsh_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(552, 6);
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
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 200;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 1000;
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(352, 6);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 0;
            this.butnew.Text = "新单据(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(832, 64);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbck);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtp2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp1);
            this.panel2.Controls.Add(this.chkdjsj);
            this.panel2.Controls.Add(this.rdo2);
            this.panel2.Controls.Add(this.rdo1);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 64);
            this.panel2.TabIndex = 3;
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(230, 14);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(112, 20);
            this.cmbck.TabIndex = 20;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(177, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "仓库名称";
            // 
            // dtp2
            // 
            this.dtp2.Enabled = false;
            this.dtp2.Location = new System.Drawing.Point(571, 15);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(110, 21);
            this.dtp2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(548, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Enabled = false;
            this.dtp1.Location = new System.Drawing.Point(434, 15);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(111, 21);
            this.dtp1.TabIndex = 9;
            // 
            // chkdjsj
            // 
            this.chkdjsj.Location = new System.Drawing.Point(361, 14);
            this.chkdjsj.Name = "chkdjsj";
            this.chkdjsj.Size = new System.Drawing.Size(80, 22);
            this.chkdjsj.TabIndex = 8;
            this.chkdjsj.Text = "登记时间";
            this.chkdjsj.Click += new System.EventHandler(this.chkshdh_CheckedChanged);
            // 
            // rdo2
            // 
            this.rdo2.Location = new System.Drawing.Point(88, 15);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(72, 22);
            this.rdo2.TabIndex = 1;
            this.rdo2.Text = "已审核";
            this.rdo2.Click += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(24, 15);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(64, 22);
            this.rdo1.TabIndex = 0;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "未审核";
            this.rdo1.Click += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(713, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 24);
            this.button4.TabIndex = 4;
            this.button4.Text = "刷新(&R)";
            this.button4.Click += new System.EventHandler(this.butref_Click);
            // 
            // Frmtitle
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(832, 485);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frmtitle";
            this.Text = "药品盘点录入";
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
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void butnew_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();
                Frmxd f = new Frmxd(_menuTag, _chineseName, _mdiParent);
                f.ShowDialog(this);
                //f.bpcgl = bpcgl;
  
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

		private void chkshdh_CheckedChanged(object sender, System.EventArgs e)
		{
			this.dtp1.Enabled=chkdjsj.Checked==true?true:false;
			this.dtp2.Enabled=chkdjsj.Checked==true?true:false;
		}

		private void Frmtitle_Load(object sender, System.EventArgs e)
		{
			this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

            if (_menuTag.Function_Name == "Fun_ts_yp_pdlr_yf" && YpConfig.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == true)
            {
                butnew.Enabled = false;
                butsh.Enabled = false;
                butdel.Enabled = false;
                
            }

            if (_menuTag.Function_Name == "Fun_ts_yp_pdlr" && YpConfig.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == false)
            {
                butnew.Enabled = false;
                butsh.Enabled = false;
                butdel.Enabled = false;
            }
		}

		private void butref_Click(object sender, System.EventArgs e)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[11];
				parameters[0].Text="@ywlx";
				parameters[0].Value=_menuTag.FunctionTag.Trim();
				parameters[1].Text="@wldw";
				parameters[1].Value=0;
				parameters[2].Text="@dtp1";
				parameters[2].Value=chkdjsj.Checked==true?dtp1.Value.ToShortDateString():"";
				parameters[3].Text="@dtp2";
				parameters[3].Value=chkdjsj.Checked==true?dtp2.Value.ToShortDateString():"";
				parameters[4].Text="@djh";
				parameters[4].Value=0;
				parameters[5].Text="@fph";
				parameters[5].Value="";
				parameters[6].Text="@shdh";
				parameters[6].Value="";
				parameters[7].Text="@shbz";
				parameters[7].Value=this.rdo1.Checked==true?0:1;
				parameters[8].Text="@deptid";
				parameters[8].Value=Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue,"0"));
				parameters[9].Text="@functionname";
				parameters[9].Value=_menuTag.Function_Name;
                parameters[10].Text = "@p_deptid";
                parameters[10].Value = InstanceForm.BCurrentDept.DeptId;
				DataTable tb=InstanceForm.BDatabase.GetDataTable("sp_yk_selectDj",parameters,30);
				FunBase.AddRowtNo(tb);
				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
				FunBase.myGridSelect(this.myDataGrid1,this.myDataGrid1.TableStyles[0].GridColumnStyles);


			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butsh_Click(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
                ypconfig = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue,"0")), InstanceForm.BDatabase);

				if (tb.Rows.Count==0) return;
                if (ypconfig.盘存方式=="0")
                {
                    Frmzylr f = new Frmzylr(_menuTag, _chineseName, _mdiParent);
                    Point point = new Point(160, 75);
                    f.Location = point;
                    f.MdiParent = _mdiParent;
                    f.Show();
                    f.FillDj(new Guid(tb.Rows[nrow]["id"].ToString()), this.rdo2.Checked);
                }
                else
                {

                        Frmzylr_kcmx f = new Frmzylr_kcmx(_menuTag, _chineseName, _mdiParent);
                        Point point = new Point(160, 75);
                        f.Location = point;
                        f.MdiParent = _mdiParent;
                        f.Show();
                        f.FillDj(new Guid(tb.Rows[nrow]["id"].ToString()), this.rdo2.Checked);

                }
				
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void rdo2_CheckedChanged(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
			if (this.rdo1.Checked==true)
				this.dataGridTableStyle1.ForeColor=System.Drawing.Color.Black ;
			else
				this.dataGridTableStyle1.ForeColor=System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
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

        private void butdel_Click(object sender, EventArgs e)
        {


            try
            {
                if (MessageBox.Show("删除盘点录入单的操作不可恢复！您确定要删除第" + Convert.ToString((this.myDataGrid1.CurrentCell.RowNumber + 1)) + "行吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (tb.Rows.Count == 0) return;
                YF_PDCS_PDCSMX.DelDj(new Guid(tb.Rows[this.myDataGrid1.CurrentCell.RowNumber]["id"].ToString()), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString() + InstanceForm.BCurrentUser.Name + "进行删除操作", InstanceForm.BDatabase);
                butref_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue,"0"));
            //bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);
            //pcfs = (new SystemCfg(8052)).Config;
        }



	}
}
