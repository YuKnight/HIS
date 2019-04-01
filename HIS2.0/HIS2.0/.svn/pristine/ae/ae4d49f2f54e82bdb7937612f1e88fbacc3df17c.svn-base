using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_jc_tysjwh
{
	/// <summary>
	/// FrmDataMaintenance 的摘要说明。
	/// </summary>
	public class FrmMaintenanceSetting : System.Windows.Forms.Form
	{
		//自定义变量
		private int _curRowIndex;
		private CurrentStatus _status;					//当前状态
		//自动生成变量
		private System.Windows.Forms.ToolBar tbarMain;
		private System.Windows.Forms.Panel plGrid;
		private TrasenClasses.GeneralControls.ComboGridSearch cGridSearch;
		private TrasenClasses.GeneralControls.DataGridEx dtgrdMain;
		private System.Windows.Forms.ImageList img;
		private System.Windows.Forms.ToolBarButton tbbtnDelete;
		private System.Windows.Forms.ToolBarButton tbbtnRefresh;
		private System.Windows.Forms.ToolBarButton tbbtnClose;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.GroupBox gbData;
		private System.Windows.Forms.Splitter splilData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFunctionName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private TrasenClasses.GeneralControls.DataGridEx dtgrdDetail;
		private System.Windows.Forms.TextBox txtRemarks;
		private System.Windows.Forms.TextBox txtSelectString;
		private System.Windows.Forms.TextBox txtDatabaseTableName;
		private System.Windows.Forms.TextBox txtFunctionDesc;
		private System.Windows.Forms.TextBox txtMenuName;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton tbbtnSave;
		private System.Windows.Forms.ToolBarButton tbbtnCancel;
		private System.Windows.Forms.ToolBarButton tbbtnNew;
		private System.Windows.Forms.ToolBarButton tbbtnModify;
		private System.Windows.Forms.ToolBarButton tbbtnAddLine;
		private System.Windows.Forms.ToolBarButton tbbtnDelLine;
		private System.Windows.Forms.Label lblCaption;
		private System.Windows.Forms.Panel plLeft;
		private System.Windows.Forms.Panel plData;
		private System.Windows.Forms.TextBox txtReportTitle;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnGetFields;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel panel1;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 构造通用数据维护对象
		/// </summary>
		/// <param name="formText">标题</param>
		public FrmMaintenanceSetting(string formText)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			lblCaption.Text =formText;
			this.Text =formText;

			this.txtDatabaseTableName.Controls.Add(this.btnGetFields);
			this.btnGetFields.Dock = DockStyle.Right;
			this.btnGetFields.Cursor = Cursors.Arrow;
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmMaintenanceSetting));
			this.tbarMain = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbtnNew = new System.Windows.Forms.ToolBarButton();
			this.tbbtnModify = new System.Windows.Forms.ToolBarButton();
			this.tbbtnDelete = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbbtnAddLine = new System.Windows.Forms.ToolBarButton();
			this.tbbtnDelLine = new System.Windows.Forms.ToolBarButton();
			this.tbbtnSave = new System.Windows.Forms.ToolBarButton();
			this.tbbtnCancel = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.tbbtnRefresh = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.tbbtnClose = new System.Windows.Forms.ToolBarButton();
			this.img = new System.Windows.Forms.ImageList(this.components);
			this.plLeft = new System.Windows.Forms.Panel();
			this.plData = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnGetFields = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtReportTitle = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFunctionDesc = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMenuName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFunctionName = new System.Windows.Forms.TextBox();
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtSelectString = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDatabaseTableName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dtgrdDetail = new TrasenClasses.GeneralControls.DataGridEx();
			this.lblCaption = new System.Windows.Forms.Label();
			this.plGrid = new System.Windows.Forms.Panel();
			this.dtgrdMain = new TrasenClasses.GeneralControls.DataGridEx();
			this.cGridSearch = new TrasenClasses.GeneralControls.ComboGridSearch();
			this.gbData = new System.Windows.Forms.GroupBox();
			this.splilData = new System.Windows.Forms.Splitter();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.plLeft.SuspendLayout();
			this.plData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgrdDetail)).BeginInit();
			this.plGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgrdMain)).BeginInit();
			this.gbData.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbarMain
			// 
			this.tbarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.tbbtnNew,
																						this.tbbtnModify,
																						this.tbbtnDelete,
																						this.toolBarButton2,
																						this.tbbtnAddLine,
																						this.tbbtnDelLine,
																						this.tbbtnSave,
																						this.tbbtnCancel,
																						this.toolBarButton3,
																						this.tbbtnRefresh,
																						this.toolBarButton4,
																						this.tbbtnClose});
			this.tbarMain.DropDownArrows = true;
			this.tbarMain.ImageList = this.img;
			this.tbarMain.Location = new System.Drawing.Point(0, 0);
			this.tbarMain.Name = "tbarMain";
			this.tbarMain.ShowToolTips = true;
			this.tbarMain.Size = new System.Drawing.Size(910, 41);
			this.tbarMain.TabIndex = 3;
			this.tbarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbarMain_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbtnNew
			// 
			this.tbbtnNew.ImageIndex = 0;
			this.tbbtnNew.Tag = "0";
			this.tbbtnNew.Text = "添加";
			this.tbbtnNew.ToolTipText = "添加新项";
			// 
			// tbbtnModify
			// 
			this.tbbtnModify.ImageIndex = 8;
			this.tbbtnModify.Tag = "1";
			this.tbbtnModify.Text = "修改";
			this.tbbtnModify.ToolTipText = "修改当前项";
			// 
			// tbbtnDelete
			// 
			this.tbbtnDelete.ImageIndex = 9;
			this.tbbtnDelete.Tag = "2";
			this.tbbtnDelete.Text = "删除";
			this.tbbtnDelete.ToolTipText = "删除当前项";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbtnAddLine
			// 
			this.tbbtnAddLine.Enabled = false;
			this.tbbtnAddLine.ImageIndex = 11;
			this.tbbtnAddLine.Tag = "12";
			this.tbbtnAddLine.Text = "增行";
			// 
			// tbbtnDelLine
			// 
			this.tbbtnDelLine.Enabled = false;
			this.tbbtnDelLine.ImageIndex = 12;
			this.tbbtnDelLine.Tag = "13";
			this.tbbtnDelLine.Text = "减行";
			// 
			// tbbtnSave
			// 
			this.tbbtnSave.Enabled = false;
			this.tbbtnSave.ImageIndex = 1;
			this.tbbtnSave.Tag = "3";
			this.tbbtnSave.Text = "保存";
			this.tbbtnSave.ToolTipText = "保存当前项";
			// 
			// tbbtnCancel
			// 
			this.tbbtnCancel.ImageIndex = 10;
			this.tbbtnCancel.Tag = "4";
			this.tbbtnCancel.Text = "取消";
			this.tbbtnCancel.ToolTipText = "撤消操作";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbtnRefresh
			// 
			this.tbbtnRefresh.ImageIndex = 2;
			this.tbbtnRefresh.Tag = "5";
			this.tbbtnRefresh.Text = "刷新";
			this.tbbtnRefresh.ToolTipText = "刷新网格数据";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbtnClose
			// 
			this.tbbtnClose.ImageIndex = 5;
			this.tbbtnClose.Tag = "11";
			this.tbbtnClose.Text = "关闭";
			this.tbbtnClose.ToolTipText = "关闭窗口";
			// 
			// img
			// 
			this.img.ImageSize = new System.Drawing.Size(16, 16);
			this.img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img.ImageStream")));
			this.img.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// plLeft
			// 
			this.plLeft.AutoScroll = true;
			this.plLeft.BackColor = System.Drawing.SystemColors.Control;
			this.plLeft.Controls.Add(this.plData);
			this.plLeft.Controls.Add(this.lblCaption);
			this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.plLeft.Location = new System.Drawing.Point(3, 17);
			this.plLeft.Name = "plLeft";
			this.plLeft.Size = new System.Drawing.Size(455, 518);
			this.plLeft.TabIndex = 5;
			// 
			// plData
			// 
			this.plData.BackColor = System.Drawing.SystemColors.Window;
			this.plData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.plData.Controls.Add(this.panel1);
			this.plData.Controls.Add(this.btnGetFields);
			this.plData.Controls.Add(this.txtReportTitle);
			this.plData.Controls.Add(this.label7);
			this.plData.Controls.Add(this.label1);
			this.plData.Controls.Add(this.txtFunctionDesc);
			this.plData.Controls.Add(this.label3);
			this.plData.Controls.Add(this.txtMenuName);
			this.plData.Controls.Add(this.label2);
			this.plData.Controls.Add(this.txtFunctionName);
			this.plData.Controls.Add(this.txtRemarks);
			this.plData.Controls.Add(this.label6);
			this.plData.Controls.Add(this.txtSelectString);
			this.plData.Controls.Add(this.label5);
			this.plData.Controls.Add(this.txtDatabaseTableName);
			this.plData.Controls.Add(this.label4);
			this.plData.Controls.Add(this.dtgrdDetail);
			this.plData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plData.Location = new System.Drawing.Point(0, 26);
			this.plData.Name = "plData";
			this.plData.Size = new System.Drawing.Size(455, 492);
			this.plData.TabIndex = 14;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(6, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(644, 14);
			this.textBox1.TabIndex = 18;
			this.textBox1.Text = "例:Select 0 As ROWNO,RYBH As ID,RYXM As NAME,PYM As PY_CODE,\'\' As WB_CODE,\'\' AS D_" +
				"CODE From TABLE_NAME";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(6, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(414, 12);
			this.label9.TabIndex = 17;
			this.label9.Text = "*选项卡SQL语句中必须包含列名：ROWNO,ID,NAME,PY_CODE,WB_CODE,D_CODE";
			// 
			// btnGetFields
			// 
			this.btnGetFields.BackColor = System.Drawing.Color.Silver;
			this.btnGetFields.Location = new System.Drawing.Point(412, 108);
			this.btnGetFields.Name = "btnGetFields";
			this.btnGetFields.Size = new System.Drawing.Size(34, 18);
			this.btnGetFields.TabIndex = 16;
			this.btnGetFields.Text = "...";
			this.toolTip1.SetToolTip(this.btnGetFields, "点击获取表字段");
			this.btnGetFields.Click += new System.EventHandler(this.btnGetFields_Click);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(6, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(198, 12);
			this.label8.TabIndex = 15;
			this.label8.Text = "*单元格内容修改后请按回车键确认";
			// 
			// txtReportTitle
			// 
			this.txtReportTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtReportTitle.BackColor = System.Drawing.SystemColors.Window;
			this.txtReportTitle.Location = new System.Drawing.Point(88, 183);
			this.txtReportTitle.Name = "txtReportTitle";
			this.txtReportTitle.Size = new System.Drawing.Size(360, 21);
			this.txtReportTitle.TabIndex = 5;
			this.txtReportTitle.Text = "";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(2, 183);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(91, 17);
			this.label7.TabIndex = 13;
			this.label7.Text = "报表打印标题：";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "引出函数：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFunctionDesc
			// 
			this.txtFunctionDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctionDesc.BackColor = System.Drawing.SystemColors.Window;
			this.txtFunctionDesc.Location = new System.Drawing.Point(88, 58);
			this.txtFunctionDesc.Multiline = true;
			this.txtFunctionDesc.Name = "txtFunctionDesc";
			this.txtFunctionDesc.Size = new System.Drawing.Size(360, 42);
			this.txtFunctionDesc.TabIndex = 2;
			this.txtFunctionDesc.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "功能说明：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMenuName
			// 
			this.txtMenuName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMenuName.BackColor = System.Drawing.SystemColors.Window;
			this.txtMenuName.Location = new System.Drawing.Point(88, 30);
			this.txtMenuName.Name = "txtMenuName";
			this.txtMenuName.Size = new System.Drawing.Size(360, 21);
			this.txtMenuName.TabIndex = 1;
			this.txtMenuName.Text = "";
			this.txtMenuName.TextChanged += new System.EventHandler(this.txtMenuName_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "菜单名称：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFunctionName
			// 
			this.txtFunctionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctionName.BackColor = System.Drawing.SystemColors.Window;
			this.txtFunctionName.Location = new System.Drawing.Point(88, 4);
			this.txtFunctionName.Name = "txtFunctionName";
			this.txtFunctionName.Size = new System.Drawing.Size(360, 21);
			this.txtFunctionName.TabIndex = 0;
			this.txtFunctionName.Text = "";
			// 
			// txtRemarks
			// 
			this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
			this.txtRemarks.Location = new System.Drawing.Point(88, 209);
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.Size = new System.Drawing.Size(360, 23);
			this.txtRemarks.TabIndex = 6;
			this.txtRemarks.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(2, 209);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(91, 17);
			this.label6.TabIndex = 14;
			this.label6.Text = "数据维护备注：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSelectString
			// 
			this.txtSelectString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSelectString.BackColor = System.Drawing.SystemColors.Window;
			this.txtSelectString.Location = new System.Drawing.Point(88, 133);
			this.txtSelectString.Multiline = true;
			this.txtSelectString.Name = "txtSelectString";
			this.txtSelectString.Size = new System.Drawing.Size(360, 42);
			this.txtSelectString.TabIndex = 4;
			this.txtSelectString.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(2, 135);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 17);
			this.label5.TabIndex = 12;
			this.label5.Text = "查询字符串：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDatabaseTableName
			// 
			this.txtDatabaseTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDatabaseTableName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDatabaseTableName.Location = new System.Drawing.Point(88, 106);
			this.txtDatabaseTableName.Name = "txtDatabaseTableName";
			this.txtDatabaseTableName.Size = new System.Drawing.Size(360, 21);
			this.txtDatabaseTableName.TabIndex = 3;
			this.txtDatabaseTableName.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(2, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "数据库表名：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtgrdDetail
			// 
			this.dtgrdDetail.AllowSorting = false;
			this.dtgrdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dtgrdDetail.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dtgrdDetail.CaptionVisible = false;
			this.dtgrdDetail.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
			this.dtgrdDetail.DataMember = "";
			this.dtgrdDetail.GridPrintTitle = null;
			this.dtgrdDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgrdDetail.Location = new System.Drawing.Point(4, 238);
			this.dtgrdDetail.Name = "dtgrdDetail";
			this.dtgrdDetail.Size = new System.Drawing.Size(444, 176);
			this.dtgrdDetail.TabIndex = 7;
			this.dtgrdDetail.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.dtgrdDetail_myKeyDown);
			this.dtgrdDetail.CellValuesChanged += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(this.dtgrdDetail_CellValuesChanged);
			// 
			// lblCaption
			// 
			this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblCaption.Font = new System.Drawing.Font("楷体_GB2312", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCaption.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblCaption.Location = new System.Drawing.Point(0, 0);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(455, 26);
			this.lblCaption.TabIndex = 13;
			this.lblCaption.Text = "数据维护设置";
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// plGrid
			// 
			this.plGrid.Controls.Add(this.dtgrdMain);
			this.plGrid.Controls.Add(this.cGridSearch);
			this.plGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plGrid.Location = new System.Drawing.Point(462, 17);
			this.plGrid.Name = "plGrid";
			this.plGrid.Size = new System.Drawing.Size(445, 518);
			this.plGrid.TabIndex = 7;
			// 
			// dtgrdMain
			// 
			this.dtgrdMain.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dtgrdMain.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dtgrdMain.CaptionVisible = false;
			this.dtgrdMain.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
			this.dtgrdMain.DataMember = "";
			this.dtgrdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dtgrdMain.GridPrintTitle = null;
			this.dtgrdMain.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgrdMain.Location = new System.Drawing.Point(0, 30);
			this.dtgrdMain.Name = "dtgrdMain";
			this.dtgrdMain.ReadOnly = true;
			this.dtgrdMain.Size = new System.Drawing.Size(445, 488);
			this.dtgrdMain.TabIndex = 10;
			this.dtgrdMain.CurrentCellChanged += new System.EventHandler(this.dtgrdMain_CurrentCellChanged);
			// 
			// cGridSearch
			// 
			this.cGridSearch.BackColor = System.Drawing.SystemColors.Control;
			this.cGridSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.cGridSearch.Location = new System.Drawing.Point(0, 0);
			this.cGridSearch.MappingDataGrid = this.dtgrdMain;
			this.cGridSearch.Name = "cGridSearch";
			this.cGridSearch.Size = new System.Drawing.Size(445, 30);
			this.cGridSearch.TabIndex = 8;
			this.cGridSearch.TableStyleIndex = 0;
			// 
			// gbData
			// 
			this.gbData.BackColor = System.Drawing.SystemColors.Control;
			this.gbData.Controls.Add(this.plGrid);
			this.gbData.Controls.Add(this.splilData);
			this.gbData.Controls.Add(this.plLeft);
			this.gbData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbData.Location = new System.Drawing.Point(0, 41);
			this.gbData.Name = "gbData";
			this.gbData.Size = new System.Drawing.Size(910, 538);
			this.gbData.TabIndex = 0;
			this.gbData.TabStop = false;
			// 
			// splilData
			// 
			this.splilData.Location = new System.Drawing.Point(458, 17);
			this.splilData.Name = "splilData";
			this.splilData.Size = new System.Drawing.Size(4, 518);
			this.splilData.TabIndex = 7;
			this.splilData.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 416);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(453, 74);
			this.panel1.TabIndex = 19;
			// 
			// FrmMaintenanceSetting
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(910, 579);
			this.Controls.Add(this.gbData);
			this.Controls.Add(this.tbarMain);
			this.Name = "FrmMaintenanceSetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "数据维护设置";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmDataMaintenance_Load);
			this.plLeft.ResumeLayout(false);
			this.plData.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgrdDetail)).EndInit();
			this.plGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgrdMain)).EndInit();
			this.gbData.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 方法
		/// <summary>
		/// 加载初始化数据
		/// </summary>
		private void RefreshData()
		{
			DataTable tb=InstanceForm.BDatabase.GetDataTable("select * from Pub_DataMaintenance_Main where delete_bit=0");
			dtgrdMain.DataSource =tb.DefaultView;
			tb.DefaultView.Sort="id";
			if(tb.DefaultView.Count>0)
			{
				int i=tb.DefaultView.Find(Convertor.IsNull(txtFunctionName.Tag,"-1"));
				if(i<0)
				{
					dtgrdMain_CurrentCellChanged(null,null);
				}
				else
				{
					dtgrdMain.CurrentCell =new DataGridCell(i,0);
				}
			}
		}
		/// <summary>
		/// 创建网格格式
		/// </summary>
		private void CreateGridStyle()
		{	
			string[] head={"引出函数","菜单名称","数据库表名","功能说明"};
			string[] colname={"Function_Name","Menu_Name","Database_TableName","Function_Desc"};
			int[] colwidth={150,150,150,300};
			dtgrdMain.CreateTableStyle(head,colname,colwidth);
			string[] dhead={"字段名称","显示列标题","显示宽度","唯一索引","正则表达式","默认值","删除标记","自动增长","名称字段","拼音码字段","五笔码字段","不允许重复","特殊类型","选项卡SQL语句"};
			string[] dcolname={"Database_Name","Chinese_Name","View_Width","IsUniqueKey","RegularExpressions","Default_Value","IsDeleteField","IsAutoIncrease","IsNameField","IsPYField","IsWBField","UnAllowRepeat","SpeciType","ShowCardSql"};
			int[] dcolwidth={80,100,80,70,100,70,80,80,80,80,80,80,70,300};
			dtgrdDetail.CreateTableStyle(dhead,dcolname,dcolwidth,20,true);
		}
		/// <summary>
		/// 根据窗体局部变量_status的值控制按钮的可用状态、工具栏显示
		/// </summary>
		private void ChangeByStatus(CurrentStatus status)
		{
			_status=status;
			switch(status)
			{
				case CurrentStatus.查询状态 :
					tbbtnSave.Enabled =false;
					tbbtnNew.Enabled =true;
					tbbtnModify.Enabled =true;
					tbbtnDelete.Enabled =true;
					tbbtnRefresh.Enabled =true;
					
					tbbtnAddLine.Enabled=false;
					tbbtnDelLine.Enabled =false;
					txtFunctionName.Enabled =false;
					txtMenuName.Enabled =false;
					txtFunctionDesc .Enabled =false;
					txtDatabaseTableName.Enabled =false;
					txtSelectString.Enabled =false;
					txtReportTitle.Enabled =false;
					txtRemarks.Enabled =false;
					dtgrdDetail.ReadOnly =true;
					break;
				default:
					tbbtnSave.Enabled =true;
					tbbtnNew.Enabled =false;
					tbbtnModify.Enabled =false;
					tbbtnDelete.Enabled =false;
					tbbtnRefresh.Enabled =false;
					
					tbbtnAddLine.Enabled=true;
					tbbtnDelLine.Enabled =true;
					txtFunctionName.Enabled =true;
					txtMenuName.Enabled =true;
					txtFunctionDesc .Enabled =true;
					txtDatabaseTableName.Enabled =true;
					txtSelectString.Enabled =true;
					txtReportTitle.Enabled =true;
					txtRemarks.Enabled =true;
					dtgrdDetail.ReadOnly =false;
					break;
			}
		}
		/// <summary>
		/// 保存当前数据
		/// </summary>
		/// <returns></returns>
		private bool SaveDataMaintenance()
		{
			bool beginTransaction=false;
			try
			{
				#region 数据校验
				if(txtFunctionName.Text.Trim()=="")
				{
					MessageBox.Show("引出函数不能为空！","提示");
					return false;
				}
				if(txtMenuName.Text.Trim()=="")
				{
					MessageBox.Show("菜单名称不能为空！","提示");
					return false;
				}
				if(txtFunctionDesc.Text.Trim()=="")
				{
					MessageBox.Show("功能说明不能为空！","提示");
					return false;
				}
				if(txtDatabaseTableName.Text.Trim()=="")
				{
					MessageBox.Show("数据库表名不能为空！","提示");
					return false;
				}
				if(txtSelectString.Text.Trim()=="")
				{
					MessageBox.Show("查询字符串不能为空！","提示");
					return false;
				}
				DataTable tb=(DataTable)dtgrdDetail.DataSource;
				if(tb==null || tb.Rows.Count==0)
				{
					MessageBox.Show("请添加明细内容！","提示");
					return false;
				}
				//检查字段是否重复
				string[] _fieldNames = new string[tb.Rows.Count];
				for ( int i = 0; i < tb.Rows.Count; i ++ )
					_fieldNames[i] = tb.Rows[i]["Database_Name"].ToString().Trim();
				for ( int i = 0 ; i < _fieldNames.Length; i ++ )
				{
					for ( int j = i + 1; j < _fieldNames.Length; j ++ )
					{
						if (_fieldNames[i].Trim().ToUpper() == _fieldNames[j].Trim().ToUpper() )
						{
							MessageBox.Show("字段名称【" + _fieldNames[i] + "】有重复！","");
							return false;
						}
					}
				}
				//剔除空行
				bool hasEmptyRow = true;
				bool goonCheck = true;
				while (hasEmptyRow)
				{
					for ( int i = 0 ; i < tb.Rows.Count; i ++ )
					{
						if ( tb.Rows[i]["Database_Name"].ToString().Trim() == "" )
						{
							tb.Rows.Remove( tb.Rows[i]);
							goonCheck =true;
							break;
						}
						goonCheck = false;
					}
					if (!goonCheck )
						hasEmptyRow = false;
				}

				#endregion

				string[] sqls=new string[2];
				if(_status==CurrentStatus.新建状态)
				{
					sqls[0]=@"Insert into Pub_DataMaintenance_Main (Function_Name,Menu_Name,Function_Desc,Database_TableName,Select_String,Remarks)
								Values ('','','','','','')";
					object identity;
					int ret=InstanceForm.BDatabase.InsertRecord(sqls[0],out identity);
					if(ret<=0)
					{
						MessageBox.Show("数据插入失败！","提示");
						return false;
					}
					sqls[0]="Select * from Pub_DataMaintenance_Main where id="+Convert.ToInt32(Convertor.IsNull(identity,"-1"));;
					sqls[1]="Select * from Pub_DataMaintenance_Detail where 1=2";
				}
				else
				{
					sqls[0]="Select * from Pub_DataMaintenance_Main where id="+Convert.ToInt32(Convertor.IsNull(txtFunctionName.Tag,"-1"));;
					sqls[1]="Select * from Pub_DataMaintenance_Detail where main_id="+Convert.ToInt32(Convertor.IsNull(txtFunctionName.Tag,"-1"));
				}
				DataSet dataSet=new DataSet();
				//开始事务
				InstanceForm.BDatabase.BeginTransaction();
				beginTransaction=true;
				//主表适配器
				DbDataAdapter ada0=InstanceForm.BDatabase.GetAdapter(sqls[0]);
				InstanceForm.BDatabase.CreateCommandBuilder(ada0);
				//子表适配器
				DbDataAdapter ada1=InstanceForm.BDatabase.GetAdapter(sqls[1]);
				InstanceForm.BDatabase.CreateCommandBuilder(ada1);
				//
				ada0.Fill(dataSet,"Pub_DataMaintenance_Main");
				ada1.Fill(dataSet,"Pub_DataMaintenance_Detail");
				//主表内容
				DataRow mRow=dataSet.Tables["Pub_DataMaintenance_Main"].Rows[0];
					
				mRow["Function_Name"]=txtFunctionName.Text.Trim();
				mRow["Menu_Name"]=txtMenuName.Text.Trim();
				mRow["Function_Desc"]=txtFunctionDesc.Text.Trim();
				mRow["Database_TableName"]=txtDatabaseTableName.Text.Trim();
				mRow["Select_String"]=txtSelectString.Text.Trim();
				mRow["Report_Title"]=txtReportTitle.Text.Trim();
				mRow["Remarks"]=txtRemarks.Text.Trim();
				//更新数据
				ada0.Update(dataSet, "Pub_DataMaintenance_Main");
				//子表内容
				DataRow dRow;
				DataRow[] rows;
				int detailID;
				for(int i=0;i<tb.Rows.Count;i++)
				{
					if(Convertor.IsNull(tb.Rows[i]["Database_Name"],"")!="" && Convertor.IsNull(tb.Rows[i]["Chinese_Name"],"")!="")
					{
						detailID=Convert.ToInt32(tb.Rows[i]["id"]);
						if(detailID<0)		//新增记录
						{
							dRow=dataSet.Tables["Pub_DataMaintenance_Detail"].NewRow();
							dataSet.Tables["Pub_DataMaintenance_Detail"].Rows.Add(dRow);
						}
						else
						{
							rows=dataSet.Tables["Pub_DataMaintenance_Detail"].Select("id="+detailID);
							dRow=rows[0];
						}
						dRow["Main_id"]=mRow["id"];
						dRow["Database_Name"]=tb.Rows[i]["Database_Name"];
						dRow["Chinese_Name"]=tb.Rows[i]["Chinese_Name"];
						dRow["View_Width"]=tb.Rows[i]["View_Width"];
						dRow["Default_Value"]=tb.Rows[i]["Default_Value"];
						dRow["ShowCardSql"]=tb.Rows[i]["ShowCardSql"];
						dRow["RegularExpressions"]=tb.Rows[i]["RegularExpressions"];
						dRow["IsUniqueKey"]=tb.Rows[i]["IsUniqueKey"];
						dRow["IsDeleteField"]=tb.Rows[i]["IsDeleteField"];
						dRow["IsAutoIncrease"]=tb.Rows[i]["IsAutoIncrease"];
						dRow["IsPYField"]=tb.Rows[i]["IsPYField"];
						dRow["IsWBField"]=tb.Rows[i]["IsWBField"];
						dRow["IsNameField"]=tb.Rows[i]["IsNameField"];
						dRow["UnAllowRepeat"]=tb.Rows[i]["UnAllowRepeat"];
						dRow["SpeciType"]=tb.Rows[i]["SpeciType"];
						dRow["Delete_bit"]=tb.Rows[i]["Delete_bit"];
					}
				}	
				//更新数据
				ada1.Update(dataSet, "Pub_DataMaintenance_Detail");
				//提交事务
				InstanceForm.BDatabase.CommitTransaction();
				txtFunctionName.Tag=mRow["id"];
				MessageBox.Show("保存成功！","提示");
				//释放资源
				mRow=null;
				dRow=null;
				rows=null;
				ada0.Dispose();
				ada1.Dispose();
				dataSet.Dispose();
				return true;
			}
			catch(Exception err)
			{
				if(beginTransaction)
				{
					//回滚事务
					InstanceForm.BDatabase.RollbackTransaction();
				}
				MessageBox.Show(err.Message,"错误");
				return false;
			}
		}
		/// <summary>
		/// 添加一新行
		/// </summary>
		private void AddNewRow()
		{
			DataTable tb=(DataTable)dtgrdDetail.DataSource;
			if(tb==null) 
			{
				return ;	
			}
			DataRow row=tb.NewRow();
			row["id"]=-1;			//-1表示新增
			row["View_Width"]=80;
			row["IsUniqueKey"]=0;
			row["IsDeleteField"]=0;
			row["IsAutoIncrease"]=0;
			row["IsPYField"]=0;
			row["IsWBField"]=0;
			row["IsNameField"]=0;
			row["UnAllowRepeat"]=0;
			row["SpeciType"]=0;
			row["Delete_bit"]=0;
			tb.Rows.Add(row);
			dtgrdDetail.CurrentCell =new DataGridCell(tb.Rows.Count-1,0);
			tb=null;
		}
		/// <summary>
		/// 添加一新行
		/// </summary>
		private void AddNewRow(string fieldName)
		{
			DataTable tb=(DataTable)dtgrdDetail.DataSource;
			if(tb==null) 
			{
				return ;	
			}
			DataRow row=tb.NewRow();
			row["id"]=-1;			//-1表示新增
			row["Database_Name"] = fieldName;
			row["Chinese_Name"] = fieldName;   //默认标题名为数据库字段名
			row["View_Width"]=80;
			row["IsUniqueKey"]=0;
			row["IsDeleteField"]=0;
			row["IsAutoIncrease"]=0;
			row["IsPYField"]=0;
			row["IsWBField"]=0;
			row["IsNameField"]=0;
			row["UnAllowRepeat"]=0;
			row["SpeciType"]=0;
			row["Delete_bit"]=0;
			tb.Rows.Add(row);
			dtgrdDetail.CurrentCell =new DataGridCell(tb.Rows.Count-1,0);
			tb=null;
		}
		/// <summary>
		/// 删除当前行
		/// </summary>
		private void DeleteCurRow()
		{
			if(MessageBox.Show("确定要删除该明细行吗？","询问",MessageBoxButtons.YesNo,MessageBoxIcon.Question ,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{
				DataTable tb=(DataTable)dtgrdDetail.DataSource;
				if(tb==null) 
				{
					return ;	
				}
				if(Convert.ToInt32(tb.Rows[dtgrdDetail.CurrentRowIndex]["id"])<0)
				{
					tb.Rows.Remove(tb.Rows[dtgrdDetail.CurrentRowIndex]);
				}
				else
				{
					tb.Rows[dtgrdDetail.CurrentRowIndex]["delete_bit"]=1;
				}
				tb=null;
			}
		}
		/// <summary>
		/// 显示数据
		/// </summary>
		private void DisplayData()
		{
			DataView dv=(DataView)dtgrdMain.DataSource;
			if(dv.Count>0)
			{
				DataRowView drv=dv[_curRowIndex];
				txtFunctionName.Text =Convertor.IsNull(drv["Function_Name"],"");
				txtFunctionName.Tag =drv["id"];
				txtMenuName.Text =Convertor.IsNull(drv["Menu_Name"],"");
				txtFunctionDesc.Text =Convertor.IsNull(drv["Function_Desc"],"");
				txtDatabaseTableName.Text =Convertor.IsNull(drv["Database_TableName"],"");
				txtSelectString.Text =Convertor.IsNull(drv["Select_String"],"");
				txtReportTitle.Text =Convertor.IsNull(drv["Report_Title"],"");
				txtRemarks.Text =Convertor.IsNull(drv["Remarks"],"");
				//明细
				DataTable tb=InstanceForm.BDatabase.GetDataTable("select * from Pub_DataMaintenance_Detail where main_id="+Convert.ToInt32(drv["id"])+" and delete_bit=0");
				dtgrdDetail.DataSource =tb;
			}
		}
		/// <summary>
		/// 清空文本框内容
		/// </summary>
		private void ClearControl()
		{
			txtFunctionName.Text ="";
			txtFunctionName.Tag =null;
			txtMenuName.Text ="";
			txtFunctionDesc.Text ="";
			txtDatabaseTableName.Text ="";
			txtSelectString.Text ="";
			txtReportTitle.Text ="";
			txtRemarks.Text ="";
			//明细
			DataTable tb=InstanceForm.BDatabase.GetDataTable("select * from Pub_DataMaintenance_Detail where 1=2");
			dtgrdDetail.DataSource =tb;
		}
		#endregion

		#region 主窗体事件
		private void FrmDataMaintenance_Load(object sender, System.EventArgs e)
		{
			//变量初始化
			_curRowIndex=-1;
			
			CreateGridStyle();
			RefreshData();

			ChangeByStatus(CurrentStatus.查询状态);
		}
		#endregion

		#region 工具栏事件
		private void tbarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			Cursor.Current =Cursors.WaitCursor;
			try
			{
				int buttonTag=Convert.ToInt32(e.Button.Tag);
				DataView dv=(DataView)dtgrdMain.DataSource;
				switch(buttonTag)
				{
					case  0 :			//添加
						ChangeByStatus(CurrentStatus.新建状态);
						ClearControl();
						break;
					case  1 :			//修改
						if(dv.Count>0)
						{
							ChangeByStatus(CurrentStatus.修改状态);
						}
						else
						{
							MessageBox.Show("请选择具体行！","提示");
						}
						break;
					case  2 :			//删除
						if(dv.Count>0)
						{
							if(MessageBox.Show("确定要删除该项吗？","询问",MessageBoxButtons.YesNo,MessageBoxIcon.Question ,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
							{
								string sql="Update Pub_DataMaintenance_Main set delete_bit=1 where id="+Convert.ToInt32(Convertor.IsNull(txtFunctionName.Tag,"-1"));
								int ret=InstanceForm.BDatabase.DoCommand(sql);
								if(ret>0)
								{
									RefreshData();
								}
								else
								{
									MessageBox.Show("删除失败！","提示");
								}
							}
						}
						else
						{
							MessageBox.Show("请选择具体行！","提示");
						}
						break;
					case  3 :			//保存
						if(SaveDataMaintenance())
						{
							ChangeByStatus(CurrentStatus.查询状态);
							RefreshData();
						}
						break;
					case  4 :			//取消
						ChangeByStatus(CurrentStatus.查询状态);
						DisplayData();
						break;
					case  5 :			//刷新
						RefreshData();
						break;
					case  11 :			//关闭窗口
						this.Close();
						break;
					case  12 :			//添加一行
						AddNewRow();
						break;
					case  13 :			//删除一行
						DeleteCurRow();
						break;
					default :
						break;
				}
				Cursor.Current =Cursors.Default;
			}
			catch(Exception err)
			{
				Cursor.Current =Cursors.Default;
				MessageBox.Show(err.Message,"错误");
			}
		}
		#endregion 

		#region 网格事件
		private void dtgrdDetail_CellValuesChanged(object sender, TrasenClasses.GeneralControls.DataGridEnableEventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)dtgrdDetail.DataSource;
				if(tb!=null)
				{
					if(tb.Rows.Count>0 && dtgrdDetail.CurrentRowIndex <tb.Rows.Count)
					{
						if(Convert.ToInt32(tb.Rows[e.Row]["id"])<0)
						{
							e.ForeColor =Color.Blue;
						}
						else if(Convert.ToInt32(Convertor.IsNull(tb.Rows[e.Row]["delete_bit"],"0"))>0)
						{
							e.ForeColor =Color.Red;
						}
						else
						{
							e.ForeColor =Color.Black;
						}
					}
					tb=null;
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"错误");
			}
		}
		private void dtgrdMain_CurrentCellChanged(object sender, System.EventArgs e)
		{
			//选中网格
			dtgrdMain.SelectCurrentRow();
			if(_status ==CurrentStatus.查询状态)
			{
				if(_curRowIndex!=dtgrdMain.CurrentRowIndex)
				{
					_curRowIndex=dtgrdMain.CurrentRowIndex;
					//显示数据于左边数据面板
					DisplayData();
				}
			}
			else if(_curRowIndex!=dtgrdMain.CurrentRowIndex)
			{
				dtgrdMain.CurrentCell =new DataGridCell(_curRowIndex,0);
			}
		}
		private bool dtgrdDetail_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			try
			{
				DataTable tb=(DataTable)dtgrdDetail.DataSource;
				if(tb==null) 
				{
					return true;	
				}
				int row=dtgrdDetail.CurrentCell.RowNumber ;
				int col=dtgrdDetail.CurrentCell.ColumnNumber ;
				if(row>tb.Rows.Count-1 && keyData!=Keys.Up && keyData!=Keys.Down)
				{
					return true;
				}
				if(keyData==Keys.Enter)
				{
					if(col<dtgrdDetail.TableStyles[0].GridColumnStyles.Count-1)
					{
						dtgrdDetail.CurrentCell=new DataGridCell(row,col+1);
					}
					else if (col == dtgrdDetail.TableStyles[0].GridColumnStyles.Count-1)
					{
						//换行
						if (row == tb.Rows.Count - 1 )
						{
							//最后一行
							if(dtgrdDetail.ReadOnly)
							{
								dtgrdDetail.CurrentCell=new DataGridCell(row,0);
							}
							else
							{
								AddNewRow();
							}
						}
						else
						{
							dtgrdDetail.CurrentCell=new DataGridCell(row+1,0);
						}
					}
					else
					{
						if(dtgrdDetail.ReadOnly)
						{
							dtgrdDetail.CurrentCell=new DataGridCell(row,0);
						}
						else
						{
							AddNewRow();
						}
					}
				}
				return false;
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"错误");
				return true;
			}
		}
		#endregion 

		private void btnGetFields_Click(object sender, System.EventArgs e)
		{
			//根据输入的表名获取字段
			string sql = "select * from " + this.txtDatabaseTableName.Text + " where 1<>1";
			try
			{
				DataTable tableFields = InstanceForm.BDatabase.GetDataTable(sql);
				for( int i=0;i<tableFields.Columns.Count;i++)
				{
					string datatableColumnName = tableFields.Columns[i].ColumnName;
					
					DataRow[] drs = ( ( DataTable )this.dtgrdDetail.DataSource ).Select("Database_Name = '" + datatableColumnName + "'");
					if ( drs.Length == 0 )
						AddNewRow(datatableColumnName);
				}
				this.txtSelectString.Text = "select * from " + this.txtDatabaseTableName.Text;
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			
		}

		private void txtMenuName_TextChanged(object sender, System.EventArgs e)
		{
			txtFunctionDesc.Text = txtMenuName.Text;
			txtReportTitle.Text = txtMenuName.Text;
			txtRemarks.Text = txtMenuName.Text;
		}
		
	}
}
