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

namespace ts_jc_wardbed
{
	public struct BedInfo
	{
		public string BedID;			//ID
		public string BedNo;		//床号
		public string WardID;		//所在病区
		public string WardName;
		public long DeptID;			//所属科室
		public string DeptName;
		public string RoomNo;		//所在病房
		public bool IsPlus;			//加床标志
		public bool IsInuse;		//是否有病人在用
		public bool UseState;		//床位状态(停用，在用)
		public long ChargeDocID;	//主治医生
		public string ChargeDocName;
		public long ManageDocID;	//管床医生
		public string ManageDocName;
		public long FunNurseID;		//负责护士
		public string FunNurseName;
		public long LinkFeeID;		//联动费用
		public string LinkFeeName;

	}
	public struct DeptInfo
	{
		public string WardID;
		public string WardName;
		public long DeptID;
		public string DeptName;
	}
	public struct RoomInfo
	{
		public string RoomNo;
		public string WardID;
		public string WardName;
        public int RoomJgbm;
	}
	public class FrmWardBed : System.Windows.Forms.Form
	{
		/// <summary>
		/// 床位费统计大项目代码
		/// </summary>
		private string cwfCode= (new SystemCfg(7029)).Config.Trim();
        public int _jgbm;
        private int settingByNurse = 0;

		private TrasenClasses.GeneralControls.LabelEx label1;
		private System.Windows.Forms.ToolBar tblToolbar;
		private System.Windows.Forms.ImageList imgToolbar;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ListView lstBed;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cboWard;
		private System.Windows.Forms.ListView lstDept;
		private System.Windows.Forms.TextBox txtLinkFee;
		private System.Windows.Forms.TextBox txtFunNurse;
		private System.Windows.Forms.TextBox txtManageDoc;
		private System.Windows.Forms.TextBox txtChargeDoc;
		private System.Windows.Forms.TextBox txtDept;
		private System.Windows.Forms.TextBox txtBedNo;
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.ListView lstRoom;
		private System.Windows.Forms.ToolBarButton tlbbtnAddRoom;
		private System.Windows.Forms.ToolBarButton tlbbtnAddBed;
		private System.Windows.Forms.ToolBarButton tblbtnEditBed;
		private System.Windows.Forms.ToolBarButton tlbbtnExit;
		private System.Windows.Forms.ToolBarButton tblbtnStatus;
		private System.Windows.Forms.ToolBarButton tlbbtnRefresh;
		private System.Windows.Forms.CheckBox chkPlus;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ContextMenu menuRoom;
		private System.Windows.Forms.MenuItem menuChangeRoomNo;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuEditBedFee;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private TrasenClasses.GeneralControls.LabelEx labelEx1;
		private System.Windows.Forms.Panel panel8;
		private TrasenClasses.GeneralControls.LabelEx tsLabel3;
		private TrasenClasses.GeneralControls.LabelEx tgsLabel1;
		private TrasenClasses.GeneralControls.LabelEx tsLabel2;
        private System.ComponentModel.IContainer components;
        private Label label4;
        private Label lblAllNum;
        private Label label10;
        private Label lblPlusNum;
        private Label label6;
        private Label lblNonNum;
        private Label label12;

        /// <summary>
        /// 仅仅是 床位查看，2012-5-7加 ，只有查询权
        /// </summary>
        private bool _OnlyView = false;
        public FrmWardBed(string formText, bool OnlyView1)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.Text=formText;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            _OnlyView = OnlyView1;
            this.tlbbtnAddRoom.Visible = !_OnlyView;
            this.tlbbtnAddBed.Visible = !_OnlyView;
            this.tblbtnEditBed.Visible = !_OnlyView;
            this.tblbtnStatus.Visible = !_OnlyView;



			GetWardList();

		}
        /// <summary>
        /// 只设置当前登录的病区下的床位
        /// </summary>
        /// <param name="formText"></param>
        /// <param name="SettingByNurse"></param>
        public FrmWardBed( string formText　, int SettingByNurse )
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent( );
            this.Text = formText;
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            label1.Text = "[" + InstanceForm.BCurrentDept.WardDeptName + "] 床位设置";
            settingByNurse = SettingByNurse;
            GetWardList( );
            
            
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWardBed));
            this.label1 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.tblToolbar = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tlbbtnAddRoom = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.tlbbtnAddBed = new System.Windows.Forms.ToolBarButton();
            this.tblbtnEditBed = new System.Windows.Forms.ToolBarButton();
            this.tblbtnStatus = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.tlbbtnRefresh = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.tlbbtnExit = new System.Windows.Forms.ToolBarButton();
            this.imgToolbar = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lstRoom = new System.Windows.Forms.ListView();
            this.menuRoom = new System.Windows.Forms.ContextMenu();
            this.menuChangeRoomNo = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuEditBedFee = new System.Windows.Forms.MenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tsLabel3 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lstDept = new System.Windows.Forms.ListView();
            this.labelEx1 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.cboWard = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblNonNum = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPlusNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAllNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkPlus = new System.Windows.Forms.CheckBox();
            this.txtLinkFee = new System.Windows.Forms.TextBox();
            this.txtFunNurse = new System.Windows.Forms.TextBox();
            this.txtManageDoc = new System.Windows.Forms.TextBox();
            this.txtChargeDoc = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtBedNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tgsLabel1 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstBed = new System.Windows.Forms.ListView();
            this.tsLabel2 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.BackColor2 = System.Drawing.Color.AliceBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1004, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "病区床位管理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tblToolbar
            // 
            this.tblToolbar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tblToolbar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.tlbbtnAddRoom,
            this.toolBarButton3,
            this.tlbbtnAddBed,
            this.tblbtnEditBed,
            this.tblbtnStatus,
            this.toolBarButton4,
            this.tlbbtnRefresh,
            this.toolBarButton5,
            this.tlbbtnExit});
            this.tblToolbar.DropDownArrows = true;
            this.tblToolbar.ImageList = this.imgToolbar;
            this.tblToolbar.Location = new System.Drawing.Point(0, 26);
            this.tblToolbar.Name = "tblToolbar";
            this.tblToolbar.ShowToolTips = true;
            this.tblToolbar.Size = new System.Drawing.Size(1004, 28);
            this.tblToolbar.TabIndex = 1;
            this.tblToolbar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.tblToolbar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tblToolbar_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.toolBarButton1.Tag = "";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbbtnAddRoom
            // 
            this.tlbbtnAddRoom.ImageIndex = 0;
            this.tlbbtnAddRoom.Name = "tlbbtnAddRoom";
            this.tlbbtnAddRoom.Tag = "ADD_ROOM";
            this.tlbbtnAddRoom.Text = "增加病房";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbbtnAddBed
            // 
            this.tlbbtnAddBed.ImageIndex = 2;
            this.tlbbtnAddBed.Name = "tlbbtnAddBed";
            this.tlbbtnAddBed.Tag = "ADD_BED";
            this.tlbbtnAddBed.Text = "增加病床";
            // 
            // tblbtnEditBed
            // 
            this.tblbtnEditBed.ImageIndex = 3;
            this.tblbtnEditBed.Name = "tblbtnEditBed";
            this.tblbtnEditBed.Tag = "EDIT_BED";
            this.tblbtnEditBed.Text = "编辑病床";
            // 
            // tblbtnStatus
            // 
            this.tblbtnStatus.ImageIndex = 5;
            this.tblbtnStatus.Name = "tblbtnStatus";
            this.tblbtnStatus.Tag = "STOP_BEGIN";
            this.tblbtnStatus.Text = "停用";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbbtnRefresh
            // 
            this.tlbbtnRefresh.ImageIndex = 6;
            this.tlbbtnRefresh.Name = "tlbbtnRefresh";
            this.tlbbtnRefresh.Tag = "REFRESH";
            this.tlbbtnRefresh.Text = "刷新";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbbtnExit
            // 
            this.tlbbtnExit.ImageIndex = 4;
            this.tlbbtnExit.Name = "tlbbtnExit";
            this.tlbbtnExit.Tag = "EXIT";
            this.tlbbtnExit.Text = "关闭";
            // 
            // imgToolbar
            // 
            this.imgToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgToolbar.ImageStream")));
            this.imgToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgToolbar.Images.SetKeyName(0, "");
            this.imgToolbar.Images.SetKeyName(1, "");
            this.imgToolbar.Images.SetKeyName(2, "");
            this.imgToolbar.Images.SetKeyName(3, "");
            this.imgToolbar.Images.SetKeyName(4, "");
            this.imgToolbar.Images.SetKeyName(5, "");
            this.imgToolbar.Images.SetKeyName(6, "");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 502);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.cboWard);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 502);
            this.panel4.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 150);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(260, 352);
            this.panel7.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lstRoom);
            this.panel5.Controls.Add(this.tsLabel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 352);
            this.panel5.TabIndex = 4;
            // 
            // lstRoom
            // 
            this.lstRoom.ContextMenu = this.menuRoom;
            this.lstRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRoom.HideSelection = false;
            this.lstRoom.LargeImageList = this.imgList;
            this.lstRoom.Location = new System.Drawing.Point(0, 19);
            this.lstRoom.MultiSelect = false;
            this.lstRoom.Name = "lstRoom";
            this.lstRoom.Size = new System.Drawing.Size(260, 333);
            this.lstRoom.TabIndex = 3;
            this.lstRoom.UseCompatibleStateImageBehavior = false;
            this.lstRoom.SelectedIndexChanged += new System.EventHandler(this.lstRoom_SelectedIndexChanged);
            // 
            // menuRoom
            // 
            this.menuRoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChangeRoomNo,
            this.menuItem1,
            this.menuEditBedFee});
            // 
            // menuChangeRoomNo
            // 
            this.menuChangeRoomNo.Index = 0;
            this.menuChangeRoomNo.Text = "修改房间号";
            this.menuChangeRoomNo.Click += new System.EventHandler(this.menuChangeRoomNo_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "-";
            // 
            // menuEditBedFee
            // 
            this.menuEditBedFee.Index = 2;
            this.menuEditBedFee.Text = "修改该房床位费";
            this.menuEditBedFee.Click += new System.EventHandler(this.menuEditBedFee_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "");
            this.imgList.Images.SetKeyName(1, "");
            this.imgList.Images.SetKeyName(2, "");
            this.imgList.Images.SetKeyName(3, "");
            this.imgList.Images.SetKeyName(4, "");
            // 
            // tsLabel3
            // 
            this.tsLabel3.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.tsLabel3.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tsLabel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tsLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsLabel3.Location = new System.Drawing.Point(0, 0);
            this.tsLabel3.Name = "tsLabel3";
            this.tsLabel3.Size = new System.Drawing.Size(260, 19);
            this.tsLabel3.TabIndex = 2;
            this.tsLabel3.Text = "科室病房";
            this.tsLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.labelEx1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(260, 123);
            this.panel6.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lstDept);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 19);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(260, 104);
            this.panel8.TabIndex = 2;
            // 
            // lstDept
            // 
            this.lstDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDept.HideSelection = false;
            this.lstDept.LargeImageList = this.imgList;
            this.lstDept.Location = new System.Drawing.Point(0, 0);
            this.lstDept.MultiSelect = false;
            this.lstDept.Name = "lstDept";
            this.lstDept.Size = new System.Drawing.Size(260, 104);
            this.lstDept.TabIndex = 1;
            this.lstDept.UseCompatibleStateImageBehavior = false;
            this.lstDept.SelectedIndexChanged += new System.EventHandler(this.lstDept_SelectedIndexChanged);
            this.lstDept.Click += new System.EventHandler(this.lstDept_Click);
            // 
            // labelEx1
            // 
            this.labelEx1.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.labelEx1.BackColor2 = System.Drawing.Color.AliceBlue;
            this.labelEx1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.Location = new System.Drawing.Point(0, 0);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(260, 19);
            this.labelEx1.TabIndex = 0;
            this.labelEx1.Text = "病区科室";
            this.labelEx1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboWard
            // 
            this.cboWard.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWard.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboWard.Location = new System.Drawing.Point(0, 0);
            this.cboWard.Name = "cboWard";
            this.cboWard.Size = new System.Drawing.Size(260, 27);
            this.cboWard.TabIndex = 0;
            this.cboWard.SelectedIndexChanged += new System.EventHandler(this.cboWard_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(260, 54);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 502);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lblNonNum);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblPlusNum);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblAllNum);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.chkPlus);
            this.panel2.Controls.Add(this.txtLinkFee);
            this.panel2.Controls.Add(this.txtFunNurse);
            this.panel2.Controls.Add(this.txtManageDoc);
            this.panel2.Controls.Add(this.txtChargeDoc);
            this.panel2.Controls.Add(this.txtDept);
            this.panel2.Controls.Add(this.txtBedNo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tgsLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(264, 386);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 170);
            this.panel2.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(659, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "张";
            // 
            // lblNonNum
            // 
            this.lblNonNum.AutoSize = true;
            this.lblNonNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNonNum.Location = new System.Drawing.Point(632, 63);
            this.lblNonNum.Name = "lblNonNum";
            this.lblNonNum.Size = new System.Drawing.Size(24, 16);
            this.lblNonNum.TabIndex = 22;
            this.lblNonNum.Text = "__";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(556, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "张，空床";
            // 
            // lblPlusNum
            // 
            this.lblPlusNum.AutoSize = true;
            this.lblPlusNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPlusNum.Location = new System.Drawing.Point(519, 63);
            this.lblPlusNum.Name = "lblPlusNum";
            this.lblPlusNum.Size = new System.Drawing.Size(24, 16);
            this.lblPlusNum.TabIndex = 20;
            this.lblPlusNum.Text = "__";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(410, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "张，其中加床";
            // 
            // lblAllNum
            // 
            this.lblAllNum.AutoSize = true;
            this.lblAllNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAllNum.Location = new System.Drawing.Point(377, 63);
            this.lblAllNum.Name = "lblAllNum";
            this.lblAllNum.Size = new System.Drawing.Size(24, 16);
            this.lblAllNum.TabIndex = 18;
            this.lblAllNum.Text = "__";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(251, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "本科室共有病床";
            // 
            // chkPlus
            // 
            this.chkPlus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPlus.Location = new System.Drawing.Point(170, 25);
            this.chkPlus.Name = "chkPlus";
            this.chkPlus.Size = new System.Drawing.Size(93, 24);
            this.chkPlus.TabIndex = 16;
            this.chkPlus.Text = "加床标志";
            // 
            // txtLinkFee
            // 
            this.txtLinkFee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLinkFee.BackColor = System.Drawing.SystemColors.Window;
            this.txtLinkFee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLinkFee.Location = new System.Drawing.Point(85, 130);
            this.txtLinkFee.Name = "txtLinkFee";
            this.txtLinkFee.ReadOnly = true;
            this.txtLinkFee.Size = new System.Drawing.Size(635, 26);
            this.txtLinkFee.TabIndex = 15;
            // 
            // txtFunNurse
            // 
            this.txtFunNurse.BackColor = System.Drawing.SystemColors.Window;
            this.txtFunNurse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFunNurse.Location = new System.Drawing.Point(423, 96);
            this.txtFunNurse.Name = "txtFunNurse";
            this.txtFunNurse.ReadOnly = true;
            this.txtFunNurse.Size = new System.Drawing.Size(90, 26);
            this.txtFunNurse.TabIndex = 14;
            // 
            // txtManageDoc
            // 
            this.txtManageDoc.BackColor = System.Drawing.SystemColors.Window;
            this.txtManageDoc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtManageDoc.Location = new System.Drawing.Point(254, 96);
            this.txtManageDoc.Name = "txtManageDoc";
            this.txtManageDoc.ReadOnly = true;
            this.txtManageDoc.Size = new System.Drawing.Size(90, 26);
            this.txtManageDoc.TabIndex = 13;
            // 
            // txtChargeDoc
            // 
            this.txtChargeDoc.BackColor = System.Drawing.SystemColors.Window;
            this.txtChargeDoc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChargeDoc.Location = new System.Drawing.Point(85, 96);
            this.txtChargeDoc.Name = "txtChargeDoc";
            this.txtChargeDoc.ReadOnly = true;
            this.txtChargeDoc.Size = new System.Drawing.Size(90, 26);
            this.txtChargeDoc.TabIndex = 12;
            // 
            // txtDept
            // 
            this.txtDept.BackColor = System.Drawing.SystemColors.Window;
            this.txtDept.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDept.Location = new System.Drawing.Point(85, 60);
            this.txtDept.Name = "txtDept";
            this.txtDept.ReadOnly = true;
            this.txtDept.Size = new System.Drawing.Size(114, 26);
            this.txtDept.TabIndex = 11;
            // 
            // txtBedNo
            // 
            this.txtBedNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtBedNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBedNo.Location = new System.Drawing.Point(85, 24);
            this.txtBedNo.Name = "txtBedNo";
            this.txtBedNo.ReadOnly = true;
            this.txtBedNo.Size = new System.Drawing.Size(63, 26);
            this.txtBedNo.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(13, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "床位费";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(351, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "负责护士";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(13, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "所属科室";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(181, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "管床医生";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "主治医生";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "床位号";
            // 
            // tgsLabel1
            // 
            this.tgsLabel1.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.tgsLabel1.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tgsLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tgsLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tgsLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tgsLabel1.Location = new System.Drawing.Point(0, 0);
            this.tgsLabel1.Name = "tgsLabel1";
            this.tgsLabel1.Size = new System.Drawing.Size(740, 19);
            this.tgsLabel1.TabIndex = 1;
            this.tgsLabel1.Text = "床位信息";
            this.tgsLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstBed);
            this.panel3.Controls.Add(this.tsLabel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(264, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(740, 332);
            this.panel3.TabIndex = 5;
            // 
            // lstBed
            // 
            this.lstBed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBed.HideSelection = false;
            this.lstBed.LargeImageList = this.imgList;
            this.lstBed.Location = new System.Drawing.Point(0, 19);
            this.lstBed.MultiSelect = false;
            this.lstBed.Name = "lstBed";
            this.lstBed.Size = new System.Drawing.Size(740, 313);
            this.lstBed.TabIndex = 3;
            this.lstBed.UseCompatibleStateImageBehavior = false;
            this.lstBed.SelectedIndexChanged += new System.EventHandler(this.lstBed_SelectedIndexChanged);
            this.lstBed.DoubleClick += new System.EventHandler(this.lstBed_DoubleClick);
            // 
            // tsLabel2
            // 
            this.tsLabel2.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.tsLabel2.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tsLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tsLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsLabel2.Location = new System.Drawing.Point(0, 0);
            this.tsLabel2.Name = "tsLabel2";
            this.tsLabel2.Size = new System.Drawing.Size(740, 19);
            this.tsLabel2.TabIndex = 2;
            this.tsLabel2.Text = "病房床位列表";
            this.tsLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmWardBed
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1004, 556);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tblToolbar);
            this.Controls.Add(this.label1);
            this.Name = "FrmWardBed";
            this.Click += new System.EventHandler(this.FrmWardBed_Click);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 获取所有病区列表
		/// <summary>
		/// 获取病区列表
		/// </summary>
		private void GetWardList()
		{
			string sql="select * from jc_ward ";
            if (settingByNurse == 1)
            {
                sql += " where dept_id=" + InstanceForm.BCurrentDept.WardDeptId;
            }
            else
            {
                sql += " where  dept_id in (select dept_id from JC_DEPT_PROPERTY where DELETED=0 )";
            }
            sql += "order by ward_id";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(sql);
			cboWard.DisplayMember="WARD_NAME";
			cboWard.ValueMember="WARD_ID";
			cboWard.DataSource=tb;
			
		}
		#endregion

		#region 获取病区科室
		/// <summary>
		/// 获取病区科室
		/// </summary>
		/// <param name="WardID">病区ID(string)</param>
		private void GetWardDeptList(string WardID)
		{
			try
			{
				string sql="select a.ward_id,a.dept_id,b.ward_name,c.name from jc_wardrdept a inner join jc_ward b ";
				sql+=" on a.ward_id=b.ward_id ";
				sql+=" inner join jc_dept_property c on a.dept_id=c.dept_id";
				sql+=" where a.dept_id<>b.dept_id and b.ward_id='"+WardID+"'";
				DataTable tb=InstanceForm.BDatabase.GetDataTable(sql);
				this.lstDept.Items.Clear();
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					DeptInfo deptInfo=new DeptInfo();
					deptInfo.WardID=tb.Rows[i]["ward_id"].ToString().Trim();
					deptInfo.WardName=tb.Rows[i]["ward_name"].ToString().Trim();
					deptInfo.DeptID=Convert.ToInt64(tb.Rows[i]["dept_id"]);
					deptInfo.DeptName=tb.Rows[i]["name"].ToString().Trim();

					ListViewItem item=new ListViewItem();
					item.Text=deptInfo.DeptName;
					item.Tag=deptInfo;
					item.ImageIndex=0;
					this.lstDept.Items.Add(item);
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}
		
		#endregion

		#region 获取病区病房
		/// <summary>
		/// 获取病区病房
		/// </summary>
		/// <param name="WardID">病区ID(string)</param>
		private void GetWardRoomList(string WardID)
		{
			string sql="Select a.jgbm,a.ward_id,room_no,b.ward_name ";
			sql+=" from ZY_BEDDICTION a left join jc_ward b on a.ward_id=b.ward_id ";
            sql += " where a.ward_id='" + WardID + "' group by a.ward_id,room_no,b.ward_name,case when  isnumeric(room_no)=1 and SUBSTRING (room_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',room_no)>0 then 2 when SUBSTRING (room_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(room_no)=1 then cast(room_no as int) else 999999 end,a.jgbm";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(sql);
			this.lstRoom.Items.Clear();
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				RoomInfo roomInfo=new RoomInfo();
				roomInfo.RoomNo=tb.Rows[i]["room_no"].ToString().Trim();
				roomInfo.WardID=tb.Rows[i]["ward_id"].ToString().Trim();
				roomInfo.WardName=tb.Rows[i]["ward_name"].ToString().Trim();
                _jgbm = roomInfo.RoomJgbm = Convert.ToInt32(tb.Rows[i]["jgbm"].ToString());

				ListViewItem item=new ListViewItem();
				item.Text=roomInfo.RoomNo;
				item.Tag=roomInfo;
				item.ImageIndex=1;
				this.lstRoom.Items.Add(item);
			}
		}
		/// <summary>
		/// 获取病区所属科室的病房
		/// </summary>
		/// <param name="WardID">病区ID(string)</param>
		/// <param name="DeptID">科室ID(long)</param>
		private void GetWardRoomList(string WardID,long DeptID)
		{
			string sql="Select a.jgbm,a.ward_id,room_no,b.ward_name ";
			sql+=" from ZY_BEDDICTION a left join jc_ward b on a.ward_id=b.ward_id ";
            sql += " where a.ward_id='" + WardID + "' and a.dept_id=" + DeptID + " group by a.ward_id,room_no,b.ward_name,case when  isnumeric(room_no)=1 and SUBSTRING (room_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',room_no)>0 then 2 when SUBSTRING (room_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(room_no)=1 then cast(room_no as int) else 999999 end,a.jgbm";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(sql);
			this.lstRoom.Items.Clear();
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				RoomInfo roomInfo=new RoomInfo();
				roomInfo.RoomNo=tb.Rows[i]["room_no"].ToString().Trim();
				roomInfo.WardID=tb.Rows[i]["ward_id"].ToString().Trim();
				roomInfo.WardName=tb.Rows[i]["ward_name"].ToString().Trim();
                _jgbm = roomInfo.RoomJgbm = Convert.ToInt32(tb.Rows[i]["jgbm"].ToString());
				ListViewItem item=new ListViewItem();
				item.Text=roomInfo.RoomNo;
				item.Tag=roomInfo;
				item.ImageIndex=1;
				this.lstRoom.Items.Add(item);
			}
		}
		#endregion

        #region"获取科室病房 add by jchl"
        private void GetWardDeptList(string WardID, long deptID)
        {
            string sql = "select a.bed_id, a.ward_id,b.ward_name,";
            sql += "a.dept_id,c.name,";
            sql += "a.room_no,a.bed_no,";
            sql += "a.hoitem_id,g.order_name,";
            sql += "a.zz_doc,d.name as zz_doc_name,";
            sql += "a.zy_doc,e.name as zy_doc_name,";
            sql += "a.chargenurse,f.name as chargenurse_name,a.isplus,isinuse,a.inpatient_id";
            sql += " from zy_beddiction a left join jc_ward b on a.ward_id=b.ward_id";
            sql += " left join jc_dept_property c on a.dept_id=c.dept_id";
            sql += " left join jc_employee_property d on a.zz_doc=d.employee_id";
            sql += " left join jc_employee_property e on a.zy_doc=e.employee_id";
            sql += " left join jc_employee_property f on a.chargenurse=f.employee_id";
            sql += " left join jc_hoitemdiction g on a.hoitem_id=g.order_id ";
            sql += " where a.ward_id='" + WardID + "' and a.DEPT_ID='" + deptID + "'";
            sql += " order by case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end,a.pxxh ";
            
			DataTable tb=InstanceForm.BDatabase.GetDataTable(sql);
			this.lstBed.Items.Clear();
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				BedInfo bedInfo=new BedInfo();
                bedInfo.BedID = tb.Rows[i]["bed_id"].ToString();
				bedInfo.BedNo=tb.Rows[i]["bed_no"].ToString();
				bedInfo.WardID=tb.Rows[i]["ward_id"].ToString();
				bedInfo.WardName=tb.Rows[i]["ward_name"].ToString();
				bedInfo.DeptID=Convert.IsDBNull(tb.Rows[i]["dept_id"])?-1:Convert.ToInt64(tb.Rows[i]["dept_id"]);
				bedInfo.DeptName=tb.Rows[i]["name"].ToString().Trim();
				bedInfo.RoomNo=tb.Rows[i]["room_no"].ToString().Trim();
				bedInfo.ChargeDocID=Convert.IsDBNull(tb.Rows[i]["zz_doc"])?-1:Convert.ToInt64(tb.Rows[i]["zz_doc"]);
				bedInfo.ChargeDocName=tb.Rows[i]["zz_doc_name"].ToString().Trim();
				bedInfo.ManageDocID=Convert.IsDBNull(tb.Rows[i]["zy_doc"])?-1:Convert.ToInt64(tb.Rows[i]["zy_doc"]);
				bedInfo.ManageDocName=tb.Rows[i]["zy_doc_name"].ToString().Trim();
				bedInfo.FunNurseID=Convert.IsDBNull(tb.Rows[i]["chargenurse"])?-1:Convert.ToInt64(tb.Rows[i]["chargenurse"]);
				bedInfo.FunNurseName=tb.Rows[i]["chargenurse_name"].ToString().Trim();
				bedInfo.LinkFeeID=Convert.IsDBNull(tb.Rows[i]["hoitem_id"])?-1:Convert.ToInt64(tb.Rows[i]["hoitem_id"]);
				bedInfo.LinkFeeName=tb.Rows[i]["order_name"].ToString();
				bedInfo.IsPlus=Convert.ToInt16(tb.Rows[i]["isplus"])==1?true:false;
				bedInfo.IsInuse=Convert.IsDBNull(tb.Rows[i]["inpatient_id"])?false:true;
				bedInfo.UseState=Convert.ToInt16(tb.Rows[i]["isinuse"])==0?true:false;
				
				ListViewItem item=new ListViewItem();
				item.Text=bedInfo.BedNo;
				if ( bedInfo.IsPlus )
					item.Text = item.Text + "(加)";
				item.Tag=bedInfo;
				if(bedInfo.UseState)
				{
					if(bedInfo.IsInuse)
						item.ImageIndex=3;
					else
						item.ImageIndex=2;
				}
				else
					item.ImageIndex=4;
				
				this.lstBed.Items.Add(item);
                this.ClearBedInfo();
            }
        }
        #endregion

        #region 获取病房的病床列表
        /// <summary>
		/// 获取病房内的床位列表
		/// </summary>
		/// <param name="WardID">病房所在的病区ID</param>
		/// <param name="RoomNo">房间号</param>
		private void GetRoomBedList(string WardID,string RoomNo)
		{
			string sql="select a.bed_id, a.ward_id,b.ward_name,";
			sql+="a.dept_id,c.name,";
			sql+="a.room_no,a.bed_no,";
			sql+="a.hoitem_id,g.order_name,";
			sql+="a.zz_doc,d.name as zz_doc_name,";
			sql+="a.zy_doc,e.name as zy_doc_name,";
			sql+="a.chargenurse,f.name as chargenurse_name,a.isplus,isinuse,a.inpatient_id";
			sql+=" from zy_beddiction a left join jc_ward b on a.ward_id=b.ward_id";
			sql+=" left join jc_dept_property c on a.dept_id=c.dept_id";
			sql+=" left join jc_employee_property d on a.zz_doc=d.employee_id";
			sql+=" left join jc_employee_property e on a.zy_doc=e.employee_id";
			sql+=" left join jc_employee_property f on a.chargenurse=f.employee_id";
			sql+=" left join jc_hoitemdiction g on a.hoitem_id=g.order_id ";
			sql+=" where a.ward_id='"+WardID+"' and a.room_no='"+RoomNo+"'";
            sql += " order by case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end,a.pxxh ";

			DataTable tb=InstanceForm.BDatabase.GetDataTable(sql);
			this.lstBed.Items.Clear();
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				BedInfo bedInfo=new BedInfo();
                bedInfo.BedID = tb.Rows[i]["bed_id"].ToString();
				bedInfo.BedNo=tb.Rows[i]["bed_no"].ToString();
				bedInfo.WardID=tb.Rows[i]["ward_id"].ToString();
				bedInfo.WardName=tb.Rows[i]["ward_name"].ToString();
				bedInfo.DeptID=Convert.IsDBNull(tb.Rows[i]["dept_id"])?-1:Convert.ToInt64(tb.Rows[i]["dept_id"]);
				bedInfo.DeptName=tb.Rows[i]["name"].ToString().Trim();
				bedInfo.RoomNo=tb.Rows[i]["room_no"].ToString().Trim();
				bedInfo.ChargeDocID=Convert.IsDBNull(tb.Rows[i]["zz_doc"])?-1:Convert.ToInt64(tb.Rows[i]["zz_doc"]);
				bedInfo.ChargeDocName=tb.Rows[i]["zz_doc_name"].ToString().Trim();
				bedInfo.ManageDocID=Convert.IsDBNull(tb.Rows[i]["zy_doc"])?-1:Convert.ToInt64(tb.Rows[i]["zy_doc"]);
				bedInfo.ManageDocName=tb.Rows[i]["zy_doc_name"].ToString().Trim();
				bedInfo.FunNurseID=Convert.IsDBNull(tb.Rows[i]["chargenurse"])?-1:Convert.ToInt64(tb.Rows[i]["chargenurse"]);
				bedInfo.FunNurseName=tb.Rows[i]["chargenurse_name"].ToString().Trim();
				bedInfo.LinkFeeID=Convert.IsDBNull(tb.Rows[i]["hoitem_id"])?-1:Convert.ToInt64(tb.Rows[i]["hoitem_id"]);
				bedInfo.LinkFeeName=tb.Rows[i]["order_name"].ToString();
				bedInfo.IsPlus=Convert.ToInt16(tb.Rows[i]["isplus"])==1?true:false;
				bedInfo.IsInuse=Convert.IsDBNull(tb.Rows[i]["inpatient_id"])?false:true;
				bedInfo.UseState=Convert.ToInt16(tb.Rows[i]["isinuse"])==0?true:false;
				
				ListViewItem item=new ListViewItem();
				item.Text=bedInfo.BedNo;
				if ( bedInfo.IsPlus )
					item.Text = item.Text + "(加)";
				item.Tag=bedInfo;
				if(bedInfo.UseState)
				{
					if(bedInfo.IsInuse)
						item.ImageIndex=3;
					else
						item.ImageIndex=2;
				}
				else
					item.ImageIndex=4;
				
				this.lstBed.Items.Add(item);
				this.ClearBedInfo();
			}
		}
		/// <summary>
		/// 获取病房内的床位列表
		/// </summary>
		/// <param name="WardID">病房所在的病区ID</param>
		/// <param name="RoomNo">房间号</param>
		private void GetRoomBedList(string WardID)
		{
			string sql="select a.bed_id, a.ward_id,b.ward_name,";
			sql+="a.dept_id,c.name,";
			sql+="a.room_no,a.bed_no,";
			sql+="a.hoitem_id,g.order_name,";
			sql+="a.zz_doc,d.name as zz_doc_name,";
			sql+="a.zy_doc,e.name as zy_doc_name,";
			sql+="a.chargenurse,f.name as chargenurse_name,a.isplus,isinuse,a.inpatient_id";
			sql+=" from zy_beddiction a left join jc_ward b on a.ward_id=b.ward_id";
			sql+=" left join jc_dept_property c on a.dept_id=c.dept_id";
			sql+=" left join jc_employee_property d on a.zz_doc=d.employee_id";
			sql+=" left join jc_employee_property e on a.zy_doc=e.employee_id";
			sql+=" left join jc_employee_property f on a.chargenurse=f.employee_id";
			sql+=" left join jc_hoitemdiction g on a.hoitem_id=g.order_id ";
			sql+=" where a.ward_id='"+WardID+"'";
            sql += " order by case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end,a.pxxh";

			DataTable tb=InstanceForm.BDatabase.GetDataTable(sql);
			this.lstBed.Items.Clear();
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				BedInfo bedInfo=new BedInfo();
                bedInfo.BedID = tb.Rows[i]["bed_id"].ToString();
				bedInfo.BedNo=tb.Rows[i]["bed_no"].ToString();
				bedInfo.WardID=tb.Rows[i]["ward_id"].ToString();
				bedInfo.WardName=tb.Rows[i]["ward_name"].ToString();
				bedInfo.DeptID=Convert.IsDBNull(tb.Rows[i]["dept_id"])?-1:Convert.ToInt64(tb.Rows[i]["dept_id"]);
				bedInfo.DeptName=tb.Rows[i]["name"].ToString().Trim();
				bedInfo.RoomNo=tb.Rows[i]["room_no"].ToString().Trim();
				bedInfo.ChargeDocID=Convert.IsDBNull(tb.Rows[i]["zz_doc"])?-1:Convert.ToInt64(tb.Rows[i]["zz_doc"]);
				bedInfo.ChargeDocName=tb.Rows[i]["zz_doc_name"].ToString().Trim();
				bedInfo.ManageDocID=Convert.IsDBNull(tb.Rows[i]["zy_doc"])?-1:Convert.ToInt64(tb.Rows[i]["zy_doc"]);
				bedInfo.ManageDocName=tb.Rows[i]["zy_doc_name"].ToString().Trim();
				bedInfo.FunNurseID=Convert.IsDBNull(tb.Rows[i]["chargenurse"])?-1:Convert.ToInt64(tb.Rows[i]["chargenurse"]);
				bedInfo.FunNurseName=tb.Rows[i]["chargenurse_name"].ToString().Trim();
				bedInfo.LinkFeeID=Convert.IsDBNull(tb.Rows[i]["hoitem_id"])?-1:Convert.ToInt64(tb.Rows[i]["hoitem_id"]);
				bedInfo.LinkFeeName=tb.Rows[i]["order_name"].ToString();
				bedInfo.IsPlus=Convert.ToInt16(tb.Rows[i]["isplus"])==1?true:false;
				bedInfo.IsInuse=Convert.IsDBNull(tb.Rows[i]["inpatient_id"])?false:true;
				bedInfo.UseState=Convert.ToInt16(tb.Rows[i]["isinuse"])==0?true:false;
				
				ListViewItem item=new ListViewItem();
				item.Text=bedInfo.BedNo;
				if ( bedInfo.IsPlus )
					item.Text = item.Text + "(加)";
				item.Tag=bedInfo;
				if(bedInfo.UseState)
				{
					if(bedInfo.IsInuse)
						item.ImageIndex=3;
					else
						item.ImageIndex=2;
				}
				else
					item.ImageIndex=4;
				
				this.lstBed.Items.Add(item);
				this.ClearBedInfo();
			}
		}
		#endregion

		#region 显示病床的信息
		/// <summary>
		/// 显示床位基本信息
		/// </summary>
		/// <param name="bedInfo">需要显示的床位(自定义的struct)</param>
		private void ShowBedInfo(BedInfo bedInfo)
		{
			this.txtBedNo.Tag=bedInfo.BedID;
			this.txtBedNo.Text=bedInfo.BedNo;
			this.txtDept.Text=bedInfo.DeptName;
			this.txtDept.Tag=bedInfo.DeptID;
			this.txtChargeDoc.Text=bedInfo.ChargeDocName;
			this.txtChargeDoc.Tag=bedInfo.ChargeDocID;
			this.txtManageDoc.Text=bedInfo.ManageDocName;
			this.txtManageDoc.Tag=bedInfo.ManageDocID;
			this.txtFunNurse.Text=bedInfo.FunNurseName;
			this.txtFunNurse.Tag=bedInfo.FunNurseID;
			this.txtLinkFee.Text=bedInfo.LinkFeeName;
			this.txtLinkFee.Tag=bedInfo.LinkFeeID;
			this.chkPlus.Checked=bedInfo.IsPlus;
		}
		#endregion

		#region 清空病床信息
		/// <summary>
		/// 清空床位显示的信息
		/// </summary>
		private void ClearBedInfo()
		{
			this.txtBedNo.Tag=-1;
			this.txtBedNo.Text="";
			this.txtDept.Text="";
			this.txtDept.Tag=-1;
			this.txtChargeDoc.Text="";
			this.txtChargeDoc.Tag=-1;
			this.txtManageDoc.Text="";
			this.txtManageDoc.Tag=-1;
			this.txtFunNurse.Text="";
			this.txtFunNurse.Tag=-1;
			this.txtLinkFee.Text="";
			this.txtLinkFee.Tag=-1;
		}
		#endregion

		#region 刷新修改的内容
		/// <summary>
		/// 刷新修改的病床信息
		/// </summary>
		private void RefreshEditContent()
		{
			BedInfo bedInfo=(BedInfo)this.lstBed.SelectedItems[0].Tag;
			string sql="select a.bed_id, a.ward_id,b.ward_name,";
			sql+="a.dept_id,c.name,";
			sql+="a.room_no,a.bed_no,";
			sql+="a.hoitem_id,g.order_name,";
			sql+="a.zz_doc,d.name as zz_doc_name,";
			sql+="a.zy_doc,e.name as zy_doc_name,";
			sql+="a.chargenurse,f.name as chargenurse_name,a.isplus,isinuse,a.inpatient_id";
			sql+=" from zy_beddiction a left join jc_ward b on a.ward_id=b.ward_id";
			sql+=" left join jc_dept_property c on a.dept_id=c.dept_id";
			sql+=" left join jc_employee_property d on a.zz_doc=d.employee_id";
			sql+=" left join jc_employee_property e on a.zy_doc=e.employee_id";
			sql+=" left join jc_employee_property f on a.chargenurse=f.employee_id";
			sql+=" left join jc_hoitemdiction g on a.hoitem_id=g.order_id ";
			sql+=" where a.bed_id='"+bedInfo.BedID+"'";

			DataRow dr=InstanceForm.BDatabase.GetDataRow(sql);
			#region 重新赋值
			bedInfo.BedNo=dr["bed_no"].ToString();
			bedInfo.WardID=dr["ward_id"].ToString();
			bedInfo.WardName=dr["ward_name"].ToString();
			bedInfo.DeptID=Convert.IsDBNull(dr["dept_id"])?-1:Convert.ToInt64(dr["dept_id"]);
			bedInfo.DeptName=dr["name"].ToString().Trim();
			bedInfo.RoomNo=dr["room_no"].ToString().Trim();
			bedInfo.ChargeDocID=Convert.IsDBNull(dr["zz_doc"])?-1:Convert.ToInt64(dr["zz_doc"]);
			bedInfo.ChargeDocName=dr["zz_doc_name"].ToString().Trim();
			bedInfo.ManageDocID=Convert.IsDBNull(dr["zy_doc"])?-1:Convert.ToInt64(dr["zy_doc"]);
			bedInfo.ManageDocName=dr["zy_doc_name"].ToString().Trim();
			bedInfo.FunNurseID=Convert.IsDBNull(dr["chargenurse"])?-1:Convert.ToInt64(dr["chargenurse"]);
			bedInfo.FunNurseName=dr["chargenurse_name"].ToString().Trim();
			bedInfo.LinkFeeID=Convert.IsDBNull(dr["hoitem_id"])?-1:Convert.ToInt64(dr["hoitem_id"]);
			bedInfo.LinkFeeName=dr["order_name"].ToString();
			bedInfo.IsPlus=Convert.ToInt16(dr["isplus"])==1?true:false;
			bedInfo.IsInuse=Convert.IsDBNull(dr["inpatient_id"])?false:true;
			bedInfo.UseState=Convert.ToInt16(dr["isinuse"])==0?true:false;
			#endregion
			lstBed.SelectedItems[0].Tag=bedInfo;
			this.ShowBedInfo(bedInfo);
		}
		#endregion

		#region 刷新新增的内容(重载2次)
		/// <summary>
		/// 刷新病区的病床
		/// </summary>
		private void RefreshAddContent()
		{
			string wardId=cboWard.SelectedValue.ToString().Trim();
			this.GetWardRoomList(wardId);
		}
		/// <summary>
		/// 刷新病区的某个病房的病床
		/// </summary>
		/// <param name="WardID">病区ID(string)</param>
		/// <param name="RoomNo">房间号(string)</param>
		private void RefreshAddContent(string WardID,string RoomNo)
		{
			this.GetRoomBedList(WardID,RoomNo);
		}
		#endregion

		private void cboWard_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lstBed.Items.Clear();
			ClearBedInfo();
			string wardId=cboWard.SelectedValue.ToString();
			this.GetWardDeptList(wardId);
			this.GetWardRoomList(wardId);
			this.GetRoomBedList(wardId);	
		}

		private void lstRoom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lstRoom.SelectedItems.Count==0)
			{
				this.lstBed.Items.Clear();
				this.ClearBedInfo();
				return;
			}

			RoomInfo roomInfo=(RoomInfo)this.lstRoom.SelectedItems[0].Tag;
			this.GetRoomBedList(roomInfo.WardID,roomInfo.RoomNo);
		}
		
		private void lstDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            //GetWardRoomList
            if (lstDept.SelectedItems.Count == 0)
            {
                this.lstBed.Items.Clear();
                this.ClearBedInfo();
                return;
            }

            DeptInfo deptInfo = (DeptInfo)this.lstDept.SelectedItems[0].Tag;
            this.GetWardDeptList(deptInfo.WardID, deptInfo.DeptID);
		}
		private void lstBed_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lstBed.SelectedItems.Count==0) 
			{
				this.ClearBedInfo();
				return;
			}
			BedInfo bedInfo=(BedInfo)this.lstBed.SelectedItems[0].Tag;
			//TODO:显示床位信息
			this.ShowBedInfo(bedInfo);
			//控制启用/停用按钮显示
			if(bedInfo.UseState)
				this.tblbtnStatus.Text="停用";
			else
				this.tblbtnStatus.Text="启用";
		}

		private void tblToolbar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			FrmBedEdit fEdit=null;
			FrmAddBed fAdd=null;
			RoomInfo roomInfo=new RoomInfo();
			DeptInfo deptInfo=new DeptInfo();

			switch(e.Button.Tag.ToString().Trim())
			{
				case "ADD_ROOM":
                    if (_OnlyView) return;
					#region 增加病房的同时增加病床
					if(lstDept.SelectedItems.Count==0)
					{
						MessageBox.Show("请选择科室","",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
					//获取新增病房信息
					DlgInputBox dlgRoom=new DlgInputBox("","请输入新病房的病房号","增加病房");
					dlgRoom.ShowDialog();
					if(DlgInputBox.DlgResult)
					{
						string roomNo=DlgInputBox.DlgValue;
						if(roomNo.Trim()=="")
						{
							MessageBox.Show("无效的病房号","",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						}
						//获取增加病床前的必要信息
						roomInfo.RoomNo=roomNo;
						roomInfo.WardID=cboWard.SelectedValue.ToString();
						roomInfo.WardName=cboWard.Text;
						deptInfo=(DeptInfo)lstDept.SelectedItems[0].Tag;
                        
						#region TODO:判断病房号是否重复
						//每个病区的病房号是唯一的，与科室无关
						string sql="select room_no from zy_beddiction where ward_id='"+roomInfo.WardID+"' and room_no='"+roomInfo.RoomNo+"'";
						DataRow dr=InstanceForm.BDatabase.GetDataRow(sql);
						if(dr!=null)
						{
							MessageBox.Show("["+roomInfo.WardName+"] 已经有病房 ["+roomInfo.RoomNo+"]","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
							return;
						}
						#endregion

						//调用新增操作界面
//						fEdit=new FrmBedEdit(deptInfo,roomInfo);
//						fEdit.ShowDialog();
//						if(!fEdit._operateCancel)
//						{
//							this.RefreshAddContent();
//						}
						/*200731*/
						fAdd=new FrmAddBed(deptInfo,roomInfo);
						fAdd.ShowDialog();
					}
					#endregion
					break;
				case "ADD_BED":
                    if (_OnlyView) return;
					#region 增加新病床
					if(lstDept.SelectedItems.Count==0)
					{
						MessageBox.Show("请选择科室","",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
					if(lstRoom.SelectedItems.Count==0)
					{
						MessageBox.Show("请选择病房","",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
					deptInfo=(DeptInfo)this.lstDept.SelectedItems[0].Tag;
					roomInfo=(RoomInfo)this.lstRoom.SelectedItems[0].Tag;
					/*200731*/
					fAdd=new FrmAddBed(deptInfo,roomInfo);
					fAdd.ShowDialog();

					#endregion
					break;
				case "EDIT_BED":
                    if (_OnlyView) return;
					#region 修改病床信息
					if(lstBed.SelectedItems.Count==0)
					{
						MessageBox.Show("请选择要编辑的病床","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
						return;
					}
					BedInfo bedInfo=(BedInfo)lstBed.SelectedItems[0].Tag;
					fEdit=new FrmBedEdit(bedInfo);
					fEdit.ShowDialog();
					if(fEdit._ChangeRoom)
					{
						foreach(ListViewItem item in lstBed.SelectedItems)
						{
							lstBed.Items.Remove(item);
						}
						return;
					}
					if(!fEdit._operateCancel)
					{
						this.RefreshEditContent();
					}
					#endregion
					break;
				case "STOP_BEGIN":
                    if (_OnlyView) return;
					#region 启用/停用 病床
					try
					{
						if(lstBed.SelectedItems.Count==0) 
						{
							MessageBox.Show("请先选择病床","",MessageBoxButtons.OK,MessageBoxIcon.Information);
							return;
						}
						BedInfo bed=(BedInfo)lstBed.SelectedItems[0].Tag;
						if(bed.IsInuse)
						{
							MessageBox.Show("该床位还有病人，不能停用","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
							return;
						}
						
						string sql="";
						if(e.Button.Text=="停用")
						{
							DialogResult rst=MessageBox.Show("确定要停用该床吗？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
							if(rst==DialogResult.No) return;

							sql="update zy_beddiction set isinuse=1 where bed_id='"+bed.BedID+"'";
							InstanceForm.BDatabase.DoCommand(sql);
							this.RefreshEditContent();
							lstBed.SelectedItems[0].ImageIndex=4;
							e.Button.Text="启用";
                            string cznr = "停用：" + bed.WardName + bed.DeptName + "(" + bed.BedNo + "床)  bed_id-" + bed.BedID;
                            ts_jc_log.His_Log.SaveLog("床位停用", cznr, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);


						}
						else
						{
							DialogResult rst=MessageBox.Show("确定要启用该床吗？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
							if(rst==DialogResult.No) return;

							sql="update zy_beddiction set isinuse=0 where bed_id='"+bed.BedID+"'";
							InstanceForm.BDatabase.DoCommand(sql);
							this.RefreshEditContent();
							lstBed.SelectedItems[0].ImageIndex=2;
							e.Button.Text="停用";
                            string cznr = "启用：" + bed.WardName + bed.DeptName + "(" + bed.BedNo + "床)  bed_id-" + bed.BedID;
                            ts_jc_log.His_Log.SaveLog("床位启用", cznr, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);


						}
					}
					catch(Exception err)
					{
						MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
					}
					#endregion
					break;
				case "EXIT":
					this.Close();
					break;
				case "REFRESH":
					GetWardList();
					this.lstBed.Items.Clear();
					this.ClearBedInfo();
					break;
			}
		}

		private void lstBed_DoubleClick(object sender, System.EventArgs e)
		{
			if(lstBed.SelectedItems.Count==0) return;
			ToolBarButton tbbtn=new ToolBarButton();
			tbbtn.Tag="EDIT_BED";
			tblToolbar_ButtonClick(tbbtn,new ToolBarButtonClickEventArgs(tbbtn));
		}

		private void menuChangeRoomNo_Click(object sender, System.EventArgs e)
		{
			try
			{
                if (_OnlyView) return;
				if(lstRoom.SelectedItems.Count==0) return;
				RoomInfo room=(RoomInfo)lstRoom.SelectedItems[0].Tag;
				DlgInputBox dlgRoom=new DlgInputBox(room.RoomNo,"请输入新的房间号","修改房间号");
				dlgRoom.ShowDialog();
				if(DlgInputBox.DlgResult)
				{
					//判断房间号是否重复
					string roomNo=DlgInputBox.DlgValue;
					if(roomNo.Trim().ToUpper()==room.RoomNo.Trim().ToUpper()) return;
					DataRow dr=InstanceForm.BDatabase.GetDataRow("select * from zy_beddiction where room_no='"+roomNo+"' and ward_id='"+room.WardID+"'");
					if(dr!=null)
					{
						MessageBox.Show("该房间号已经存在","",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
					string sql="update zy_beddiction set room_no='"+roomNo+"' where ward_id='"+room.WardID+"' and room_no='"+room.RoomNo+"'";
					InstanceForm.BDatabase.DoCommand(sql);

					RoomInfo newRoom=new RoomInfo();
					newRoom.RoomNo=roomNo;
					newRoom.WardID=room.WardID;
					newRoom.WardName=room.WardName;
					lstRoom.SelectedItems[0].Tag=newRoom;
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void menuEditBedFee_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(lstRoom.SelectedItems.Count==0) return;
				RoomInfo room=(RoomInfo)lstRoom.SelectedItems[0].Tag;

                string sql = "select c.jgbm,order_id as ID,b.d_code as Code,order_name as name,b.py_code ,b.wb_code,c.price";
				sql+=" from jc_hoi_hdi a inner join jc_hoitemdiction b on a.hoitem_id=b.order_id";
				sql+=" inner join vi_jc_items c on a.hditem_id=c.itemid and a.tcid=c.tcid";
                sql += " where b.delete_bit=0 ";
                if ( ! string.IsNullOrEmpty(cwfCode.Trim()) )
                    sql += " and c.bigitemcode in (" + cwfCode + ") ";
                sql += " order by order_id";
				FrmSelectCard fSelect=new FrmSelectCard(sql);
				fSelect.ShowDialog();
				if(fSelect.FindResult)
				{
					long hoItemid=fSelect.SelectID;
					DialogResult rst=MessageBox.Show("确定要修改该房间的病房床位费吗？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if(rst==DialogResult.Yes)
					{
						sql="update zy_beddiction set hoitem_id="+hoItemid+" where ward_id='"+room.WardID+"' and room_no='"+room.RoomNo+"'";
						InstanceForm.BDatabase.DoCommand(sql);
						MessageBox.Show("床位费已修改","",MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}
				fSelect.Dispose();
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void FrmWardBed_Click(object sender, System.EventArgs e)
		{
			
		}

		private void lstDept_Click(object sender, System.EventArgs e)
		{
			string wardId="";
			lstBed.Items.Clear();
			if(lstDept.SelectedItems.Count==0)
			{
				wardId=cboWard.SelectedValue.ToString();
				this.GetWardRoomList(wardId);
			}
			else
			{
				DeptInfo deptInfo=(DeptInfo)this.lstDept.SelectedItems[0].Tag;

                //Modify by jchl
                string strCwInfo = string.Format("select  COUNT(1) as all_num,count(case when ISPLUS=1 then 0 end) as plus_num,count(case when INPATIENT_ID IS null then 0 end) as non_num from ZY_BEDDICTION where DEPT_ID={0} group by DEPT_ID",deptInfo.DeptID);
                DataTable dtCw=InstanceForm.BDatabase.GetDataTable(strCwInfo);
                if (dtCw != null && dtCw.Rows.Count > 0)
                {
                    string allNum = dtCw.Rows[0]["all_num"].ToString();
                    string plusNum = dtCw.Rows[0]["plus_num"].ToString();
                    string nonNum = dtCw.Rows[0]["non_num"].ToString();

                    lblAllNum.Text = allNum;
                    lblPlusNum.Text = plusNum;
                    lblNonNum.Text = nonNum;
                }
                //获取病房信息
                this.GetWardRoomList(deptInfo.WardID, deptInfo.DeptID);

                //获取病床信息
                this.GetWardDeptList(deptInfo.WardID, deptInfo.DeptID);

			}
		}

	}
}
