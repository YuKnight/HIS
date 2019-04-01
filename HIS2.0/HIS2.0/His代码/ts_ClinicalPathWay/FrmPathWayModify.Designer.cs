namespace ts_ClinicalPathWay
{
    partial class FrmPathWayModify
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPathWayModify));
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.menuMain = new DevExpress.XtraBars.Bar();
            this.btnSavePathWay = new DevExpress.XtraBars.BarButtonItem();
            this.btnRuleDictionary = new DevExpress.XtraBars.BarButtonItem();
            this.btnPathWayAssessment = new DevExpress.XtraBars.BarButtonItem();
            this.btnPathTableSet = new DevExpress.XtraBars.BarButtonItem();
            this.btnConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pathWay = new PathWay.PathWay();
            this.plStepInfo = new System.Windows.Forms.Panel();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnOperation = new DevExpress.XtraEditors.SimpleButton();
            this.chkIsFirst = new DevExpress.XtraEditors.CheckEdit();
            this.lbDay = new System.Windows.Forms.Label();
            this.tbTimeDown = new DevExpress.XtraEditors.CalcEdit();
            this.lbTo = new System.Windows.Forms.Label();
            this.tbTimeUp = new DevExpress.XtraEditors.CalcEdit();
            this.lbStepTime = new System.Windows.Forms.Label();
            this.tbStepName = new DevExpress.XtraEditors.TextEdit();
            this.lbStepName = new System.Windows.Forms.Label();
            this.btnExplain = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddKind = new DevExpress.XtraEditors.SimpleButton();
            this.tlItem = new DevExpress.XtraTreeList.TreeList();
            this.cmsTreeList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnGrouping = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelGrouping = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.插入一行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.plLoading = new System.Windows.Forms.Panel();
            this.lbLoading = new System.Windows.Forms.Label();
            this.ilLoading = new System.Windows.Forms.ImageList(this.components);
            this.tmrLoadingClose = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.plStepInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsFirst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeDown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStepName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlItem)).BeginInit();
            this.cmsTreeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.plLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "node.bmp");
            this.imageList1.Images.SetKeyName(1, "nodeopen.bmp");
            this.imageList1.Images.SetKeyName(2, "leaf.bmp");
            this.imageList1.Images.SetKeyName(3, "leafedit.bmp");
            // 
            // barManager
            // 
            this.barManager.AllowQuickCustomization = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.menuMain});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSavePathWay,
            this.btnPathWayAssessment,
            this.btnRuleDictionary,
            this.btnPathTableSet,
            this.btnConfig});
            this.barManager.MainMenu = this.menuMain;
            this.barManager.MaxItemId = 5;
            // 
            // menuMain
            // 
            this.menuMain.BarName = "Custom 1";
            this.menuMain.DockCol = 0;
            this.menuMain.DockRow = 0;
            this.menuMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.menuMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSavePathWay),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRuleDictionary),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPathWayAssessment),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPathTableSet),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfig)});
            this.menuMain.OptionsBar.MultiLine = true;
            this.menuMain.OptionsBar.UseWholeRow = true;
            this.menuMain.Text = "Custom 1";
            // 
            // btnSavePathWay
            // 
            this.btnSavePathWay.Caption = "保存路径(&S)";
            this.btnSavePathWay.Id = 0;
            this.btnSavePathWay.Name = "btnSavePathWay";
            this.btnSavePathWay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSavePathWay_ItemClick_1);
            // 
            // btnRuleDictionary
            // 
            this.btnRuleDictionary.Caption = "评估字典(&D)";
            this.btnRuleDictionary.Id = 2;
            this.btnRuleDictionary.Name = "btnRuleDictionary";
            // 
            // btnPathWayAssessment
            // 
            this.btnPathWayAssessment.Caption = "路径评估(&A)";
            this.btnPathWayAssessment.Id = 1;
            this.btnPathWayAssessment.Name = "btnPathWayAssessment";
            // 
            // btnPathTableSet
            // 
            this.btnPathTableSet.Caption = "表单选择(&T)";
            this.btnPathTableSet.Id = 3;
            this.btnPathTableSet.Name = "btnPathTableSet";
            this.btnPathTableSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPathTableSet_ItemClick);
            // 
            // btnConfig
            // 
            this.btnConfig.Caption = "表单配置(&C)";
            this.btnConfig.Id = 4;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfig_ItemClick);
            // 
            // pathWay
            // 
            this.pathWay.AutoScroll = true;
            this.pathWay.BackColor = System.Drawing.Color.Cornsilk;
            this.pathWay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pathWay.BackgroundImage")));
            this.pathWay.Dock = System.Windows.Forms.DockStyle.Top;
            this.pathWay.Location = new System.Drawing.Point(0, 25);
            this.pathWay.Name = "pathWay";
            this.pathWay.OnlyOneFirst = true;
            this.pathWay.ShowModifyForm = false;
            this.pathWay.Size = new System.Drawing.Size(1016, 150);
            this.pathWay.TabIndex = 1;
            // 
            // plStepInfo
            // 
            this.plStepInfo.Controls.Add(this.btnDelete);
            this.plStepInfo.Controls.Add(this.btnOperation);
            this.plStepInfo.Controls.Add(this.chkIsFirst);
            this.plStepInfo.Controls.Add(this.lbDay);
            this.plStepInfo.Controls.Add(this.tbTimeDown);
            this.plStepInfo.Controls.Add(this.lbTo);
            this.plStepInfo.Controls.Add(this.tbTimeUp);
            this.plStepInfo.Controls.Add(this.lbStepTime);
            this.plStepInfo.Controls.Add(this.tbStepName);
            this.plStepInfo.Controls.Add(this.lbStepName);
            this.plStepInfo.Controls.Add(this.btnExplain);
            this.plStepInfo.Controls.Add(this.btnAddItem);
            this.plStepInfo.Controls.Add(this.btnAddKind);
            this.plStepInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plStepInfo.Location = new System.Drawing.Point(0, 175);
            this.plStepInfo.Name = "plStepInfo";
            this.plStepInfo.Size = new System.Drawing.Size(1016, 30);
            this.plStepInfo.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDelete.Location = new System.Drawing.Point(267, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "删除(F9)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnOperation
            // 
            this.btnOperation.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnOperation.Appearance.Options.UseForeColor = true;
            this.btnOperation.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOperation.Location = new System.Drawing.Point(201, 4);
            this.btnOperation.Name = "btnOperation";
            this.btnOperation.Size = new System.Drawing.Size(60, 23);
            this.btnOperation.TabIndex = 11;
            this.btnOperation.Text = "手术(F8)";
            // 
            // chkIsFirst
            // 
            this.chkIsFirst.Location = new System.Drawing.Point(688, 6);
            this.chkIsFirst.Name = "chkIsFirst";
            this.chkIsFirst.Properties.Caption = "起始阶段";
            this.chkIsFirst.Size = new System.Drawing.Size(75, 19);
            this.chkIsFirst.TabIndex = 10;
            // 
            // lbDay
            // 
            this.lbDay.AutoSize = true;
            this.lbDay.Location = new System.Drawing.Point(665, 10);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(17, 12);
            this.lbDay.TabIndex = 9;
            this.lbDay.Text = "天";
            // 
            // tbTimeDown
            // 
            this.tbTimeDown.Location = new System.Drawing.Point(570, 5);
            this.tbTimeDown.Name = "tbTimeDown";
            this.tbTimeDown.Size = new System.Drawing.Size(30, 21);
            this.tbTimeDown.TabIndex = 8;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(606, 10);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(17, 12);
            this.lbTo.TabIndex = 7;
            this.lbTo.Text = "到";
            // 
            // tbTimeUp
            // 
            this.tbTimeUp.Location = new System.Drawing.Point(629, 5);
            this.tbTimeUp.Name = "tbTimeUp";
            this.tbTimeUp.Size = new System.Drawing.Size(30, 21);
            this.tbTimeUp.TabIndex = 6;
            // 
            // lbStepTime
            // 
            this.lbStepTime.AutoSize = true;
            this.lbStepTime.Location = new System.Drawing.Point(505, 10);
            this.lbStepTime.Name = "lbStepTime";
            this.lbStepTime.Size = new System.Drawing.Size(59, 12);
            this.lbStepTime.TabIndex = 5;
            this.lbStepTime.Text = "阶段历时:";
            // 
            // tbStepName
            // 
            this.tbStepName.Location = new System.Drawing.Point(399, 5);
            this.tbStepName.Name = "tbStepName";
            this.tbStepName.Size = new System.Drawing.Size(100, 21);
            this.tbStepName.TabIndex = 4;
            // 
            // lbStepName
            // 
            this.lbStepName.AutoSize = true;
            this.lbStepName.Location = new System.Drawing.Point(334, 10);
            this.lbStepName.Name = "lbStepName";
            this.lbStepName.Size = new System.Drawing.Size(59, 12);
            this.lbStepName.TabIndex = 3;
            this.lbStepName.Text = "阶段名称:";
            // 
            // btnExplain
            // 
            this.btnExplain.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnExplain.Appearance.Options.UseForeColor = true;
            this.btnExplain.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExplain.Location = new System.Drawing.Point(135, 4);
            this.btnExplain.Name = "btnExplain";
            this.btnExplain.Size = new System.Drawing.Size(60, 23);
            this.btnExplain.TabIndex = 2;
            this.btnExplain.Text = "说明(F7)";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnAddItem.Appearance.Options.UseForeColor = true;
            this.btnAddItem.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAddItem.Location = new System.Drawing.Point(69, 4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(60, 23);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "项目(F3)";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click_1);
            // 
            // btnAddKind
            // 
            this.btnAddKind.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnAddKind.Appearance.Options.UseForeColor = true;
            this.btnAddKind.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAddKind.Location = new System.Drawing.Point(3, 4);
            this.btnAddKind.Name = "btnAddKind";
            this.btnAddKind.Size = new System.Drawing.Size(60, 23);
            this.btnAddKind.TabIndex = 0;
            this.btnAddKind.Text = "分类(F2)";
            this.btnAddKind.Click += new System.EventHandler(this.btnAddKind_Click_1);
            // 
            // tlItem
            // 
            this.tlItem.ContextMenuStrip = this.cmsTreeList;
            this.tlItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlItem.Location = new System.Drawing.Point(0, 205);
            this.tlItem.Name = "tlItem";
            this.tlItem.OptionsSelection.MultiSelect = true;
            this.tlItem.OptionsView.AutoWidth = false;
            this.tlItem.Size = new System.Drawing.Size(1016, 507);
            this.tlItem.TabIndex = 7;
            // 
            // cmsTreeList
            // 
            this.cmsTreeList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGrouping,
            this.btnCancelGrouping,
            this.toolStripSeparator1,
            this.插入一行ToolStripMenuItem});
            this.cmsTreeList.Name = "cmsTreeList";
            this.cmsTreeList.Size = new System.Drawing.Size(142, 76);
            // 
            // btnGrouping
            // 
            this.btnGrouping.Name = "btnGrouping";
            this.btnGrouping.Size = new System.Drawing.Size(141, 22);
            this.btnGrouping.Text = "药品分组(&G)";
            this.btnGrouping.Click += new System.EventHandler(this.btnGrouping_Click_1);
            // 
            // btnCancelGrouping
            // 
            this.btnCancelGrouping.Name = "btnCancelGrouping";
            this.btnCancelGrouping.Size = new System.Drawing.Size(141, 22);
            this.btnCancelGrouping.Text = "取消分组(&C)";
            this.btnCancelGrouping.Click += new System.EventHandler(this.btnCancelGrouping_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // 插入一行ToolStripMenuItem
            // 
            this.插入一行ToolStripMenuItem.Name = "插入一行ToolStripMenuItem";
            this.插入一行ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.插入一行ToolStripMenuItem.Text = "插入一行";
            this.插入一行ToolStripMenuItem.Click += new System.EventHandler(this.插入一行ToolStripMenuItem_Click);
            // 
            // pbLoading
            // 
            this.pbLoading.BackColor = System.Drawing.Color.White;
            this.pbLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbLoading.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLoading.ErrorImage = null;
            this.pbLoading.InitialImage = null;
            this.pbLoading.Location = new System.Drawing.Point(0, 0);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(53, 62);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLoading.TabIndex = 8;
            this.pbLoading.TabStop = false;
            // 
            // plLoading
            // 
            this.plLoading.BackColor = System.Drawing.Color.White;
            this.plLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plLoading.Controls.Add(this.lbLoading);
            this.plLoading.Controls.Add(this.pbLoading);
            this.plLoading.Location = new System.Drawing.Point(408, 269);
            this.plLoading.Name = "plLoading";
            this.plLoading.Size = new System.Drawing.Size(200, 64);
            this.plLoading.TabIndex = 9;
            this.plLoading.Visible = false;
            // 
            // lbLoading
            // 
            this.lbLoading.AutoSize = true;
            this.lbLoading.Location = new System.Drawing.Point(58, 27);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(101, 12);
            this.lbLoading.TabIndex = 9;
            this.lbLoading.Text = "正在加载数据....";
            // 
            // ilLoading
            // 
            this.ilLoading.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilLoading.ImageStream")));
            this.ilLoading.TransparentColor = System.Drawing.Color.Transparent;
            this.ilLoading.Images.SetKeyName(0, "1");
            this.ilLoading.Images.SetKeyName(1, "2");
            this.ilLoading.Images.SetKeyName(2, "3");
            this.ilLoading.Images.SetKeyName(3, "4");
            this.ilLoading.Images.SetKeyName(4, "5");
            this.ilLoading.Images.SetKeyName(5, "6");
            this.ilLoading.Images.SetKeyName(6, "7");
            this.ilLoading.Images.SetKeyName(7, "8");
            this.ilLoading.Images.SetKeyName(8, "9");
            this.ilLoading.Images.SetKeyName(9, "10");
            this.ilLoading.Images.SetKeyName(10, "11");
            this.ilLoading.Images.SetKeyName(11, "12");
            this.ilLoading.Images.SetKeyName(12, "13");
            this.ilLoading.Images.SetKeyName(13, "14");
            this.ilLoading.Images.SetKeyName(14, "15");
            // 
            // tmrLoadingClose
            // 
            this.tmrLoadingClose.Interval = 1;
            // 
            // FrmPathWayModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.plLoading);
            this.Controls.Add(this.tlItem);
            this.Controls.Add(this.plStepInfo);
            this.Controls.Add(this.pathWay);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "FrmPathWayModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "路径配置";
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pathWay, 0);
            this.Controls.SetChildIndex(this.plStepInfo, 0);
            this.Controls.SetChildIndex(this.tlItem, 0);
            this.Controls.SetChildIndex(this.plLoading, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.plStepInfo.ResumeLayout(false);
            this.plStepInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsFirst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeDown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStepName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlItem)).EndInit();
            this.cmsTreeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.plLoading.ResumeLayout(false);
            this.plLoading.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar menuMain;
        private DevExpress.XtraBars.BarButtonItem btnSavePathWay;
        private DevExpress.XtraBars.BarButtonItem btnPathWayAssessment;
        private DevExpress.XtraBars.BarButtonItem btnRuleDictionary;
        private PathWay.PathWay pathWay;
        private System.Windows.Forms.Panel plStepInfo;
        private DevExpress.XtraTreeList.TreeList tlItem;
        private DevExpress.XtraEditors.SimpleButton btnAddKind;
        private DevExpress.XtraEditors.SimpleButton btnAddItem;
        private DevExpress.XtraEditors.SimpleButton btnExplain;
        private System.Windows.Forms.Label lbStepName;
        private DevExpress.XtraEditors.TextEdit tbStepName;
        private System.Windows.Forms.Label lbStepTime;
        private DevExpress.XtraEditors.CalcEdit tbTimeUp;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.Label lbDay;
        private DevExpress.XtraEditors.CalcEdit tbTimeDown;
        private DevExpress.XtraEditors.CheckEdit chkIsFirst;
        private System.Windows.Forms.ContextMenuStrip cmsTreeList;
        private System.Windows.Forms.ToolStripMenuItem btnCancelGrouping;
        private DevExpress.XtraEditors.SimpleButton btnOperation;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Panel plLoading;
        private System.Windows.Forms.Label lbLoading;
        private System.Windows.Forms.ImageList ilLoading;
        private System.Windows.Forms.Timer tmrLoadingClose;
        private DevExpress.XtraBars.BarButtonItem btnPathTableSet;
        private DevExpress.XtraBars.BarButtonItem btnConfig;
        private System.Windows.Forms.ToolStripMenuItem btnGrouping;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 插入一行ToolStripMenuItem;
    }
}