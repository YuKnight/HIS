using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenFrame.Classes ;
using TrasenClasses.GeneralClasses;
using System.Management;
using System.Data; 
using System.Collections.Generic;

namespace TrasenFrame.Forms
{
    /// <summary>
    /// 参数设置对话框
    /// </summary>
    public class FrmParaSetting : System.Windows.Forms.Form
    {
        //自定义变量
        //private int _threadNum;
        //private bool _printerSearchComplete;	//打印机是否搜索完毕
        private string _backGroundImagePath = Constant.BackGroundPicturePath;
        //自动产生变量
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFirstRun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbImeMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox picBk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbReportPrinter;
        private System.Windows.Forms.Button btRefreshPrinter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMenuFontSize;
        private System.Windows.Forms.ComboBox cboBackground;
        private CheckBox chkIsSelectConnect;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// 参数设置窗口构造函数
        /// </summary>
        public FrmParaSetting()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
        }
        /// <summary>
        /// 参数设置窗口构造函数
        /// </summary>
        /// <param name="chineseName">标题</param>
        public FrmParaSetting(string chineseName)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            this.Text = chineseName;
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSure = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIsSelectConnect = new System.Windows.Forms.CheckBox();
            this.cboBackground = new System.Windows.Forms.ComboBox();
            this.cboMenuFontSize = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btRefreshPrinter = new System.Windows.Forms.Button();
            this.cmbReportPrinter = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.picBk = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbImeMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFirstRun = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBk)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(260, 291);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(92, 30);
            this.btnSure.TabIndex = 1;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(365, 291);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsSelectConnect);
            this.groupBox1.Controls.Add(this.cboBackground);
            this.groupBox1.Controls.Add(this.cboMenuFontSize);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmbImeMode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 279);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // chkIsSelectConnect
            // 
            this.chkIsSelectConnect.AutoSize = true;
            this.chkIsSelectConnect.Location = new System.Drawing.Point(18, 119);
            this.chkIsSelectConnect.Name = "chkIsSelectConnect";
            this.chkIsSelectConnect.Size = new System.Drawing.Size(144, 16);
            this.chkIsSelectConnect.TabIndex = 13;
            this.chkIsSelectConnect.Text = "是否允许选择链接登陆";
            this.chkIsSelectConnect.UseVisualStyleBackColor = true;
            this.chkIsSelectConnect.Visible = false;
            // 
            // cboBackground
            // 
            this.cboBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBackground.Location = new System.Drawing.Point(124, 56);
            this.cboBackground.Name = "cboBackground";
            this.cboBackground.Size = new System.Drawing.Size(188, 20);
            this.cboBackground.TabIndex = 22;
            this.cboBackground.SelectionChangeCommitted += new System.EventHandler(this.cboBackground_SelectionChangeCommitted);
            // 
            // cboMenuFontSize
            // 
            this.cboMenuFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenuFontSize.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cboMenuFontSize.Location = new System.Drawing.Point(124, 86);
            this.cboMenuFontSize.Name = "cboMenuFontSize";
            this.cboMenuFontSize.Size = new System.Drawing.Size(84, 20);
            this.cboMenuFontSize.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "菜单字体大小：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtPort);
            this.groupBox5.Controls.Add(this.btRefreshPrinter);
            this.groupBox5.Controls.Add(this.cmbReportPrinter);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.cmbPrinter);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(8, 195);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(434, 75);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "外部设备";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(358, 46);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(70, 21);
            this.txtPort.TabIndex = 18;
            // 
            // btRefreshPrinter
            // 
            this.btRefreshPrinter.Location = new System.Drawing.Point(270, 18);
            this.btRefreshPrinter.Name = "btRefreshPrinter";
            this.btRefreshPrinter.Size = new System.Drawing.Size(158, 26);
            this.btRefreshPrinter.TabIndex = 23;
            this.btRefreshPrinter.Text = "搜索并配置打印机";
            this.btRefreshPrinter.Click += new System.EventHandler(this.btRefreshPrinter_Click);
            // 
            // cmbReportPrinter
            // 
            this.cmbReportPrinter.DropDownWidth = 150;
            this.cmbReportPrinter.Location = new System.Drawing.Point(116, 46);
            this.cmbReportPrinter.Name = "cmbReportPrinter";
            this.cmbReportPrinter.Size = new System.Drawing.Size(150, 20);
            this.cmbReportPrinter.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "报表打印机：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.DropDownWidth = 150;
            this.cmbPrinter.Location = new System.Drawing.Point(116, 18);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(150, 20);
            this.cmbPrinter.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "发票打印机：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "报价器COM口：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.picBk);
            this.groupBox4.Location = new System.Drawing.Point(319, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(123, 106);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "背景图片预览";
            // 
            // picBk
            // 
            this.picBk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBk.Location = new System.Drawing.Point(3, 17);
            this.picBk.Name = "picBk";
            this.picBk.Size = new System.Drawing.Size(117, 86);
            this.picBk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBk.TabIndex = 18;
            this.picBk.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "背景图片路径：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbFilterType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbSearchType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 44);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选项卡设置";
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Location = new System.Drawing.Point(346, 20);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(82, 20);
            this.cmbFilterType.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "过滤字段：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Location = new System.Drawing.Point(116, 20);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(150, 20);
            this.cmbSearchType.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "过滤方式：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbImeMode
            // 
            this.cmbImeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImeMode.Location = new System.Drawing.Point(124, 22);
            this.cmbImeMode.Name = "cmbImeMode";
            this.cmbImeMode.Size = new System.Drawing.Size(188, 20);
            this.cmbImeMode.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "个性化中文输入法：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "报表路径：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFirstRun
            // 
            this.cmbFirstRun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFirstRun.Location = new System.Drawing.Point(104, 334);
            this.cmbFirstRun.Name = "cmbFirstRun";
            this.cmbFirstRun.Size = new System.Drawing.Size(191, 20);
            this.cmbFirstRun.TabIndex = 9;
            this.cmbFirstRun.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "启动模块：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(106, 366);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(189, 21);
            this.txtLogPath.TabIndex = 12;
            // 
            // FrmParaSetting
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(465, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.cmbFirstRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogPath);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmParaSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.FrmParaSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBk)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private void InitializeComboBox()
        {
            try
            {
                LoadImeMode();
                LoadSearchType();
                LoadFilterType();
                LoadBackGround();
                LoadDefaultCom();
                LoadMenuFontSize();
                LoadBackGroupImage();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// 输入法
        /// </summary>
        private void LoadImeMode()
        {
            Item item = null;
            int selIndex = 0;
            #region 输入法
            string cIme = Constant.CustomImeMode;
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                item = new Item();
                item.Text = InputLanguage.InstalledInputLanguages[i].LayoutName;
                item.Value = i;
                cmbImeMode.Items.Add(item);
                if (cIme == item.Text)
                {
                    selIndex = i;
                }
            }
            if (cmbImeMode.Items.Count > 0)
            {
                cmbImeMode.SelectedIndex = selIndex;
            }
            #endregion
         
        }
        /// <summary>
        /// 过滤方式
        /// </summary>
        private void LoadSearchType()
        {
            Item item = null;
            #region 过滤方式
            item = new Item();
            item.Text = "前导相似";
            item.Value = SearchType.前导相似;
            cmbSearchType.Items.Add(item);
            item = new Item();
            item.Text = "精确定位";
            item.Value = SearchType.精确定位;
            cmbSearchType.Items.Add(item);
            item = new Item();
            item.Text = "模糊查询";
            item.Value = SearchType.模糊查询;
            cmbSearchType.Items.Add(item);
            cmbSearchType.SelectedIndex = GetSelectIndex(cmbSearchType, Constant.CustomSearchType);
            #endregion
           
        }
        /// <summary>
        /// 过滤字段
        /// </summary>
        private void LoadFilterType()
        {
            Item item = null;
            #region 过滤字段
            item = new Item();
            item.Text = "智能";
            item.Value = FilterType.智能;
            cmbFilterType.Items.Add(item);
            item = new Item();
            item.Text = "拼音";
            item.Value = FilterType.拼音;
            cmbFilterType.Items.Add(item);
            item = new Item();
            item.Text = "五笔";
            item.Value = FilterType.五笔;
            cmbFilterType.Items.Add(item);
            item = new Item();
            item.Text = "数字";
            item.Value = FilterType.数字;
            cmbFilterType.Items.Add(item);
            cmbFilterType.SelectedIndex = GetSelectIndex(cmbFilterType, Constant.CustomFilterType);
            #endregion
           
        }
        /// <summary>
        /// 背景图片路径
        /// </summary>
        private void LoadBackGround()
        {
            #region 背景图片路径
            _backGroundImagePath = Constant.BackGroundPicturePath;
            #endregion
           
        }
        /// <summary>
        ///  COM口
        /// </summary>
        private void LoadDefaultCom()
        {
            #region  COM口
            txtPort.Text = Constant.ComPort;
            #endregion
          
        }
        /// <summary>
        /// 发票打印机\报表打印机
        /// </summary>
        private void LoadDefaultPrinter()
        {
            string cInvoicePrinterName = Constant.CInvoicePrinterName;
            string cReportPrinterName = Constant.CReportPrinterName;
            PrinterManager printerManager = new PrinterManager();
            List<string> installedPrinters = printerManager.GetInstanlledPrinters();
            cmbPrinter.Items.Clear();
            cmbReportPrinter.Items.Clear();
            foreach( string name in installedPrinters )
            {
                cmbPrinter.Items.Add( name );
                cmbReportPrinter.Items.Add( name );
            }
            cmbPrinter.Text = cInvoicePrinterName;
            cmbReportPrinter.Text = cReportPrinterName;
        }
        /// <summary>
        /// 加载字体
        /// </summary>
        private void LoadMenuFontSize()
        {
            string tmp = Constant.MenuFontSize;

            this.cboMenuFontSize.SelectedIndex = GetSelectIndex(this.cboMenuFontSize, tmp);

        }
        private void LoadBackGroupImage()
        {
            //Modify By Tany 2012-02-20 如果注册名字不是Trasen，那么不加载图片
            //if(FrmMdiMain.m)
            if (FrmMdiMain.FRAMEKIND == FrameKind.东软)
            {
                this.cboBackground.Items.Add("ehis.JPG");
            }
            else if ( FrmMdiMain.FRAMEKIND == FrameKind.弘麒 )
            {
                this.cboBackground.Items.Add( "OnKiy.JPG" );
            }
            else
            {
                this.cboBackground.Items.Add( "ts001.JPG" );
                this.cboBackground.Items.Add( "ts002.JPG" );
                this.cboBackground.Items.Add( "ts003.JPG" );
                this.cboBackground.Items.Add( "ts004.JPG" );
                this.cboBackground.Items.Add( "ts005.JPG" );
                this.cboBackground.Items.Add( "ts006.JPG" );
                this.cboBackground.Items.Add( "ts007.JPG" );
                this.cboBackground.Items.Add( "ts008.JPG" );
                this.cboBackground.Items.Add( "ts009.JPG" );
                this.cboBackground.Items.Add( "自定义" );
            }
            //this.cboBackground.SelectedIndex = GetSelectIndex(this.cboBackground, Constant.BackImage);

            // add by wangzhi 2013-10-11
            string imageName = "";
            bool isFile = false;
            ( new TrasenFrame.Classes.AppEnvironment() ).GetBackgroundImage( TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode , out imageName , out isFile );
            if ( isFile )
                this.cboBackground.Text = "自定义";
            else
                this.cboBackground.Text = imageName;
        }
        /// <summary>
        /// 寻找选择项
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int GetSelectIndex(ComboBox cmb, Object obj)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (((Item)cmb.Items[i]).Value.ToString() == obj.ToString())
                {
                    return i;
                }
            }
            return 0;
        }
        private int GetSelectIndex(ComboBox cmb, string values)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (cmb.Items[i].ToString().Trim() == values.Trim())
                    return i;
            }
            return -1;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSure_Click(object sender, System.EventArgs e)
        {

            //中文输入法
            Constant.CustomImeMode = ((Item)cmbImeMode.SelectedItem).Text;
            //过滤方式
            Constant.CustomSearchType = (SearchType)((Item)cmbSearchType.SelectedItem).Value;
            //过滤字段
            Constant.CustomFilterType = (FilterType)((Item)cmbFilterType.SelectedItem).Value;
            //背景图片路径
            //Constant.BackGroundPicturePath = this._backGroundImagePath;
            //Constant.BackImage = this.cboBackground.Text;
            if ( cboBackground.Text == "自定义" )
                ( new TrasenFrame.Classes.AppEnvironment() ).SetBackgroundImage( TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode , this._backGroundImagePath , true );
            else
                ( new TrasenFrame.Classes.AppEnvironment() ).SetBackgroundImage( TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode , this.cboBackground.Text , false );
            //COM端口
            Constant.ComPort = txtPort.Text.Trim();
            
            //票据打印机设置
            Constant.CInvoicePrinterName = cmbPrinter.Text;
            //报表打印机设置
            Constant.CReportPrinterName = cmbReportPrinter.Text;
            
            //字体大小
            Constant.MenuFontSize = this.cboMenuFontSize.Text;

            Constant.IsSelectConnect = chkIsSelectConnect.Checked;

            MessageBox.Show("参数设置保存成功！\n重新登录后设置方能生效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }


        private void FrmParaSetting_Load(object sender, System.EventArgs e)
        {
            
            
            //初始化组合框
            InitializeComboBox();
            //初始话打印机
            cmbPrinter.Enabled = false;
            cmbReportPrinter.Enabled = false;
            cmbPrinter.Text = Constant.CInvoicePrinterName;
            cmbReportPrinter.Text = Constant.CReportPrinterName;

            //Add By Tany 2009-08-06
            chkIsSelectConnect.Checked = Constant.IsSelectConnect;
            chkIsSelectConnect.Visible = FrmMdiMain.CurrentUser.IsAdministrator;
        }

        private void btRefreshPrinter_Click(object sender, System.EventArgs e)
        {
            cmbPrinter.Enabled = true;
            cmbReportPrinter.Enabled = true;
            cmbPrinter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportPrinter.DropDownStyle = ComboBoxStyle.DropDownList;
            Cursor.Current = PubStaticFun.WaitCursor();
            LoadDefaultPrinter();
            Cursor.Current = Cursors.Default;
            FrmPrinterSetting fPrinterSet = new FrmPrinterSetting();
            fPrinterSet.ShowDialog( this );
        }

        private void cboBackground_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            this._backGroundImagePath = "";
            if (cboBackground.Text == "自定义")
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = @"所有图像文件(*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico;*.emf;*.wmf)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico;*.emf;*.wmf|
							位图文件(*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico|图元文件(*.emf;*.wmf)|*.emf;*.wmf";
                dlgOpen.Title = "请选择图片";
                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    this._backGroundImagePath = dlgOpen.FileName;
                    picBk.Image = Image.FromFile(_backGroundImagePath);
                }
                dlgOpen.Dispose();
                dlgOpen = null;
            }
            else
            {
                System.IO.Stream strm = this.GetType().Assembly.GetManifestResourceStream("TrasenFrame.Forms.Background." + cboBackground.Text);

                if (strm != null)
                {
                    picBk.Image = Image.FromStream(strm);
                }
                else
                    this.BackgroundImage = null;
            }
        }

    }
}
