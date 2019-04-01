using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_hzhljl
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class frmWZHZHLJL : System.Windows.Forms.Form
    {
        //自定义变量
        private BaseFunc myFunc;
        private int current_id = 0;
        private bool isNew = true;
        private Guid pat_id = Guid.Empty;
        private long baby_id = 0;
        private string strSql = "";

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker DtpbeginDate;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btSaveModel;
        private System.Windows.Forms.Button btOpenModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt新建;
        private System.Windows.Forms.Button bt保存;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.RichTextBox rtbBook;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblBed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblZyh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTW;
        private System.Windows.Forms.TextBox txtMB;
        private System.Windows.Forms.TextBox txtHX;
        private System.Windows.Forms.TextBox txtXY;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtInQuantity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtStool;
        private System.Windows.Forms.TextBox txtPee;
        private System.Windows.Forms.Label label17;
        private RichTextBoxEx rtbShow;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel6;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtInpatNo;
        private System.Windows.Forms.Button btnSeek;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Splitter splitter2;
        private System.ComponentModel.IContainer components;

        public frmWZHZHLJL(string _formText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rtbShow = new TrasenClasses.GeneralControls.RichTextBoxEx(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblWard = new System.Windows.Forms.Label();
            this.lblBed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblZyh = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtInQuantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbBook = new System.Windows.Forms.RichTextBox();
            this.txtXY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtStool = new System.Windows.Forms.TextBox();
            this.txtPee = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.bt新建 = new System.Windows.Forms.Button();
            this.btSaveModel = new System.Windows.Forms.Button();
            this.btOpenModel = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.bt保存 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtInpatNo = new System.Windows.Forms.TextBox();
            this.btnSeek = new System.Windows.Forms.Button();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(160, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 701);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.rtbShow);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(744, 353);
            this.panel4.TabIndex = 64;
            // 
            // rtbShow
            // 
            this.rtbShow.BackColor = System.Drawing.SystemColors.Window;
            this.rtbShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbShow.DetectUrls = false;
            this.rtbShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbShow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbShow.LinkStyle = true;
            this.rtbShow.Location = new System.Drawing.Point(0, 0);
            this.rtbShow.Name = "rtbShow";
            this.rtbShow.ReadOnly = true;
            this.rtbShow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbShow.Size = new System.Drawing.Size(744, 353);
            this.rtbShow.TabIndex = 59;
            this.rtbShow.Text = "";
            this.toolTip1.SetToolTip(this.rtbShow, "点击【  】里面的数字修改记录");
            this.rtbShow.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbShow_LinkClicked);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.lblDept);
            this.panel5.Controls.Add(this.lblWard);
            this.panel5.Controls.Add(this.lblBed);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.lblName);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.lblZyh);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(744, 40);
            this.panel5.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(127, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "科室";
            // 
            // lblDept
            // 
            this.lblDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDept.Location = new System.Drawing.Point(175, 16);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(88, 23);
            this.lblDept.TabIndex = 3;
            // 
            // lblWard
            // 
            this.lblWard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWard.Location = new System.Drawing.Point(319, 16);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(80, 23);
            this.lblWard.TabIndex = 5;
            // 
            // lblBed
            // 
            this.lblBed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBed.Location = new System.Drawing.Point(455, 16);
            this.lblBed.Name = "lblBed";
            this.lblBed.Size = new System.Drawing.Size(64, 23);
            this.lblBed.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(407, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 23);
            this.label9.TabIndex = 6;
            this.label9.Text = "床号";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(55, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 23);
            this.lblName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "姓名";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(271, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "病区";
            // 
            // lblZyh
            // 
            this.lblZyh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZyh.Location = new System.Drawing.Point(583, 16);
            this.lblZyh.Name = "lblZyh";
            this.lblZyh.Size = new System.Drawing.Size(72, 23);
            this.lblZyh.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(527, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 23);
            this.label11.TabIndex = 8;
            this.label11.Text = "住院号";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 393);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(744, 4);
            this.splitter1.TabIndex = 61;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.txtXY);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtHX);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtMB);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtTW);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblId);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.DtpbeginDate);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 397);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 248);
            this.panel3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtItem);
            this.groupBox2.Controls.Add(this.txtInQuantity);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(8, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 48);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入量(毫升)";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 16);
            this.label12.TabIndex = 79;
            this.label12.Text = "项目";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(40, 16);
            this.txtItem.MaxLength = 14;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(120, 21);
            this.txtItem.TabIndex = 5;
            this.txtItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // txtInQuantity
            // 
            this.txtInQuantity.Location = new System.Drawing.Point(216, 16);
            this.txtInQuantity.Name = "txtInQuantity";
            this.txtInQuantity.Size = new System.Drawing.Size(112, 21);
            this.txtInQuantity.TabIndex = 6;
            this.txtInQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(168, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 81;
            this.label13.Text = "实入量";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rtbBook);
            this.groupBox1.Location = new System.Drawing.Point(0, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 128);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病情及处理";
            // 
            // rtbBook
            // 
            this.rtbBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbBook.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbBook.Location = new System.Drawing.Point(3, 17);
            this.rtbBook.MaxLength = 7800;
            this.rtbBook.Name = "rtbBook";
            this.rtbBook.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbBook.Size = new System.Drawing.Size(738, 108);
            this.rtbBook.TabIndex = 11;
            this.rtbBook.Text = "";
            // 
            // txtXY
            // 
            this.txtXY.Location = new System.Drawing.Point(597, 40);
            this.txtXY.Name = "txtXY";
            this.txtXY.Size = new System.Drawing.Size(87, 21);
            this.txtXY.TabIndex = 3;
            this.txtXY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(526, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 76;
            this.label10.Text = "血压(mmHg)";
            // 
            // txtHX
            // 
            this.txtHX.Location = new System.Drawing.Point(423, 41);
            this.txtHX.Name = "txtHX";
            this.txtHX.Size = new System.Drawing.Size(87, 21);
            this.txtHX.TabIndex = 2;
            this.txtHX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(347, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 74;
            this.label8.Text = "呼吸(次/分)";
            // 
            // txtMB
            // 
            this.txtMB.Location = new System.Drawing.Point(246, 41);
            this.txtMB.Name = "txtMB";
            this.txtMB.Size = new System.Drawing.Size(87, 21);
            this.txtMB.TabIndex = 1;
            this.txtMB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(172, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 72;
            this.label6.Text = "脉搏(次/分)";
            // 
            // txtTW
            // 
            this.txtTW.Location = new System.Drawing.Point(71, 41);
            this.txtTW.Name = "txtTW";
            this.txtTW.Size = new System.Drawing.Size(87, 21);
            this.txtTW.TabIndex = 0;
            this.txtTW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "体温(℃)";
            // 
            // lblId
            // 
            this.lblId.ForeColor = System.Drawing.Color.Blue;
            this.lblId.Location = new System.Drawing.Point(69, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(80, 16);
            this.lblId.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 68;
            this.label2.Text = "序号：";
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(209, 8);
            this.DtpbeginDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(167, 23);
            this.DtpbeginDate.TabIndex = 12;
            this.DtpbeginDate.TabStop = false;
            this.DtpbeginDate.Value = new System.DateTime(2004, 8, 13, 12, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(169, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "日期：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtStool);
            this.groupBox3.Controls.Add(this.txtPee);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(352, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 48);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出量(毫升)";
            // 
            // txtStool
            // 
            this.txtStool.Location = new System.Drawing.Point(208, 16);
            this.txtStool.MaxLength = 14;
            this.txtStool.Name = "txtStool";
            this.txtStool.Size = new System.Drawing.Size(120, 21);
            this.txtStool.TabIndex = 9;
            this.txtStool.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // txtPee
            // 
            this.txtPee.Location = new System.Drawing.Point(40, 16);
            this.txtPee.Name = "txtPee";
            this.txtPee.Size = new System.Drawing.Size(128, 21);
            this.txtPee.TabIndex = 8;
            this.txtPee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 16);
            this.label17.TabIndex = 81;
            this.label17.Text = "小便";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(176, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 16);
            this.label16.TabIndex = 79;
            this.label16.Text = "其他";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.bt新建);
            this.panel2.Controls.Add(this.btSaveModel);
            this.panel2.Controls.Add(this.btOpenModel);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.bt保存);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnCheck);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 645);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 56);
            this.panel2.TabIndex = 12;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDel.ImageIndex = 0;
            this.btnDel.Location = new System.Drawing.Point(448, 16);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(64, 24);
            this.btnDel.TabIndex = 69;
            this.btnDel.Text = "删除(&D)";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(520, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 24);
            this.btnRefresh.TabIndex = 66;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // bt新建
            // 
            this.bt新建.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt新建.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt新建.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt新建.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt新建.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt新建.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt新建.ImageIndex = 0;
            this.bt新建.Location = new System.Drawing.Point(112, 16);
            this.bt新建.Name = "bt新建";
            this.bt新建.Size = new System.Drawing.Size(64, 24);
            this.bt新建.TabIndex = 65;
            this.bt新建.Text = "新建(&N)";
            this.bt新建.UseVisualStyleBackColor = false;
            this.bt新建.Click += new System.EventHandler(this.bt新建_Click);
            // 
            // btSaveModel
            // 
            this.btSaveModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveModel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btSaveModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSaveModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btSaveModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSaveModel.ImageIndex = 9;
            this.btSaveModel.Location = new System.Drawing.Point(280, 16);
            this.btSaveModel.Name = "btSaveModel";
            this.btSaveModel.Size = new System.Drawing.Size(88, 24);
            this.btSaveModel.TabIndex = 64;
            this.btSaveModel.Text = "保存模板(&M)";
            this.btSaveModel.UseVisualStyleBackColor = false;
            this.btSaveModel.Click += new System.EventHandler(this.btSaveModel_Click);
            // 
            // btOpenModel
            // 
            this.btOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenModel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenModel.ImageIndex = 1;
            this.btOpenModel.Location = new System.Drawing.Point(184, 16);
            this.btOpenModel.Name = "btOpenModel";
            this.btOpenModel.Size = new System.Drawing.Size(88, 24);
            this.btOpenModel.TabIndex = 63;
            this.btOpenModel.Text = "打开模板(&O)";
            this.btOpenModel.UseVisualStyleBackColor = false;
            this.btOpenModel.Click += new System.EventHandler(this.btOpenModel_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(664, 16);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 61;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.Location = new System.Drawing.Point(592, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(64, 24);
            this.btnPrint.TabIndex = 60;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // bt保存
            // 
            this.bt保存.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt保存.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt保存.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt保存.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt保存.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt保存.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt保存.ImageIndex = 0;
            this.bt保存.Location = new System.Drawing.Point(376, 16);
            this.bt保存.Name = "bt保存";
            this.bt保存.Size = new System.Drawing.Size(64, 24);
            this.bt保存.TabIndex = 13;
            this.bt保存.Text = "保存(&S)";
            this.bt保存.UseVisualStyleBackColor = false;
            this.bt保存.Click += new System.EventHandler(this.bt保存_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(104, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(632, 40);
            this.button3.TabIndex = 62;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCheck.Enabled = false;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheck.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheck.ImageIndex = 0;
            this.btnCheck.Location = new System.Drawing.Point(32, 16);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(64, 24);
            this.btnCheck.TabIndex = 67;
            this.btnCheck.Text = "审核(&K)";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox4);
            this.panel6.Controls.Add(this.myDataGrid2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(160, 701);
            this.panel6.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.txtInpatNo);
            this.groupBox4.Controls.Add(this.btnSeek);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 640);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 61);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "住院号查询";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBox1.Location = new System.Drawing.Point(4, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 20);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtInpatNo
            // 
            this.txtInpatNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInpatNo.Location = new System.Drawing.Point(4, 13);
            this.txtInpatNo.Name = "txtInpatNo";
            this.txtInpatNo.Size = new System.Drawing.Size(96, 21);
            this.txtInpatNo.TabIndex = 0;
            this.txtInpatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInpatNo_KeyPress);
            // 
            // btnSeek
            // 
            this.btnSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeek.BackColor = System.Drawing.SystemColors.Control;
            this.btnSeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeek.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeek.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSeek.Location = new System.Drawing.Point(104, 23);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(48, 24);
            this.btnSeek.TabIndex = 56;
            this.btnSeek.Text = "查询";
            this.btnSeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Black;
            this.myDataGrid2.CaptionText = "病人信息";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size(160, 640);
            this.myDataGrid2.TabIndex = 25;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(160, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 701);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // frmWZHZHLJL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(904, 701);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Name = "frmWZHZHLJL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "危重患者护理记录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYBHZ_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmYBHZ_Load(object sender, System.EventArgs e)
        {
            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            this.btnCheck.Enabled = false;

            //查出本科室的病人信息
            string sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_Bed " +
                "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY dbo.Fun_GetBedToOrder( (case when left( bed_no,1)='+' then '999'+ bed_no else  bed_no end) ),Baby_ID";
            string[] GrdMappingName1 ={ "床号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
            int[] GrdWidth1 ={ 6, 12, 0, 0, 0, 0 };
            int[] Alignment1 ={ 1, 0, 0, 0, 0, 0 };
            myFunc.InitGridSQL(sSql, GrdMappingName1, GrdWidth1, Alignment1, this.myDataGrid2);
            myFunc.SelectBin(true, this.myDataGrid2, 2, 3, 4, 5);

            myDataGrid2_CurrentCellChanged(null, null);
        }

        public void Show_Date(Guid v_pat_id, long v_baby_id)
        {
            try
            {
                DataTable binTb = new DataTable();
                string book_user_name = "";
                //				string check_user_name="";
                string sSql = "select * from zy_wzhzhljl where inpatient_id='" + v_pat_id + "' and baby_id=" + v_baby_id + " order by book_date,id";
                DataTable myTb = new DataTable();

                rtbShow.Text = "";
                pat_id = v_pat_id;
                baby_id = v_baby_id;

                binTb = GetPatInfo(pat_id, baby_id);
                if (binTb == null || binTb.Rows.Count == 0)
                {
                    MessageBox.Show(this, "没有病人信息，请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lblName.Text = binTb.Rows[0]["name"].ToString();
                lblDept.Text = binTb.Rows[0]["cur_dept_name"].ToString();
                lblWard.Text = binTb.Rows[0]["ward_name"].ToString();
                lblBed.Text = binTb.Rows[0]["bed_no"].ToString();
                lblZyh.Text = binTb.Rows[0]["inpatient_no"].ToString();

                myTb = InstanceForm.BDatabase.GetDataTable(sSql);

                if (myTb == null || myTb.Rows.Count == 0) return;

                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    book_user_name = GetUserName(myTb.Rows[i]["book_user"].ToString() == null ? 0 : Convert.ToInt32(myTb.Rows[i]["book_user"].ToString()));
                    //					check_user_name=GetUserName(myTb.Rows[i]["check_user"].ToString()==null || myTb.Rows[i]["check_user"].ToString().Trim()==""?0:Convert.ToInt32(myTb.Rows[i]["check_user"].ToString()));
                    rtbShow.Text += "【 " + myTb.Rows[i]["id"].ToString() + " 】";
                    rtbShow.Text += myTb.Rows[i]["book_date"].ToString() + "\n";
                    rtbShow.Text += "[体温]：" + myTb.Rows[i]["tw"].ToString() + " ℃" + " " +
                                    "[脉搏]：" + myTb.Rows[i]["mb"].ToString() + " 次/分" + " " +
                                    "[呼吸]：" + myTb.Rows[i]["hx"].ToString() + " 次/分" + " " +
                                    "[血压]：" + myTb.Rows[i]["xy"].ToString() + " mmHg" + "\n";
                    rtbShow.Text += "[入量项目]：" + myTb.Rows[i]["in_item"].ToString() + " [实入量]：" + myTb.Rows[i]["in_item_quantity"].ToString() + " 毫升" + "\n";
                    rtbShow.Text += "[小便]：" + myTb.Rows[i]["out_pee"].ToString() + " 毫升 [其他]：" + myTb.Rows[i]["out_stool"].ToString() + "\n";
                    rtbShow.Text += "[病情及处理]：\n";
                    rtbShow.Text += "  " + myTb.Rows[i]["book_text"].ToString().Trim() + "\n";
                    rtbShow.Text += "                                                                    " +
                        book_user_name + "\n";
                }

                rtbShow.Focus();
                rtbShow.Select(rtbShow.TextLength, 0);
                rtbShow.ScrollToCaret();
            }
            catch (Exception err)
            {
                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt新建_Click(object sender, System.EventArgs e)
        {
            this.isNew = true;
            this.btnCheck.Enabled = false;
            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.rtbBook.ForeColor = Color.Black;
            this.rtbBook.Text = "";
            this.lblId.Text = "";
            this.txtTW.Text = "";
            this.txtMB.Text = "";
            this.txtXY.Text = "";
            this.txtHX.Text = "";
            this.txtItem.Text = "";
            this.txtInQuantity.Text = "";
            this.txtStool.Text = "";
            this.txtPee.Text = "";
            this.txtTW.Focus();
        }

        private void bt保存_Click(object sender, System.EventArgs e)
        {

            try
            {
                DataTable myTb = new DataTable();

                if (pat_id == null || pat_id == Guid.Empty)
                {
                    MessageBox.Show(this, "请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //				if (this.rtbBook.Text.Trim()=="") return;

                if (this.isNew)
                {
                    strSql = @"insert into zy_wzhzhljl(id,inpatient_id,baby_id,dept_id,book_date,book_text,tw,mb,hx,xy,in_item,in_item_quantity,out_stool,out_pee,book_user,jgbm)" +
                        @" values('" + PubStaticFun.NewGuid() + "','" + pat_id + "'," + baby_id + "," + ClassStatic.Current_DeptID + ",'" + DtpbeginDate.Value + "','" + rtbBook.Text + "'," +
                        @"'" + txtTW.Text + "','" + txtMB.Text + "','" + txtHX.Text + "','" + txtXY.Text + "','" + txtItem.Text + "','" + txtInQuantity.Text + "'," +
                        @"'" + txtStool.Text + "','" + txtPee.Text + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";

                    InstanceForm.BDatabase.DoCommand(strSql);
                }
                else
                {
                    if (lblId.Text.Trim() == "") return;

                    strSql = "select * from zy_wzhzhljl where id='" + lblId.Text + "' and  book_user=" + InstanceForm.BCurrentUser.EmployeeId + " and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                    myTb = InstanceForm.BDatabase.GetDataTable(strSql);

                    //Add By Tany 2005-07-04
                    //护士长和组长护士可以操作
                    if (myFunc.IsHSZ(InstanceForm.BCurrentUser.EmployeeId) == false
                        && myFunc.IsZZHS(InstanceForm.BCurrentUser.EmployeeId) == false)
                    {
                        if (myTb == null || myTb.Rows.Count == 0)
                        {
                            MessageBox.Show(this, "对不起，不是你录入的记录不能修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    strSql = @"update zy_wzhzhljl set book_text='" + rtbBook.Text + "',modify_user=" + InstanceForm.BCurrentUser.EmployeeId + "," +
                        @"tw='" + txtTW.Text + "',mb='" + txtMB.Text + "',hx='" + txtHX.Text + "',xy='" + txtXY.Text + "'," +
                        @"in_item='" + txtItem.Text + "',in_item_quantity='" + txtInQuantity.Text + "',out_stool='" + txtStool.Text + "',out_pee='" + txtPee.Text + "'" +
                        @" where id='" + lblId.Text + "' and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                    InstanceForm.BDatabase.DoCommand(strSql);
                }

                MessageBox.Show(this, "保存成功！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show_Date(pat_id, baby_id);
                bt新建_Click(sender, e);

            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "保存危重患者护理记录错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtbShow_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            try
            {
                Guid id;

                id = new Guid(e.LinkText);
                string sSql = "select * from zy_wzhzhljl where id='" + id + "' order by id";
                DataTable myTb = new DataTable();

                myTb = InstanceForm.BDatabase.GetDataTable(sSql);

                if (myTb == null || myTb.Rows.Count == 0) return;

                lblId.Text = myTb.Rows[0]["id"].ToString();
                DtpbeginDate.Value = Convert.ToDateTime(myTb.Rows[0]["book_date"].ToString());
                this.txtTW.Text = myTb.Rows[0]["tw"].ToString(); ;
                this.txtMB.Text = myTb.Rows[0]["mb"].ToString(); ;
                this.txtXY.Text = myTb.Rows[0]["xy"].ToString(); ;
                this.txtHX.Text = myTb.Rows[0]["hx"].ToString(); ;
                this.txtItem.Text = myTb.Rows[0]["in_item"].ToString(); ;
                this.txtInQuantity.Text = myTb.Rows[0]["in_item_quantity"].ToString(); ;
                this.txtStool.Text = myTb.Rows[0]["out_stool"].ToString(); ;
                this.txtPee.Text = myTb.Rows[0]["out_pee"].ToString(); ;
                rtbBook.Text = myTb.Rows[0]["book_text"].ToString();
                if (myTb.Rows[0]["check_user"].ToString().Trim() == "") btnCheck.Enabled = true;
                else btnCheck.Enabled = false;
                isNew = false;
            }
            catch (Exception err)
            {
                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string GetUserName(int UserId)
        {
            DataTable myTb = new DataTable();
            string UserName = "";
            string sSql;

            sSql = "select name from jc_employee_property where employee_id = " + UserId;
            myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb != null && myTb.Rows.Count > 0) UserName = myTb.Rows[0]["name"].ToString();

            return UserName;

        }

        private void btOpenModel_Click(object sender, System.EventArgs e)
        {
            DataRow myDr;
            string msgStr = "";
            frmSelBox fs = new frmSelBox();

            strSql = @"select id,name 名称,model_text 内容,py 拼音码,wb 五笔码,case model_type when 0 then '全院共用' when 1 then '病区使用' when 2 then '科室使用' " +
                    @"when 3 then '个人使用' end 类型 from ZY_HLJLMODEL where mng_type in (0,2) and " +
                @"((model_type=0) or (model_type=1 and ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                @" or (model_type=2 and dept_id=" + ClassStatic.Current_DeptID + ")" +
                @" or (model_type=3 and user_id=" + InstanceForm.BCurrentUser.EmployeeId + "))";
            fs.InitGrid(strSql);
            fs.ShowDialog();
            if (fs.DialogResult == DialogResult.OK)
            {
                myDr = fs.myDr;
                if (rtbBook.Text.Trim() != "")
                {
                    msgStr = MessageBox.Show(this, "是否覆盖现有的内容？\n\n（是：覆盖现有内容    否：追加到输入栏）", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).ToString();
                    switch (msgStr.ToUpper())
                    {
                        case "YES":
                            rtbBook.Text = "";
                            break;
                        case "CANCEL":
                            return;
                    }
                }
                rtbBook.Text += myDr["内容"].ToString();
            }
            fs.Dispose();
        }

        private void btSaveModel_Click(object sender, System.EventArgs e)
        {

            try
            {
                string ModelName = "";
                int mng_type = 0;
                int model_type = 0;
                string ward_id = "";
                long dept_id = -1;
                long user_id = -1;
                string msgStr = "";
                DataTable myTb = new DataTable();
                frmHLModelSave fh = new frmHLModelSave();

                if (rtbBook.Text.Trim() == "") return;

                fh.ShowDialog();
                if (fh.DialogResult == DialogResult.OK)
                {
                    ModelName = fh.ModelName;
                    mng_type = fh.mng_type;
                    model_type = fh.model_type;
                    fh.Dispose();
                }
                else
                {
                    fh.Dispose();
                    return;
                }

                strSql = "select id,name from ZY_HLJLMODEL where name='" + ModelName + "' and mng_type in (0,2) and " +
                    "((model_type=0) or (model_type=1 and ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                    " or (model_type=2 and dept_id=" + ClassStatic.Current_DeptID + ")" +
                    " or (model_type=3 and user_id=" + InstanceForm.BCurrentUser.EmployeeId + "))";
                myTb = InstanceForm.BDatabase.GetDataTable(strSql);

                if (myTb != null && myTb.Rows.Count != 0)
                {
                    msgStr = MessageBox.Show(this, "模版名已经存在，是否替换现有的模版？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (msgStr.ToUpper() == "YES")
                    {
                        strSql = "delete from ZY_HLJLMODEL where id=" + Convert.ToInt32(myTb.Rows[0]["id"].ToString());
                        InstanceForm.BDatabase.DoCommand(strSql);
                    }
                    else
                    {
                        return;
                    }
                }

                switch (model_type)
                {
                    case 1:
                        ward_id = InstanceForm.BCurrentDept.WardId;
                        break;
                    case 2:
                        dept_id = Convert.ToInt64(ClassStatic.Current_DeptID);
                        break;
                    case 3:
                        user_id = InstanceForm.BCurrentUser.EmployeeId;
                        break;
                }

                strSql = @"insert into ZY_HLJLMODEL(name,py,wb,model_text,model_type,mng_type,ward_id,dept_id,user_id,memo) " +
                    @"values('" + ModelName + "','" + PubStaticFun.GetPYWBM(ModelName, 0) + "','" + PubStaticFun.GetPYWBM(ModelName, 1) + "','" + rtbBook.Text + "'," +
                    model_type + @"," + mng_type + ",'" + ward_id + "'," + dept_id + "," + user_id + ",' ')";
                InstanceForm.BDatabase.DoCommand(strSql);

                MessageBox.Show(this, "保存成功！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            Show_Date(pat_id, baby_id);
        }

        private void btnCheck_Click(object sender, System.EventArgs e)
        {
            //			if (isNew)
            //			{
            //				return;
            //			}
            //			else
            //			{
            //				if (lblId.Text.Trim()=="") return;
            //
            //				strSql="update zy_wzhzhljl set check_user="+InstanceForm.BCurrentUser.EmployeeId+
            //					" where id="+lblId.Text+" and inpatient_id="+pat_id+" and baby_id="+baby_id;
            //
            //				InstanceForm.BDatabase.DoCommand(strSql);
            //			}
            //			MessageBox.Show(this,"审核成功！","审核",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //			Show_Date(pat_id,baby_id);
            //			btnCheck.Enabled=false;
        }

        private DataTable GetPatInfo(Guid inpatient_id, decimal baby_id)
        {
            //获取病人的基本信息
            string sqlStr = "";
            DataTable dbTb = new DataTable();
            sqlStr = "select a.name,a.cur_dept_name,a.bed_no,a.inpatient_no,b.ward_name from vi_zy_vINPATIENT_ALL a,jc_WARD b where a.ward_id=b.ward_id and a.inpatient_id='" + inpatient_id + "' and a.baby_id=" + baby_id;
            dbTb = InstanceForm.BDatabase.GetDataTable(sqlStr);
            return dbTb;
        }

        private void txtBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) this.SelectNextControl((Control)sender, true, false, true, true);
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sSql;
                DataSet ds = new DataSet();
                DataTable prTb = new DataTable();

                sSql = "exec SP_ZYHS_SELWZHLJL '" + pat_id + "'," + baby_id + "," + InstanceForm.BCurrentUser.EmployeeId;
                prTb = InstanceForm.BDatabase.GetDataTable(sSql);
                prTb.TableName = "tabWzhljl";
                ds.Tables.Add(prTb);

                if (prTb == null || prTb.Rows.Count == 0) return;

                FrmReportView frmRptView = null;
                ParameterEx[] _parameters = new ParameterEx[7];

                _parameters[0].Text = "医院名称";
                _parameters[0].Value = (new SystemCfg(0002)).Config;
                _parameters[1].Text = "病人姓名";
                _parameters[1].Value = lblName.Text;
                _parameters[2].Text = "科室";
                _parameters[2].Value = lblDept.Text;
                _parameters[3].Text = "病区";
                _parameters[3].Value = lblWard.Text;
                _parameters[4].Text = "床号";
                _parameters[4].Value = lblBed.Text;
                _parameters[5].Text = "住院号";
                _parameters[5].Value = lblZyh.Text;
                _parameters[6].Text = "打印者";
                _parameters[6].Value = InstanceForm.BCurrentUser.Name;

                frmRptView = new FrmReportView(ds, Constant.ApplicationDirectory + "\\report\\ZYHS_危重病人护理记录.rpt", _parameters);
                frmRptView.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            if (tb.Rows.Count == 0)
            {
                return;
            }
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);
            ClassStatic.Current_BinID = new Guid(this.myDataGrid2[nrow, 2].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(this.myDataGrid2[nrow, 3]);
            ClassStatic.Current_DeptID = Convert.ToInt64(this.myDataGrid2[nrow, 4]);
            ClassStatic.Current_isMY = Convert.ToInt16(this.myDataGrid2[nrow, 5]);

            Show_Date(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
            bt新建_Click(sender, e);
        }

        private void btnSeek_Click(object sender, System.EventArgs e)
        {
            if (txtInpatNo.Text.Trim() == "")
                txtInpatNo.Text = "0";

            string sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_All " +
                "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and inpatient_no='" + txtInpatNo.Text.Trim() + "'" +
                "  order by baby_id";
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                MessageBox.Show("没有找到该病人信息，请核对住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            comboBox1.Items.Clear();

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                ClassStatic.MYTS_Name[i] = myTb.Rows[i]["姓名"].ToString().Trim();
                ClassStatic.MYTS_BabyID[i] = myTb.Rows[i]["BABY_ID"].ToString().Trim();
                ClassStatic.MYTS_BinID[i] = new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString().Trim());
                comboBox1.Items.Add(ClassStatic.MYTS_Name[i]);
                if (Convert.ToInt64(ClassStatic.MYTS_BabyID[i]) == ClassStatic.Current_BabyID)
                {
                    comboBox1.Text = ClassStatic.MYTS_Name[i];
                }
            }

            comboBox1.SelectedIndex = 0;

            ClassStatic.Current_BinID = new Guid(myTb.Rows[0]["INPATIENT_ID"].ToString().Trim());
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);
            ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[0]["DEPT_ID"].ToString().Trim());
            ClassStatic.Current_isMY = Convert.ToInt32(myTb.Rows[0]["isMY"].ToString().Trim());

            myDataGrid2.UnSelect(myDataGrid2.CurrentCell.RowNumber);

            Show_Date(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ClassStatic.Current_BinID = ClassStatic.MYTS_BinID[comboBox1.SelectedIndex];
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);

            Show_Date(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
        }

        private void txtInpatNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSeek.Focus();

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable myTb = new DataTable();

                if (pat_id == null || pat_id == Guid.Empty)
                {
                    MessageBox.Show(this, "请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lblId.Text.Trim() == "") return;

                strSql = "select * from zy_wzhzhljl where id='" + lblId.Text + "' and  book_user=" + InstanceForm.BCurrentUser.EmployeeId + " and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                myTb = InstanceForm.BDatabase.GetDataTable(strSql);

                //Add By Tany 2005-07-04
                //护士长和组长护士可以操作
                if (myFunc.IsHSZ(InstanceForm.BCurrentUser.EmployeeId) == false
                    && myFunc.IsZZHS(InstanceForm.BCurrentUser.EmployeeId) == false)
                {
                    if (myTb == null || myTb.Rows.Count == 0)
                    {
                        MessageBox.Show(this, "对不起，不是你录入的记录不能修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (MessageBox.Show(this, "记录删除将不能恢复，确认删除这条记录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                strSql = @"delete from zy_wzhzhljl where id='" + lblId.Text + "' and inpatient_id='" + pat_id + "' and baby_id=" + baby_id;

                InstanceForm.BDatabase.DoCommand(strSql);

                //写日志 Add By Tany 2005-06-21
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "删除危重护理记录", "将 " + pat_id + " 病人的 " + lblId.Text + " 号护理记录删除", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                MessageBox.Show(this, "删除成功！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show_Date(pat_id, baby_id);
                bt新建_Click(sender, e);
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "删除危重患者护理记录错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
