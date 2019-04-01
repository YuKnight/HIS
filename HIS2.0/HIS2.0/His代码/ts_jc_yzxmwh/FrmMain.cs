using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Threading;
namespace ts_jc_yzxmwh
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FrmMain : System.Windows.Forms.Form
    {
        #region 定义
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnStatus;
		private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboYzlx;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dtgrdChargeItem;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFindChargeItem;
		private System.Windows.Forms.RadioButton rdValid;
		private System.Windows.Forms.RadioButton rdInvalid;
        private Button btnExportToExcel;
        private ProgressBar pgbTotal;
        private IContainer components;

        /// <summary>
        /// 停用或恢复 --2012-3-2 jianqg 加，处理按钮（停用或恢复时自动调用dtgrdList_CurrentCellChanged会发生错误）
        /// </summary>
        private bool tyhf = false;
        private Label TSHeader;
        private RadioButton rdInAll;
        private ComboBox cmbFilter1;
        private ComboBox cmbFilterXm;
        private DataGridView dtgrdList;

        /// <summary>
        /// 医嘱项目维护 检索匹配方式及匹配项目(第1个为匹配方式【0=模糊匹配,1=前导匹配】)	，第2个为匹配项目【0=匹配医嘱项目,1=匹配收费项目，2=匹配医嘱项目或收费项目】，默认为0,0)'
        /// </summary>
        SystemCfg cfg37 = null;

        #endregion
        #region FrmMain
        public FrmMain(string captionText)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.Text = captionText;
			this.TSHeader.Text = this.Text;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";

        }
        #endregion
        #region Dispose
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
        #endregion
        #region Windows 窗体设计器生成的代码
        /// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.TSHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtgrdList = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdInAll = new System.Windows.Forms.RadioButton();
            this.rdInvalid = new System.Windows.Forms.RadioButton();
            this.rdValid = new System.Windows.Forms.RadioButton();
            this.cboYzlx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dtgrdChargeItem = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtFindChargeItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pgbTotal = new System.Windows.Forms.ProgressBar();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbFilter1 = new System.Windows.Forms.ComboBox();
            this.cmbFilterXm = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdList)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdChargeItem)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TSHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 36);
            this.panel1.TabIndex = 2;
            // 
            // TSHeader
            // 
            this.TSHeader.AutoSize = true;
            this.TSHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.TSHeader.ForeColor = System.Drawing.Color.Black;
            this.TSHeader.Location = new System.Drawing.Point(223, 7);
            this.TSHeader.Name = "TSHeader";
            this.TSHeader.Size = new System.Drawing.Size(56, 25);
            this.TSHeader.TabIndex = 1;
            this.TSHeader.Text = "标题";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 694);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tabControl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 630);
            this.panel4.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 630);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1000, 604);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "医嘱项目";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtgrdList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1000, 569);
            this.panel6.TabIndex = 1;
            // 
            // dtgrdList
            // 
            this.dtgrdList.AllowUserToAddRows = false;
            this.dtgrdList.AllowUserToDeleteRows = false;
            this.dtgrdList.AllowUserToOrderColumns = true;
            this.dtgrdList.AllowUserToResizeColumns = false;
            this.dtgrdList.AllowUserToResizeRows = false;
            this.dtgrdList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdList.Location = new System.Drawing.Point(0, 0);
            this.dtgrdList.MultiSelect = false;
            this.dtgrdList.Name = "dtgrdList";
            this.dtgrdList.RowTemplate.Height = 23;
            this.dtgrdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrdList.Size = new System.Drawing.Size(1000, 569);
            this.dtgrdList.TabIndex = 0;
            this.dtgrdList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgrdList_ColumnHeaderMouseClick);
            this.dtgrdList.DoubleClick += new System.EventHandler(this.dtgrdList_DoubleClick);
            this.dtgrdList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgrdList_CellFormatting);
            this.dtgrdList.SelectionChanged += new System.EventHandler(this.dtgrdList_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmbFilterXm);
            this.panel5.Controls.Add(this.cmbFilter1);
            this.panel5.Controls.Add(this.rdInAll);
            this.panel5.Controls.Add(this.rdInvalid);
            this.panel5.Controls.Add(this.rdValid);
            this.panel5.Controls.Add(this.cboYzlx);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txtSearch);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 569);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1000, 35);
            this.panel5.TabIndex = 0;
            // 
            // rdInAll
            // 
            this.rdInAll.Location = new System.Drawing.Point(342, 7);
            this.rdInAll.Name = "rdInAll";
            this.rdInAll.Size = new System.Drawing.Size(48, 24);
            this.rdInAll.TabIndex = 6;
            this.rdInAll.Text = "全部";
            this.rdInAll.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rdInvalid
            // 
            this.rdInvalid.Location = new System.Drawing.Point(279, 7);
            this.rdInvalid.Name = "rdInvalid";
            this.rdInvalid.Size = new System.Drawing.Size(48, 24);
            this.rdInvalid.TabIndex = 5;
            this.rdInvalid.Text = "无效";
            this.rdInvalid.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rdValid
            // 
            this.rdValid.Checked = true;
            this.rdValid.Location = new System.Drawing.Point(225, 6);
            this.rdValid.Name = "rdValid";
            this.rdValid.Size = new System.Drawing.Size(48, 24);
            this.rdValid.TabIndex = 4;
            this.rdValid.TabStop = true;
            this.rdValid.Text = "正常";
            this.rdValid.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // cboYzlx
            // 
            this.cboYzlx.BackColor = System.Drawing.Color.SkyBlue;
            this.cboYzlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYzlx.Font = new System.Drawing.Font("宋体", 12F);
            this.cboYzlx.Location = new System.Drawing.Point(60, 6);
            this.cboYzlx.MaxDropDownItems = 30;
            this.cboYzlx.Name = "cboYzlx";
            this.cboYzlx.Size = new System.Drawing.Size(156, 24);
            this.cboYzlx.TabIndex = 3;
            this.cboYzlx.SelectedIndexChanged += new System.EventHandler(this.cboYzlx_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "医嘱类型";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查找";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("宋体", 11.5F);
            this.txtSearch.Location = new System.Drawing.Point(533, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(224, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(826, 367);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "未匹配的收费项目";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dtgrdChargeItem);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(826, 342);
            this.panel8.TabIndex = 2;
            // 
            // dtgrdChargeItem
            // 
            this.dtgrdChargeItem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgrdChargeItem.CaptionVisible = false;
            this.dtgrdChargeItem.DataMember = "";
            this.dtgrdChargeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdChargeItem.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgrdChargeItem.Location = new System.Drawing.Point(0, 0);
            this.dtgrdChargeItem.Name = "dtgrdChargeItem";
            this.dtgrdChargeItem.ParentRowsBackColor = System.Drawing.SystemColors.Window;
            this.dtgrdChargeItem.ReadOnly = true;
            this.dtgrdChargeItem.Size = new System.Drawing.Size(826, 342);
            this.dtgrdChargeItem.TabIndex = 0;
            this.dtgrdChargeItem.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dtgrdChargeItem.DoubleClick += new System.EventHandler(this.dtgrdChargeItem_DoubleClick);
            this.dtgrdChargeItem.CurrentCellChanged += new System.EventHandler(this.dtgrdChargeItem_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dtgrdChargeItem;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtFindChargeItem);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 342);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(826, 25);
            this.panel7.TabIndex = 1;
            // 
            // txtFindChargeItem
            // 
            this.txtFindChargeItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFindChargeItem.Location = new System.Drawing.Point(50, 2);
            this.txtFindChargeItem.Name = "txtFindChargeItem";
            this.txtFindChargeItem.Size = new System.Drawing.Size(774, 21);
            this.txtFindChargeItem.TabIndex = 1;
            this.txtFindChargeItem.TextChanged += new System.EventHandler(this.txtFindChargeItem_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "查找：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pgbTotal);
            this.panel3.Controls.Add(this.btnExportToExcel);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.btnStatus);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 630);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 64);
            this.panel3.TabIndex = 0;
            // 
            // pgbTotal
            // 
            this.pgbTotal.Location = new System.Drawing.Point(3, 24);
            this.pgbTotal.Name = "pgbTotal";
            this.pgbTotal.Size = new System.Drawing.Size(217, 21);
            this.pgbTotal.TabIndex = 35;
            this.pgbTotal.Visible = false;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.Location = new System.Drawing.Point(400, 22);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(147, 23);
            this.btnExportToExcel.TabIndex = 6;
            this.btnExportToExcel.Text = "导出到Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 9);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnStatus
            // 
            this.btnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatus.Location = new System.Drawing.Point(729, 22);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(83, 23);
            this.btnStatus.TabIndex = 4;
            this.btnStatus.Text = "停用";
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(905, 22);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(553, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(641, 22);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(817, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(83, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbFilter1
            // 
            this.cmbFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilter1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter1.FormattingEnabled = true;
            this.cmbFilter1.Items.AddRange(new object[] {
            "前导匹配",
            "模糊查询"});
            this.cmbFilter1.Location = new System.Drawing.Point(765, 10);
            this.cmbFilter1.Name = "cmbFilter1";
            this.cmbFilter1.Size = new System.Drawing.Size(78, 20);
            this.cmbFilter1.TabIndex = 7;
            // 
            // cmbFilterXm
            // 
            this.cmbFilterXm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilterXm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterXm.FormattingEnabled = true;
            this.cmbFilterXm.Items.AddRange(new object[] {
            "匹配医嘱项目",
            "匹配收费项目",
            "匹配医嘱或收费项目"});
            this.cmbFilterXm.Location = new System.Drawing.Point(849, 9);
            this.cmbFilterXm.Name = "cmbFilterXm";
            this.cmbFilterXm.Size = new System.Drawing.Size(143, 20);
            this.cmbFilterXm.TabIndex = 8;
            // 
            // FrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.Text = "医嘱项目维护";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdList)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdChargeItem)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        #region ShowItemList
        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            CreateDataGridStyle();
            LoadYzlx();
            ShowItemList("");

            cfg37 = new SystemCfg(37);
            string[] tmp37 = cfg37.Config.Split(',');
            cmbFilter1.SelectedIndex = 0;
            if (tmp37.Length > 0 && tmp37[0] == "0") //模糊匹配 2014-7-15 jianqg
            {
                cmbFilter1.SelectedIndex = 1;
            }
            cmbFilterXm.SelectedIndex = 0;
            if (tmp37.Length > 1) //匹配项目 2014-7-15 jianqg
            {
                if (tmp37[1] == "1") cmbFilterXm.SelectedIndex = 1;
                if (tmp37[1] == "2") cmbFilterXm.SelectedIndex = 2;
                
            }

            CreateChargeItemGridStyle();
            ShowChargeItemList();
            FilterData();

 
            


        }
        #endregion
		#region 创建表式样 CreateDataGridStyle
		/// <summary>
		/// 创建表式样
		/// </summary>
		private void CreateDataGridStyle()
		{
            this.dtgrdList.Columns.Clear();
            this.dtgrdList.AutoGenerateColumns = false;
            string[] headName = new string[] { "医嘱编码", "医嘱名称", "备注", "拼音码", "五笔码", "单位", "默认执行科室", "类型", "价格", "对应收费项目", "收费项目数字码", "国家编码", "编码", "默认用法", "删除", "选择", "数量", "总价", "收费项目拼音码", "收费项目五笔码", "套餐" };
            string[] mappName = new string[] { "order_id", "order_name", "bz", "py_code", "wb_code", "order_unit", "exec_dept_name", "order_type", "price", "item_name", "item_code", "std_code", "item_id", "default_usage", "delete_bit", "selected", "num", "total", "sfxm_PY_CODE", "sfxm_WB_CODE", "tc_flag" };
            int[] colWidth = new int[] { 75, 230, 60, 80, 0, 50, 70, 50, 90, 150, 75, 100, 75, 100, 0, 0, 35, 0, 0, 0, 0 };
			
			for ( int i=0;i<headName.Length; i++)
			{
                DataGridViewTextBoxColumn grdtxtCol = new DataGridViewTextBoxColumn();
				grdtxtCol.HeaderText = headName[i];
                
				grdtxtCol.DataPropertyName= mappName[i];
				grdtxtCol.Width = colWidth[i];
                if (colWidth[i] == 0) 
                    grdtxtCol.Visible = false;
				//grdtxtCol.NullText = "";
				this.dtgrdList.Columns.Add(grdtxtCol );
                
                grdtxtCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i <= 1) this.dtgrdList.Columns[i].Frozen = true;
			}
           
            this.dtgrdList.AllowUserToAddRows = false;
            this.dtgrdList.AllowUserToDeleteRows = false;
            this.dtgrdList.AllowUserToOrderColumns = false;
            this.dtgrdList.ReadOnly = true;
            this.dtgrdList.AllowUserToResizeRows = false;
            this.dtgrdList.AllowUserToResizeColumns = true;
            this.dtgrdList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgrdList.DefaultCellStyle.SelectionBackColor =  Color.LightGray;
            this.dtgrdList.DefaultCellStyle.SelectionForeColor = Color.Black;
            
            


        }
        #endregion

		#region 创建CreateChargeItemGridStyle
		private void CreateChargeItemGridStyle()
		{
			string[] headName = new string[]{"item_id"	,"国家编码"	,"项目名称","拼音码"	,"五笔码"	,"单位"		,"单价"	,"套餐"		};
			string[] mappName = new string[]{"item_id"	,"std_code"	,"item_name","py_code"	,"wb_code"	,"item_unit","price","tcbz"		};
			int[] colWidth = new int[]		{0			,100		,300		,100		,100		,75			,0		,35			};

			DataTable tabTmp = new DataTable();

			for ( int i=0;i<headName.Length; i++)
			{
				DataGridTextBoxColumn grdtxtCol = new DataGridTextBoxColumn();
				grdtxtCol.HeaderText = headName[i];
				grdtxtCol.MappingName = mappName[i];
				grdtxtCol.Width = colWidth[i];
				grdtxtCol.NullText = "";
							
				this.dtgrdChargeItem.TableStyles[0].GridColumnStyles.Add( grdtxtCol );
			
				tabTmp.Columns.Add(mappName[i]);
			}
			this.dtgrdChargeItem.DataSource = tabTmp.DefaultView;
			PubStaticFun.ModifyDataGridStyle( dtgrdChargeItem,0 );
		}
		#endregion

        private void dtgrdList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            object sort = dtgrdList.Columns[e.ColumnIndex].Tag;
            if (sort == null) sort = "";
            if (sort.ToString() == "desc") dtgrdList.Columns[e.ColumnIndex].Tag = "";
            else dtgrdList.Columns[e.ColumnIndex].Tag = "desc";
            string sortTmp = dtgrdList.Columns[e.ColumnIndex].DataPropertyName + " " + sort;
            ShowItemList(sortTmp);
            this.FilterData();
        }
        #region 加载项目列表
        /// <summary>
		/// 加载项目列表
		/// </summary>
		/// <returns></returns>
		private DataTable LoadItemData()
		{
			DataTable table = InstanceForm.BDatabase.GetDataTable("SP_JC_GET_ALLORDERS2",null,30);
            //DataColumn col = new DataColumn();
            //col.ColumnName = "selected";
            //col.DefaultValue = 0;
            //col.DataType = Type.GetType("System.Int32");
            //table.Columns.Add( col );
			return table;
		}
        #endregion
        #region 加载未匹配的收费项目
        /// <summary>
		/// 加载未匹配的收费项目
		/// </summary>
		/// <returns></returns>
		private DataTable LoadUnMatchChargeItem()
		{
			string sql = "select item_id,std_code,item_name,py_code,wb_code,item_unit,retail_price as price,' ' as tcbz ";
					sql+=" from jc_hsitem ";
					sql+=" where delete_bit=0 and item_id not in ( select hditem_id from jc_hoi_hdi where tc_flag =0 ) ";
					sql+=" union all ";
					sql+=" select item_id,'' as std_code,item_name,py_code,wb_code,item_unit,price,'◆' as tcbz ";
					sql+=" from jc_tc_t ";
					sql+=" where delete_bit=0 and item_id not in (select hditem_id from jc_hoi_hdi where tc_flag = 1) ";
			return InstanceForm.BDatabase.GetDataTable( sql );
        }
        #endregion
        #region ShowChargeItemList
        private void ShowChargeItemList()
		{
			this.dtgrdChargeItem.DataSource = LoadUnMatchChargeItem().DefaultView;
			PubStaticFun.ModifyDataGridStyle( dtgrdChargeItem,0 );
		}
        #endregion
        #region 过滤数据
        /// <summary>
		/// 过滤数据
		/// </summary>
		private void FilterData()
		{
            if (this.dtgrdList.DataSource == null) return;
            
			DataView dv = (DataView)this.dtgrdList.DataSource;
			try
			{
                object objlock = new object();

                lock (objlock)
                {

                    string strFilter = "";
                    if (this.rdInAll.Checked)
                    {
                        strFilter = "1=1";
                    }
                    else if (this.rdInvalid.Checked)
                    {
                        strFilter = "delete_bit = 1";
                    }
                    else
                    {
                        strFilter = "delete_bit = 0";
                    }
                    
                    string strVal = this.txtSearch.Text.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]");
                    if (strVal != "")
                    {
                        string strFilter_yz = "order_name like '{0}' or py_code like '{0}' or wb_code like '{0}'";
                        //jianqg 2014-7-3 增加 按收费项目名称，拼音码，五笔码,国家编码,数字码
                        string strFilter_sf = "item_name like '{0}' or sfxm_PY_CODE like '{0}' or sfxm_WB_CODE like '{0}'";
                        strFilter_sf += " or std_code like '{0}' or item_code  like '{0}'";

                        //string strFilter1 = "order_name like '%" + strVal + "%' or py_code like '%" + strVal + "%' or wb_code like '%" + strVal + "%'";
                        
                        //strFilter1 += " or item_name like '%" + strVal + "%' or item_code  like '%" + strVal + "%' or sfxm_PY_CODE like '%" + strVal + "%' or sfxm_WB_CODE like '%" + strVal + "%'";
                        //strFilter1 += " or std_code like '%" + strVal + "%'";
                        string strFilter1 = "";
                        if (cmbFilter1.Text.Contains("前导"))
                        {
                            strFilter_yz = string.Format(strFilter_yz, "" + strVal + "%");
                            strFilter_sf = string.Format(strFilter_sf, "" + strVal + "%");
                        }
                        else
                        {
                            strFilter_yz = string.Format(strFilter_yz, "%" + strVal + "%");
                            strFilter_sf = string.Format(strFilter_sf, "%" + strVal + "%");
                        }
                        if (cmbFilterXm.Text.Contains("医嘱") && cmbFilterXm.Text.Contains("收费"))
                        {
                            strFilter1=strFilter_yz + " or " + strFilter_sf;
                        }
                        else if (cmbFilterXm.Text.Contains("医嘱"))
                        {
                            strFilter1=strFilter_yz ;
                        }
                         else if (cmbFilterXm.Text.Contains("收费"))
                        {
                            strFilter1=strFilter_sf ;
                        }

                        //jianqg 2014-7-3 增加 按收费项目名称，数字码，拼音码，五笔码,国家编码

                        if (strFilter != "")
                            strFilter += " and (" + strFilter1 + ")";
                        else
                            strFilter = strFilter1;
                    }
                    if (this.cboYzlx.SelectedIndex != 0)
                    {
                        if (strFilter != "")
                        {
                            strFilter += " and order_type='" + cboYzlx.Text + "'";
                        }
                        else
                        {
                            strFilter = "order_type='" + cboYzlx.Text + "'";
                        }
                    }
                

				dv.RowFilter = strFilter ;

                //if (cmbFilterXm.Text.Contains("医嘱"))
                //{
                //    dv.Sort = "order_name asc";
                //}
                //else
                //{
                //    dv.Sort = "item_name asc";
                //}
                if (dv.Count > 0)
                {
                    this.dtgrdList.CurrentCell = this.dtgrdList.Rows[0].Cells[2];
                }
                }
			}
			catch(Exception err)
			{
				MessageBox.Show("查询错误，包含非法字符"+err.Message);
			}
        }
        #endregion
        #region LoadYzlx
        /// <summary>
		/// 加在医嘱类型
		/// </summary>
		private void LoadYzlx()
		{
			this.cboYzlx.Items.Add("<全部>");
			string sql = "select name from jc_ordertype order by code";
			DataTable table = InstanceForm.BDatabase.GetDataTable(sql);
			for ( int i=0;i<table.Rows.Count;i++)
			{
				this.cboYzlx.Items.Add( table.Rows[i][0].ToString().Trim());
			}
			if (table.Rows.Count>0) cboYzlx.SelectedIndex =0;
        }
        #endregion
        #region ShowItemList
        /// <summary>
		/// 显示数据网格列表
		/// </summary>
        private void ShowItemList(string dataColumnSort)
		{
            DataTable dt1= LoadItemData();
            DataView dv1 = null;
            if (dt1.Rows.Count > 0)
            {
                dv1 = new DataView(dt1, "", dataColumnSort, DataViewRowState.CurrentRows);
            }
            else dv1 = dt1.DefaultView;



            this.dtgrdList.DataSource = dv1;

			//PubStaticFun.ModifyDataGridStyle( this.dtgrdList,0);
        }
        #endregion

        #region dtgrdList_CellFormatting

        private void dtgrdList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            e.CellStyle.BackColor = Color.White;

            DataView dv = (DataView)this.dtgrdList.DataSource;
            if (dv.Count > 0)
            {
                int isdel = Convert.ToInt32(dv[e.RowIndex]["delete_bit"]);//dtgrdList.Rows[e.RowIndex].Cells["delete_bit"].Value.ToString(); 
                if (isdel == 1)
                    e.CellStyle.ForeColor = Color.Red;
                string tc = dv[e.RowIndex]["tc_flag"].ToString();
                if (tc == "1")
                    e.CellStyle.ForeColor = Color.Blue;

            }
        }
        #endregion

        #region dtgrdList_deleteChanged,dtgrdList_SelectionChanged
        /// <summary>
        /// dtgrdList_deleteChanged jianqg 2012-3-2 加 ，
        /// </summary>
        /// <param name="rowIndex"></param>
        private void dtgrdList_deleteChanged(int rowIndex)
        {
            try
            {

                DataView dv = (DataView)this.dtgrdList.DataSource;

                DataTable table = dv.Table;
                
                int scbz = Convert.ToInt32(dv[rowIndex]["delete_bit"]);
                if (scbz == 0)
                    this.btnStatus.Text = "停用";
                else
                    this.btnStatus.Text = "恢复";


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        

        private void dtgrdList_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgrdList.CurrentCell == null) return;
            dtgrdList.Rows[dtgrdList.CurrentCell.RowIndex].Selected = true;
            dtgrdList_deleteChanged(dtgrdList.CurrentCell.RowIndex);
        }
        #endregion
        #region btnStatus_Click
        private void btnStatus_Click(object sender, System.EventArgs e)
		{
            try
            {
                if (dtgrdList.RowCount <=0) return;
                if (dtgrdList.CurrentCell==null) return;
                DataView dv = (DataView)dtgrdList.DataSource;
                int rows = dv.Count;
                int index = dtgrdList.CurrentCell.RowIndex;
                if (dv.Count > 0)
                {
                    int xmbh = Convert.ToInt32(dv[index]["order_id"]);
                    int scbz = Convert.ToInt32(dv[index]["delete_bit"]);
                    if (MessageBox.Show("确定要" + (scbz == 0 ? "停用" : "恢复") + "项目吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        OrderItem item = new OrderItem(xmbh);
                        
                        if (scbz == 0)
                            item.SetUseable(false);
                        else
                            item.SetUseable(true);
                        // dv[dtgrdList.CurrentRowIndex]["delete_bit"] = scbz == 0 ? 1 : 0;

                        DataRow dr = dv[index].Row;

                        int scbz_new = scbz == 0 ? 1 : 0;
                        dr["delete_bit"] = scbz_new;
                        
  
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnAdd_Click
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            FrmEdit frmEdit = new FrmEdit(0);
            frmEdit.OperatorType = OP_TYPE.新增项目;
            frmEdit.ShowDialog();
        }

        #endregion
        #region btnEdit_Click
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (dtgrdList.CurrentCell==null) return;
            DataView dv = (DataView)this.dtgrdList.DataSource;
            if (dv.Count > 0)
            {
                int index1 = dtgrdList.CurrentCell.RowIndex;
                FrmEdit frmEdit = new FrmEdit(Convert.ToInt32(dv[index1]["order_id"]));
                frmEdit.dataviewYZXM = dv;

                frmEdit.lbl_sfxm_price.Text ="单价：" + dv[index1]["price"].ToString();
                frmEdit.currentRowIndex = index1;
                frmEdit.OperatorType = OP_TYPE.更新项目;
                frmEdit.ShowDialog();
            }
        }
        #endregion
        #region btnRefresh_Click，radioButton_CheckedChanged，cboYzlx_SelectedIndexChanged，txtSearch_TextChanged，btnExit_Click，dtgrdList_DoubleClick
        private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			ShowItemList("");
            this.FilterData();
		}

		private void radioButton_CheckedChanged(object sender, System.EventArgs e)
		{
            this.FilterData();
		}

		private void cboYzlx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.FilterData();
		}

		private void txtSearch_TextChanged(object sender, System.EventArgs e)
		{
			this.FilterData();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void dtgrdList_DoubleClick(object sender, System.EventArgs e)
		{
			this.btnEdit_Click(null,null);
        }
        #endregion

        #region dtgrdChargeItem 事件
        private void dtgrdChargeItem_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if ( dtgrdChargeItem.CurrentRowIndex != -1 )
			{
				dtgrdChargeItem.Select(dtgrdChargeItem.CurrentRowIndex);
			}
		}

		private void dtgrdChargeItem_DoubleClick(object sender, System.EventArgs e)
		{
			DataView dv = (DataView)this.dtgrdChargeItem.DataSource;
			if (dv.Count > 0 )
			{
				int item_id = Convert.ToInt32( dv[this.dtgrdChargeItem.CurrentRowIndex]["item_id"] );
				int tc_flag = dv[this.dtgrdChargeItem.CurrentRowIndex]["tcbz"].ToString().Trim()=="" ? 0 : 1;
				FrmEdit frmEdit = new FrmEdit(item_id,tc_flag);
				frmEdit.OperatorType = OP_TYPE.新增项目;
				frmEdit.ShowDialog();
				ShowChargeItemList();
			}
		}

		private void txtFindChargeItem_TextChanged(object sender, System.EventArgs e)
		{
			DataView dv = (DataView)this.dtgrdChargeItem.DataSource;
			if ( this.txtFindChargeItem.Text.Trim() == "")
			{
				try
				{
					this.dtgrdChargeItem.DataSource = LoadUnMatchChargeItem().DefaultView;
					PubStaticFun.ModifyDataGridStyle( this.dtgrdChargeItem,0);
				}
				catch{}
			}
			else
			{
				try
				{
					string strFilter = "";
				
					string strVal = this.txtFindChargeItem.Text.Trim().Replace("'","''").Replace("[","[[]").Replace("%","[%]");
					if ( strVal != "")
					{
						string strFilter1 = "item_name like '%" + strVal + "%' or py_code like '" + strVal + "%' or wb_code like '" + strVal + "%'" ;
						if ( strFilter != "" )
							strFilter += " and (" + strFilter1 + ")"; 
						else
							strFilter = strFilter1;
					}
				
					dv.RowFilter = strFilter ;
				}
				catch(Exception err)
				{
					MessageBox.Show("查询错误，包含非法字符"+err.Message);
				}
			}
        }
        #endregion
        private void btnExportToExcel_Click( object sender , EventArgs e )
        {
            pgbTotal.Visible = true;
            ExportToExcel();
            pgbTotal.Visible = false;
        }

        private void ExportToExcel()
        {
            #region 简单打印
            DataView dv = (DataView)this.dtgrdList.DataSource;
            Excel.Application myExcel = new Excel.Application( );
            Cursor = PubStaticFun.WaitCursor( );
            try
            {
                myExcel.Application.Workbooks.Add( true );

                //写入行头
                int SumRowCount = dv.Count;
                int SumColCount = 0 ;
                int ncol = 0;
                for ( int j = 0 ; j < this.dtgrdList.Columns.Count ; j++ )
                {

                    if (this.dtgrdList.Columns[j].Width > 0)
                    {
                        ncol++;
                        myExcel.Cells[5, ncol] = this.dtgrdList.Columns[j].HeaderText;
                        SumColCount++;    
                    }
                    
                }
                myExcel.get_Range( myExcel.Cells[5 , 1] , myExcel.Cells[5 , SumColCount] ).Font.Bold = true;
                myExcel.get_Range( myExcel.Cells[5 , 1] , myExcel.Cells[5 , SumColCount] ).Font.Size = 10;

                pgbTotal.Maximum = SumRowCount;
                pgbTotal.Value = 0;
                pgbTotal.Step = 1;

                //逐行写入数据，
                for ( int i = 0 ; i < dv.Count ; i++ )
                {
                    ncol = 0;
                    for (int j = 0; j < this.dtgrdList.Columns.Count; j++)
                    {
                        try
                        {
                            if (this.dtgrdList.Columns[j].Width > 0)
                            {
                                ncol = ncol + 1;
                                myExcel.Cells[6 + i, ncol] = "'" + (this.dtgrdList.Rows[i].Cells[j].Value == null ? "" : this.dtgrdList.Rows[i].Cells[j].Value.ToString().Trim());// this.dtgrdList[i, j].ToString().Trim();

                            }
                        }
                        catch
                        {
                            string t = "";
                        }

                    }
                     pgbTotal.PerformStep(); 
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range( myExcel.Cells[6 , 1] , myExcel.Cells[5 + SumRowCount , SumColCount] ).Select( );
                myExcel.get_Range( myExcel.Cells[6 , 1] , myExcel.Cells[5 + SumRowCount , SumColCount] ).Columns.AutoFit( );

                //加边框
                myExcel.get_Range( myExcel.Cells[5 , 1] , myExcel.Cells[5 + SumRowCount , SumColCount] ).Borders.LineStyle = 1;

                //报表名称
                myExcel.Cells[1 , 1] = "医院医嘱项目表";
                myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[1 , SumColCount] ).Font.Bold = true;
                myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[1 , SumColCount] ).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[1 , SumColCount] ).Select( );
                myExcel.get_Range( myExcel.Cells[1 , 1] , myExcel.Cells[1 , SumColCount] ).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3 , 1] = "";
                myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[3 , SumColCount] ).Font.Size = 10;
                myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[3 , SumColCount] ).Select( );
                myExcel.get_Range( myExcel.Cells[3 , 1] , myExcel.Cells[5 , SumColCount] ).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                //myExcel.get_Range(myExcel.Cells[5+SumRowCount,1],myExcel.Cells[5+SumRowCount,SumColCount]).Interior.ColorIndex = 19;


                //让Excel文件可见
                myExcel.Visible = true;

            }
            catch ( System.Exception err )
            {
                myExcel.Quit( );
                MessageBox.Show( err.Message );
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            #endregion
        }












      
	}
}
