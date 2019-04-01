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

namespace ts_zyhs_brxx
{
    /// <summary>
    /// 病人信息查询 的摘要说明。
    /// </summary>
    public class frmBRXX : System.Windows.Forms.Form
    {
        //自定义变量
        private User _User;
        private Department _Dept;
        private BaseFunc myFunc;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbSFZ;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbDWMC;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lbMZYS;
        private System.Windows.Forms.Label lbMZZD;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btShow;
        private 病人信息.PatientInfo patientInfo1;
        private System.Windows.Forms.Label lbZDRQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbLXFS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbGX;
        private System.Windows.Forms.Label lbLXR;
        private System.Windows.Forms.Label lbDH;
        private DataGridEx myDataGrid1;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbDbr;
        private TextBoxEx txtInpatNo;
        private System.Windows.Forms.Button btnSeek;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private IContainer components;

        public frmBRXX(string _formText, long _curDeptId, long _curUserId)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            _Dept = new Department(_curDeptId, InstanceForm.BDatabase);
            _User = new User(_curUserId, InstanceForm.BDatabase);

            myFunc = new BaseFunc();
        }

        public frmBRXX(string _formText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;
            _Dept = null;
            _User = null;
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.patientInfo1 = new 病人信息.PatientInfo();
            this.lbLXFS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMZZD = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbMZYS = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lbDWMC = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbZDRQ = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbSFZ = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbLXR = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbDH = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbDbr = new System.Windows.Forms.Label();
            this.lbGX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btShow = new System.Windows.Forms.Button();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtInpatNo = new TrasenClasses.GeneralControls.TextBoxEx(this.components);
            this.btnSeek = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.patientInfo1);
            this.groupBox2.Controls.Add(this.lbLXFS);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbMZZD);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.lbMZYS);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.lbDWMC);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lbZDRQ);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lbSFZ);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbLXR);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lbDH);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lbDbr);
            this.groupBox2.Controls.Add(this.lbGX);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(2, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(808, 140);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病人资料";
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo1.Location = new System.Drawing.Point(4, 12);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(456, 124);
            this.patientInfo1.TabIndex = 98;
            // 
            // lbLXFS
            // 
            this.lbLXFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLXFS.BackColor = System.Drawing.SystemColors.Control;
            this.lbLXFS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbLXFS.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLXFS.Location = new System.Drawing.Point(562, 116);
            this.lbLXFS.Name = "lbLXFS";
            this.lbLXFS.Size = new System.Drawing.Size(237, 16);
            this.lbLXFS.TabIndex = 100;
            this.lbLXFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(462, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 99;
            this.label1.Text = "联系人";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMZZD
            // 
            this.lbMZZD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMZZD.BackColor = System.Drawing.SystemColors.Control;
            this.lbMZZD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMZZD.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbMZZD.Location = new System.Drawing.Point(522, 56);
            this.lbMZZD.Name = "lbMZZD";
            this.lbMZZD.Size = new System.Drawing.Size(277, 16);
            this.lbMZZD.TabIndex = 97;
            this.lbMZZD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label25.Location = new System.Drawing.Point(462, 56);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 96;
            this.label25.Text = "门诊诊断";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMZYS
            // 
            this.lbMZYS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMZYS.BackColor = System.Drawing.SystemColors.Control;
            this.lbMZYS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMZYS.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbMZYS.Location = new System.Drawing.Point(713, 36);
            this.lbMZYS.Name = "lbMZYS";
            this.lbMZYS.Size = new System.Drawing.Size(86, 16);
            this.lbMZYS.TabIndex = 95;
            this.lbMZYS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label24.Location = new System.Drawing.Point(654, 36);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 16);
            this.label24.TabIndex = 94;
            this.label24.Text = "门诊医生";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDWMC
            // 
            this.lbDWMC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDWMC.BackColor = System.Drawing.SystemColors.Control;
            this.lbDWMC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDWMC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDWMC.Location = new System.Drawing.Point(522, 76);
            this.lbDWMC.Name = "lbDWMC";
            this.lbDWMC.Size = new System.Drawing.Size(277, 16);
            this.lbDWMC.TabIndex = 93;
            this.lbDWMC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(462, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 92;
            this.label17.Text = "单位名称";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbZDRQ
            // 
            this.lbZDRQ.BackColor = System.Drawing.SystemColors.Control;
            this.lbZDRQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbZDRQ.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbZDRQ.Location = new System.Drawing.Point(522, 36);
            this.lbZDRQ.Name = "lbZDRQ";
            this.lbZDRQ.Size = new System.Drawing.Size(128, 16);
            this.lbZDRQ.TabIndex = 91;
            this.lbZDRQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label23.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label23.Location = new System.Drawing.Point(462, 36);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 16);
            this.label23.TabIndex = 90;
            this.label23.Text = "诊断日期";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSFZ
            // 
            this.lbSFZ.BackColor = System.Drawing.SystemColors.Control;
            this.lbSFZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSFZ.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSFZ.Location = new System.Drawing.Point(522, 16);
            this.lbSFZ.Name = "lbSFZ";
            this.lbSFZ.Size = new System.Drawing.Size(128, 16);
            this.lbSFZ.TabIndex = 89;
            this.lbSFZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label20.Location = new System.Drawing.Point(462, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 16);
            this.label20.TabIndex = 88;
            this.label20.Text = "身份证";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(462, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 103;
            this.label4.Text = "联系人电话地址";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLXR
            // 
            this.lbLXR.BackColor = System.Drawing.SystemColors.Control;
            this.lbLXR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbLXR.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLXR.Location = new System.Drawing.Point(522, 96);
            this.lbLXR.Name = "lbLXR";
            this.lbLXR.Size = new System.Drawing.Size(56, 16);
            this.lbLXR.TabIndex = 104;
            this.lbLXR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(654, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 105;
            this.label6.Text = "电话";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDH
            // 
            this.lbDH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDH.BackColor = System.Drawing.SystemColors.Control;
            this.lbDH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDH.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDH.Location = new System.Drawing.Point(689, 16);
            this.lbDH.Name = "lbDH";
            this.lbDH.Size = new System.Drawing.Size(110, 16);
            this.lbDH.TabIndex = 106;
            this.lbDH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(670, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 107;
            this.label5.Text = "担保人";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDbr
            // 
            this.lbDbr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDbr.BackColor = System.Drawing.SystemColors.Control;
            this.lbDbr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDbr.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDbr.Location = new System.Drawing.Point(718, 96);
            this.lbDbr.Name = "lbDbr";
            this.lbDbr.Size = new System.Drawing.Size(81, 16);
            this.lbDbr.TabIndex = 108;
            this.lbDbr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGX
            // 
            this.lbGX.BackColor = System.Drawing.SystemColors.Control;
            this.lbGX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbGX.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbGX.Location = new System.Drawing.Point(622, 96);
            this.lbGX.Name = "lbGX";
            this.lbGX.Size = new System.Drawing.Size(44, 16);
            this.lbGX.TabIndex = 102;
            this.lbGX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(582, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 101;
            this.label2.Text = "关系";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(698, 16);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(80, 32);
            this.btCancel.TabIndex = 54;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btShow
            // 
            this.btShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btShow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btShow.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btShow.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btShow.ImageIndex = 0;
            this.btShow.Location = new System.Drawing.Point(610, 16);
            this.btShow.Name = "btShow";
            this.btShow.Size = new System.Drawing.Size(80, 32);
            this.btShow.TabIndex = 53;
            this.btShow.Text = "刷新(&R)";
            this.btShow.UseVisualStyleBackColor = false;
            this.btShow.Click += new System.EventHandler(this.btShow_Click);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "转床情况";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.RowHeadersVisible = false;
            this.myDataGrid1.Size = new System.Drawing.Size(802, 259);
            this.myDataGrid1.TabIndex = 58;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid2.CaptionText = "转科情况";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 259);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeadersVisible = false;
            this.myDataGrid2.Size = new System.Drawing.Size(802, 156);
            this.myDataGrid2.TabIndex = 59;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBox1.Location = new System.Drawing.Point(424, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(122, 22);
            this.comboBox1.TabIndex = 58;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtInpatNo
            // 
            this.txtInpatNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtInpatNo.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.txtInpatNo.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.txtInpatNo.EnterBackColor = System.Drawing.SystemColors.Window;
            this.txtInpatNo.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInpatNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInpatNo.Location = new System.Drawing.Point(92, 20);
            this.txtInpatNo.Name = "txtInpatNo";
            this.txtInpatNo.NextControl = null;
            this.txtInpatNo.PreviousControl = null;
            this.txtInpatNo.Size = new System.Drawing.Size(136, 23);
            this.txtInpatNo.TabIndex = 0;
            this.txtInpatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInpatNo_KeyPress);
            // 
            // btnSeek
            // 
            this.btnSeek.BackColor = System.Drawing.SystemColors.Control;
            this.btnSeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeek.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeek.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSeek.Location = new System.Drawing.Point(240, 16);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(80, 32);
            this.btnSeek.TabIndex = 56;
            this.btnSeek.Text = "查询(&S)";
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Controls.Add(this.txtInpatNo);
            this.panel1.Controls.Add(this.btnSeek);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 557);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 56);
            this.panel1.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(354, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 60;
            this.label7.Text = "病人姓名";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label3.Location = new System.Drawing.Point(10, 24);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(77, 14);
            this.Label3.TabIndex = 59;
            this.Label3.Text = "病人住院号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 142);
            this.panel2.TabIndex = 63;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.myDataGrid1);
            this.panel3.Controls.Add(this.myDataGrid2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(802, 415);
            this.panel3.TabIndex = 64;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 256);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(802, 3);
            this.splitter1.TabIndex = 60;
            this.splitter1.TabStop = false;
            // 
            // frmBRXX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(802, 613);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmBRXX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "病人信息查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPatientInfo_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmPatientInfo_Load(object sender, System.EventArgs e)
        {
            myFunc.InidNamecomboBox(this.comboBox1);
            btShow_Click(sender, e);
        }

        private void ShowData()
        {
            string sSql;
            //转床信息
            sSql = @"Select b.ward_name 病区,dbo.FUN_ZY_SEEKDEPTNAME(a.dept_id) 科室, d.bed_no 床号," +
                "       a.assign_date 开始时间,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.assign_user) as 开始操作员," +
                "       a.stop_date 结束时间,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.stop_user) as 结束操作员," +
                "       case stop_flag when 0 then '转床' " +
                "	                     when 1 then '转科' " +
                "	                     when 2 then '出院' " +
                "	                     when 3 then '母婴同室数量变化' " +
                "	                     when 4 then '包床状态变化' " +
                "	                     when 5 then '主任医生改变' " +
                "	                     when 6 then '管床医生改变' " +
                "	                     when 7 then '负责护士改变' " +
                "	                     when 8 then '取消分配床位' " +
                "	                     when 9 then '出院召回' " +
                "	                     else ''end as 结束原因, " +
                "       case a.isbf when 0 then '' else '√' end as 包床否," +
                "       a.ismyts as 婴儿数量" +
                "  from zy_bed_assign a " +
                "       left join jc_ward b on a.ward_id=b.ward_id  " +
                "       left join zy_beddiction d on a.bed_id=d.bed_id" +
                " where a.inpatient_id='" + ClassStatic.Current_BinID + "'" +
                "       and a.baby_id=" + ClassStatic.Current_BabyID +
                " order by a.assign_date ";
            myFunc.ShowGrid(0, sSql, this.myDataGrid1);


            //转科信息
            sSql = "select Transfer_date 转科时间,dbo.FUN_ZY_SEEKDEPTNAME(d.s_dept_id) 源科室,dbo.FUN_ZY_SEEKDEPTNAME(d.d_dept_id) 目标科室,book_date 登记时间,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.operator) 操作员 " +
                "  from ZY_TRANSFER_DEPT d " +
                "	where inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and finish_bit=1";
            myFunc.ShowGrid(0, sSql, this.myDataGrid2);
        }


        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            myFunc.NamecomboBox_SelectedIndexChanged(this.comboBox1);
            btShow_Click(sender, e);
        }

        private void btShow_Click(object sender, System.EventArgs e)
        {
            string sSql = "";

            //显示病人基本信息
            this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);

            if (ClassStatic.Current_BabyID == 0)
            {
                sSql = @"select a.Social_no,a.diagnose_date,c.name,a.clinic_diagnosis,a.unit_name,a.home_tel,a.relation_name,a.relation_tel,a.relation,a.relation_street,a.WARRANTOR dbr,a.WARRANTAMOUNT as dbje" +
                    "  from vi_zy_vinpatient a LEFT JOIN jc_employee_property c ON a.clinic_doc=c.employee_id " +//LEFT JOIN jc_employee_property d ON b.WARRANTOR=d.employee_id"+
                    " where a.inpatient_id='" + ClassStatic.Current_BinID + "'";

                DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (myTempTb.Rows.Count != 0)
                {
                    this.lbSFZ.Text = myTempTb.Rows[0]["Social_no"].ToString().Trim();
                    this.lbZDRQ.Text = myTempTb.Rows[0]["diagnose_date"].ToString().Trim();
                    this.lbMZYS.Text = myTempTb.Rows[0]["name"].ToString().Trim();
                    this.lbMZZD.Text = myTempTb.Rows[0]["clinic_diagnosis"].ToString().Trim();
                    this.lbDWMC.Text = myTempTb.Rows[0]["unit_name"].ToString().Trim();
                    this.lbGX.Text = myTempTb.Rows[0]["relation"].ToString().Trim();
                    this.lbLXFS.Text = myTempTb.Rows[0]["relation_tel"].ToString().Trim() + " " + myTempTb.Rows[0]["relation_street"].ToString().Trim();
                    this.lbLXR.Text = myTempTb.Rows[0]["relation_name"].ToString().Trim();
                    this.lbDH.Text = myTempTb.Rows[0]["home_tel"].ToString().Trim();
                    this.lbDbr.Text = myTempTb.Rows[0]["dbr"].ToString().Trim() + "(担保金额：" + Convert.ToString(myTempTb.Rows[0]["DBJE"]).Trim() + ")";
                }
                else
                {
                    this.lbSFZ.Text = "";
                    this.lbZDRQ.Text = "";
                    this.lbMZYS.Text = "";
                    this.lbMZZD.Text = "";
                    this.lbDWMC.Text = "";
                    this.lbLXFS.Text = "";
                    this.lbGX.Text = "";
                    this.lbLXR.Text = "";
                    this.lbDH.Text = "";
                    this.lbDbr.Text = "";
                }
            }

            this.ShowData();

            string[] GrdMappingName1 ={ "病区", "科室", "床号", "开始时间", "开始操作员", "结束时间", "结束操作员", "结束原因", "包床否", "婴儿数量", "主治医生", "管床医生", "负责护士" };
            int[] GrdWidth1 ={ 8, 20, 4, 19, 10, 19, 10, 16, 6, 8, 8, 8, 8 };
            int[] Alignment1 ={ 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);

            string[] GrdMappingName2 ={ "转科时间", "源科室", "目标科室", "登记时间", "操作员" };
            int[] GrdWidth2 ={ 19, 20, 20, 19, 8 };
            int[] Alignment2 ={ 0, 0, 0, 0, 0 };
            int[] ReadOnly2 ={ 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName2, GrdWidth2, Alignment2, ReadOnly2, this.myDataGrid2);

        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }

        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid2);
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

        private void btnSeek_Click(object sender, System.EventArgs e)
        {
            if (txtInpatNo.Text.Trim() == "")
                txtInpatNo.Text = "0";

            string sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_ZY_vInpatient_All " +
                "  WHERE inpatient_no='" + txtInpatNo.Text.Trim() + "'";
            if (_Dept != null)
            {
                sSql += " and WARD_ID= '" + _Dept.WardId + "'";
            }

            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                MessageBox.Show("没有找到该病人信息，请核对住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClassStatic.Current_BinID = new Guid(myTb.Rows[0]["INPATIENT_ID"].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(myTb.Rows[0]["Baby_ID"]);
            ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[0]["DEPT_ID"]);
            ClassStatic.Current_isMY = Convert.ToInt32(myTb.Rows[0]["isMY"]);

            frmPatientInfo_Load(sender, e);
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
