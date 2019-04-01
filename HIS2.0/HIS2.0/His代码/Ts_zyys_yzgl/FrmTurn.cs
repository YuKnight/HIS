using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using Ts_zyys_public;
using ts_zyhs_classes;

namespace Ts_zyys_yzgl
{
    /// <summary>
    /// 转科申请 的摘要说明。
    /// </summary>
    public class FrmTurn : System.Windows.Forms.Form
    {
        private DbQuery myQuery = new DbQuery();
        private BaseFunc myFunc = new BaseFunc();
        public User YS = null;
        public long YS_ID = 0;
        public long DeptID = 0;
        public string WardID = "";
        public Guid BinID = Guid.Empty;
        public bool outType = false; //是否完成了转科医嘱
        private int stopflag = 1;//是否停长期医嘱：0=不停、1=停
        private long Dept_Br = 0;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDiag;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBedNo;
        private System.Windows.Forms.Label lblZyh;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.ComboBox cmbWard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown numUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radBt2;
        private System.Windows.Forms.RadioButton radBt1;
        private System.Windows.Forms.CheckBox chk_hsz;
        private System.Windows.Forms.Label lbStop;
        private System.Windows.Forms.Label label11;
        private ComboBox cmbJgbm;
        private Label label12;
        private CheckBox chk_trantype;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmTurn()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_hsz = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_trantype = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbJgbm = new System.Windows.Forms.ComboBox();
            this.lbStop = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.radBt2 = new System.Windows.Forms.RadioButton();
            this.radBt1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.cmbWard = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numUD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDiag = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblWard = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBedNo = new System.Windows.Forms.Label();
            this.lblZyh = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk_hsz);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 333);
            this.panel1.TabIndex = 0;
            // 
            // chk_hsz
            // 
            this.chk_hsz.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_hsz.Location = new System.Drawing.Point(16, 233);
            this.chk_hsz.Name = "chk_hsz";
            this.chk_hsz.Size = new System.Drawing.Size(144, 24);
            this.chk_hsz.TabIndex = 27;
            this.chk_hsz.Text = "通知护士工作站";
            this.chk_hsz.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(345, 273);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(225, 273);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_trantype);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbJgbm);
            this.groupBox2.Controls.Add(this.lbStop);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.radBt2);
            this.groupBox2.Controls.Add(this.radBt1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.cmbDept);
            this.groupBox2.Controls.Add(this.cmbWard);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.numUD);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 147);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // chk_trantype
            // 
            this.chk_trantype.AutoSize = true;
            this.chk_trantype.Checked = true;
            this.chk_trantype.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_trantype.Location = new System.Drawing.Point(351, 118);
            this.chk_trantype.Name = "chk_trantype";
            this.chk_trantype.Size = new System.Drawing.Size(96, 16);
            this.chk_trantype.TabIndex = 43;
            this.chk_trantype.Text = "产生转科记录";
            this.chk_trantype.UseVisualStyleBackColor = true;
            this.chk_trantype.CheckedChanged += new System.EventHandler(this.chk_trantype_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(285, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 42;
            this.label12.Text = "院区";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbJgbm
            // 
            this.cmbJgbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJgbm.DropDownWidth = 140;
            this.cmbJgbm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbJgbm.Location = new System.Drawing.Point(72, 53);
            this.cmbJgbm.Name = "cmbJgbm";
            this.cmbJgbm.Size = new System.Drawing.Size(212, 22);
            this.cmbJgbm.TabIndex = 41;
            // 
            // lbStop
            // 
            this.lbStop.BackColor = System.Drawing.SystemColors.Window;
            this.lbStop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbStop.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStop.Location = new System.Drawing.Point(425, 12);
            this.lbStop.Name = "lbStop";
            this.lbStop.Size = new System.Drawing.Size(22, 22);
            this.lbStop.TabIndex = 40;
            this.lbStop.Text = "√";
            this.lbStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbStop.Click += new System.EventHandler(this.lbStop_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(345, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 39;
            this.label11.Text = "停长期医嘱";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radBt2
            // 
            this.radBt2.Checked = true;
            this.radBt2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBt2.Location = new System.Drawing.Point(348, 80);
            this.radBt2.Name = "radBt2";
            this.radBt2.Size = new System.Drawing.Size(64, 24);
            this.radBt2.TabIndex = 38;
            this.radBt2.TabStop = true;
            this.radBt2.Text = "修改值";
            // 
            // radBt1
            // 
            this.radBt1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radBt1.Location = new System.Drawing.Point(348, 57);
            this.radBt1.Name = "radBt1";
            this.radBt1.Size = new System.Drawing.Size(64, 24);
            this.radBt1.TabIndex = 37;
            this.radBt1.Text = "默认值";
            this.radBt1.CheckedChanged += new System.EventHandler(this.radBt1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(286, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "科";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(212, 23);
            this.dateTimePicker1.TabIndex = 28;
            // 
            // cmbDept
            // 
            this.cmbDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDept.Location = new System.Drawing.Point(72, 118);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(212, 22);
            this.cmbDept.TabIndex = 4;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // cmbWard
            // 
            this.cmbWard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbWard.Location = new System.Drawing.Point(72, 86);
            this.cmbWard.Name = "cmbWard";
            this.cmbWard.Size = new System.Drawing.Size(212, 22);
            this.cmbWard.TabIndex = 3;
            this.cmbWard.SelectedIndexChanged += new System.EventHandler(this.cmbWard_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(285, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "病区";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(15, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "转到：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 17;
            this.label9.Text = "转科时间：";
            // 
            // numUD
            // 
            this.numUD.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numUD.Location = new System.Drawing.Point(412, 80);
            this.numUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD.Name = "numUD";
            this.numUD.Size = new System.Drawing.Size(40, 24);
            this.numUD.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(342, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 14);
            this.label4.TabIndex = 34;
            this.label4.Text = "治疗末日执行次数：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDiag);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblWard);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblBedNo);
            this.groupBox1.Controls.Add(this.lblZyh);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblDiag
            // 
            this.lblDiag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiag.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDiag.Location = new System.Drawing.Point(239, 48);
            this.lblDiag.Name = "lblDiag";
            this.lblDiag.Size = new System.Drawing.Size(253, 23);
            this.lblDiag.TabIndex = 20;
            this.lblDiag.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(183, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "诊  断：";
            // 
            // lblWard
            // 
            this.lblWard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWard.Location = new System.Drawing.Point(48, 48);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(131, 23);
            this.lblWard.TabIndex = 18;
            this.lblWard.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(4, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "病室：";
            // 
            // lblBedNo
            // 
            this.lblBedNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBedNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBedNo.Location = new System.Drawing.Point(411, 16);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(81, 23);
            this.lblBedNo.TabIndex = 16;
            this.lblBedNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblZyh
            // 
            this.lblZyh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZyh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZyh.Location = new System.Drawing.Point(239, 16);
            this.lblZyh.Name = "lblZyh";
            this.lblZyh.Size = new System.Drawing.Size(128, 23);
            this.lblZyh.TabIndex = 15;
            this.lblZyh.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(48, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(131, 23);
            this.lblName.TabIndex = 14;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(183, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "住院号：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(375, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "床号：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "姓名：";
            // 
            // FrmTurn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(512, 333);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTurn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "转科申请";
            this.Load += new System.EventHandler(this.FrmTurn_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void FrmTurn_Load(object sender, System.EventArgs e)
        {
            loadData();

            DateTime dt = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            this.dateTimePicker1.Value = dt;
            this.dateTimePicker1.MaxDate = dt.Date.AddDays(7);

            this.dateTimePicker1.MinDate = dt.Date.AddDays(-2);
            string cfg6031 = new SystemCfg(6031).Config;
            if (cfg6031 == "1")
            {
                dateTimePicker1.Enabled = true;
                //add by zouchihua 2012-02-14 转科医嘱必须大于除手术以为的医嘱的时间
                try
                {
                    string sql = "select * from zy_orderrecord where inpatient_id='" + this.BinID + "' and baby_id=0 and DELETE_BIT=0 and MNGTYPE in (0,1) and dept_id not in (SELECT DEPTID FROM SS_DEPT) order by ORDER_BDATE desc ";
                    DataTable tb = InstanceForm._database.GetDataTable(sql);
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        this.dateTimePicker1.MinDate = Convert.ToDateTime(tb.Rows[0]["ORDER_BDATE"].ToString()).AddMinutes(1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dateTimePicker1.Enabled = false;
            }
        }
        #region 获得机构编码
        private void LoadJgbm()
        {
            try
            {
                #region 获得机构编码 Modify By zouchihua 2011-10-01
                DataTable Db_jgbm = FrmMdiMain.Database.GetDataTable("select JGBM,JGMC  from JC_JGBM ");
                cmbJgbm.DisplayMember = "jgmc";
                cmbJgbm.ValueMember = "jgbm";
                cmbJgbm.DataSource = Db_jgbm;
                cmbJgbm.SelectedValue = FrmMdiMain.Jgbm;
                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        #endregion
        private void loadData()
        {
            //获得机构编码 Modiby by Zouchihua 2011-10-11
            LoadJgbm();
            this.cmbJgbm.SelectedValueChanged += new EventHandler(cmbJgbm_SelectedValueChanged);
            string sSql = "select a.dept_id dept_br,a.name,a.inpatient_no,a.bed_no,c.name in_diagnosis,a.ward_id,b.ward_name  from dbo.VI_ZY_VINPATIENT_ALL a left join jc_ward b on a.ward_id=b.ward_id left join jc_disease c on a.in_diagnosis=c.coding and isnull(a.ybjklx,0)=c.ybjklx where inpatient_id='" + this.BinID + "' and baby_id=0 ";
            DataTable myTb = InstanceForm._database.GetDataTable(sSql);
            if (myTb.Rows.Count == 0) return;
            lblName.Text = myTb.Rows[0]["name"].ToString().Trim();
            lblZyh.Text = myTb.Rows[0]["inpatient_no"].ToString().Trim();
            lblBedNo.Text = myTb.Rows[0]["bed_no"].ToString();
            lblDiag.Text = myTb.Rows[0]["in_diagnosis"].ToString().Trim();
            lblWard.Tag = myTb.Rows[0]["ward_id"];
            lblWard.Text = myTb.Rows[0]["ward_name"].ToString();
            Dept_Br = Convert.ToInt64(myTb.Rows[0]["dept_br"]);
            cmbJgbm_SelectedValueChanged(null, null);
            
            //Add By Tany 2014-12-19 增加下拉选择
            cmbWard.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbWard.Text == "")
                    {
                        cmbWard.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm,b.ward_id from jc_dept_property a inner join jc_ward b on a.dept_id=b.dept_id 
                            where  a.DELETED=0 ";//a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')
                    ssql = ssql + " and  a.jgbm=" + this.cmbJgbm.SelectedValue.ToString();

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Ward_Id", "Name", "pym", "wbm" },
                                                                                       new string[] { "代码", "名称", "拼音码", "五笔码", "编号" },
                                                                                       new string[] { "Ward_Id", "Name", "PYM", "WBM", "Dept_id" }, new int[] { 80, 150, 80, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm._database.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbWard;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbWard.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbWard.Text = frmSelectCard.SelectDataRow["Name"].ToString();
                        cmbWard.SelectedValue = frmSelectCard.SelectDataRow["Ward_Id"].ToString(); ;
                    }
                }
            };
        }
        //Modiby by Zouchihua 2011-10-11 获得科室信息
        void cmbJgbm_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = FrmMdiMain.Database.GetDataTable("select ward_id ID,ward_name NAME from JC_WARD a left join  JC_DEPT_PROPERTY b on a.DEPT_ID=b.DEPT_ID where b.DELETED=0  and a.jgbm=" + this.cmbJgbm.SelectedValue.ToString() + " order by id ");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得病区信息！");
                    return;
                }
                cmbWard.DisplayMember = "NAME";
                cmbWard.ValueMember = "ID";
                cmbWard.DataSource = tb;
                tb = null;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString(), "错误");
            }
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (cmbWard.Text == "")
            {
                MessageBox.Show("没有选择病区，请选择转到的病区", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbDept.Text == "")
            {
                MessageBox.Show("没有选择科室，请选择转到的科室", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Modify By tany 2010-01-08 原来判断开单医生的科室，现在判断病人所在科室
            if (this.Dept_Br == Convert.ToInt64(this.cmbDept.SelectedValue))
            {
                FrmMessageBox.Show("不允许本科室转本科室！请重新选择科室。", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //			if(myQuery.SexName(this.BinID)=="男") 
            //			{
            //				//选择转出的科室如果是妇科和产科,则提示不能转(302表示妇产科)
            //				if(Convert.ToInt64(this.cmbDept.SelectedValue) == 302)  
            //				{
            //					MessageBox.Show("该病人是男性,不能转去妇产科,请重新选择科室","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //					return;
            //				}
            //			}

            #region 权限确认
            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(6023).Config == "0")
            {
                string dlgvalue = DlgPW.Show();
                string pwStr = dlgvalue; //YS.Password;
                bool bOk = InstanceForm._currentUser.CheckPassword(pwStr);
                if (!bOk)
                {
                    FrmMessageBox.Show("你没有通过权限确认，不能发送医嘱！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion

            //写停医嘱记录
            string er = "";
            long Order_Num = myQuery.GetYzNum(this.BinID, this.DeptID);
            long OrderNumCount = Order_Num + 1;
            int num = 0;
            SystemCfg  cfg6045=new SystemCfg(6045);
            DataTable babyTb;
            //Modify By Tany 2011-03-07 婴儿和大人一起停医嘱并转科
            //add by zouchihua 2012-5-15
            if (cfg6045.Config.Trim() == "0")
            {
               babyTb = FrmMdiMain.Database.GetDataTable("select * from zy_inpatient_baby where inpatient_id='" + BinID + "'");
            }
            else
                babyTb = FrmMdiMain.Database.GetDataTable("select * from zy_inpatient_baby where inpatient_id='" + BinID + "'  and  flag in(1,3,4)");
            //Modify By Tany 2011-03-07 婴儿和大人一起转科，对方科室也必须是产科
            if (babyTb != null && babyTb.Rows.Count > 0)
            {
                if (!myFunc.IsFCK(cmbWard.SelectedValue.ToString().Trim()))
                {
                    FrmMessageBox.Show("带婴儿的病人不允许转到非妇产科室！请重新选择科室。", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //生成数据库访问对象
            FrmMdiMain.Database.BeginTransaction();
            try
            {
                //构成SQL语句,并执行,默认婴儿ID为0，医嘱录入人为医生本人，默认病人科室为医生科室,中草药剂量默认为1,操作员为医生本人
                //武汉中心医院转科、出院、死亡医嘱存储到临时医嘱 Moidify by jchl
                string OrderID = PubStaticFun.NewGuid().ToString();//Modify BY Tany 2014-12-04 转科的Order_id不用查询来取，直接赋值公用就行//Convert.ToString(FrmMdiMain.Database.GetDataResult(sSql));
                string sSql = "INSERT INTO ZY_ORDERRECORD(" +
                    "order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc," +
                    "HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date," +
                    "Order_bDate,First_times,Order_Usage,frequency," +
                    "Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,serial_no,jgbm)" +
                    " VALUES('" + OrderID + "'," + OrderNumCount.ToString() + ",'" + BinID.ToString() + "'," + this.DeptID.ToString() + ",'" + this.WardID + "',1,0," + this.YS_ID.ToString() + "," +
                    "-1,2,'" + "转：【" + this.cmbJgbm.Text + "】" + this.cmbDept.Text.Trim() + "',0,1,'',GetDate()," + "'" + this.dateTimePicker1.Value.ToString() + "',1,'','1'," +
                    "" + this.YS_ID.ToString() + ",0,1," + "0" + "," + (Dept_Br == 0 ? DeptID.ToString() : Dept_Br.ToString()) + "," + this.DeptID.ToString() + ",0," + FrmMdiMain.Jgbm + ") ";
                FrmMdiMain.Database.DoCommand(sSql);

                //获取转科医嘱order_id
                //武汉中心医院转科、出院、死亡医嘱存储到临时医嘱 Moidify by jchl[mngtype=0->mngtype=1]
                //sSql = "select order_id from zy_orderrecord where inpatient_id='" + this.BinID.ToString() + "' and mngtype=1 and HOItem_ID=-1 and order_context like '%转%'and Order_bDate='" + this.dateTimePicker1.Value.ToString() + "' ";
                //string OrderID = Convert.ToString(FrmMdiMain.Database.GetDataResult(sSql));
                string tran_type="0";
                if (chk_trantype.Checked == false)
                    tran_type = "1";
                string sSql0 = "insert into zy_transfer_dept(" +
                    "id,Inpatient_id,S_dept_id,D_dept_id,Transfer_date,Book_date,Operator,description,Baby_id,finish_bit,order_id,CANCEL_BIT,jgbm,Trans_type) " +
                    "values('" + PubStaticFun.NewGuid() + "','" + BinID.ToString() + "'," + (Dept_Br == 0 ? DeptID.ToString() : Dept_Br.ToString()) + "," + this.cmbDept.SelectedValue.ToString() + ",'" + this.dateTimePicker1.Value.ToString() + "'," +
                    "GetDate()," + this.YS_ID.ToString() + ",'转',0,0,'" + OrderID + "',0 ," + FrmMdiMain.Jgbm + ","+tran_type+")";
                FrmMdiMain.Database.DoCommand(sSql0);

                //Modify By Tany 2011-03-07 婴儿和大人一起停医嘱
                if (babyTb != null && babyTb.Rows.Count > 0)
                {
                    for (int i = 0; i < babyTb.Rows.Count; i++)
                    {
                        string sSql1 = "";
                        if (chk_trantype.Checked)//正常转科
                        {
                            sSql1= "insert into zy_transfer_dept(" +
                            "id,Inpatient_id,S_dept_id,D_dept_id,Transfer_date,Book_date,Operator,description,Baby_id,finish_bit,order_id,CANCEL_BIT,jgbm,Trans_type) " +
                            "values('" + PubStaticFun.NewGuid() + "','" + BinID.ToString() + "'," + (Dept_Br == 0 ? DeptID.ToString() : Dept_Br.ToString()) + "," + this.cmbDept.SelectedValue.ToString() + ",'" + this.dateTimePicker1.Value.ToString() + "'," +
                            "GetDate()," + this.YS_ID.ToString() + ",'转'," + Convert.ToInt64(babyTb.Rows[i]["baby_id"]) + ",0,'" + OrderID + "',0 ," + FrmMdiMain.Jgbm + ",0)";
                        }
                        else
                        {
                            //非正常转科
                             sSql1= "insert into zy_transfer_dept(" +
                            "id,Inpatient_id,S_dept_id,D_dept_id,Transfer_date,Book_date,Operator,description,Baby_id,finish_bit,order_id,CANCEL_BIT,jgbm,Trans_type) " +
                            "values('" + PubStaticFun.NewGuid() + "','" + BinID.ToString() + "'," + (Dept_Br == 0 ? DeptID.ToString() : Dept_Br.ToString()) + "," + this.cmbDept.SelectedValue.ToString() + ",'" + this.dateTimePicker1.Value.ToString() + "'," +
                            "GetDate()," + this.YS_ID.ToString() + ",'转'," + Convert.ToInt64(babyTb.Rows[i]["baby_id"]) + ",0,'" + OrderID + "',0 ," + FrmMdiMain.Jgbm + ",1)";
                        }
                         FrmMdiMain.Database.DoCommand(sSql1);
                    }
                }

                if (this.radBt1.Checked == true) num = -1;
                else num = Convert.ToInt16(this.numUD.Value);

                if (this.lbStop.Text == "√")
                {
                    //停医嘱
                    myQuery.StopOrders(FrmMdiMain.Database, this.dateTimePicker1.Value.ToString(), this.YS_ID, this.BinID, 0, num);
                    //停账单
                    myQuery.StopOrders_ZD(FrmMdiMain.Database, this.dateTimePicker1.Value.ToString(), this.YS_ID, this.BinID, 0, num, 0);

                    //Modify By Tany 2011-03-07 婴儿和大人一起停医嘱
                    if (babyTb != null && babyTb.Rows.Count > 0)
                    {
                        for (int i = 0; i < babyTb.Rows.Count; i++)
                        {
                            //停医嘱
                            myQuery.StopOrders(FrmMdiMain.Database, this.dateTimePicker1.Value.ToString(), this.YS_ID, this.BinID, Convert.ToInt64(babyTb.Rows[i]["baby_id"]), num);
                            //停账单
                            myQuery.StopOrders_ZD(FrmMdiMain.Database, this.dateTimePicker1.Value.ToString(), this.YS_ID, this.BinID, Convert.ToInt64(babyTb.Rows[i]["baby_id"]), num, 0);
                        }
                    }
                }

                FrmMdiMain.Database.CommitTransaction();
                MessageBox.Show("转科申请成功！");
                outType = true;

                string msg_wardid = InstanceForm._currentDept.WardId;
                long msg_deptid = 0;
                long msg_empid = 0;
                string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                string msg_msg = lblBedNo.Text + " 床 " + lblName.Text + " 有转科医嘱，请处理！";
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.住院护士站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
            }
            catch (System.Exception err)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show("转科申请失败！请重试！\n" + err.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                er = err.ToString();
                this.Close();
            }
            finally
            {
                if (er.Trim() == "") myQuery.SaveLog(this.DeptID, this.YS_ID, "开转科医嘱", this.BinID.ToString() + "：从" + this.DeptID.ToString() + "转到" + this.cmbDept.SelectedValue.ToString() + "，末日次数：" + num.ToString(), 0, 41);
                else myQuery.SaveLog(this.DeptID, this.YS_ID, "转科医嘱失败", this.BinID.ToString() + "：" + er.Trim() + " ⊙从" + this.DeptID.ToString() + "转到" + this.cmbDept.SelectedValue.ToString() + "，末日次数：" + num.ToString(), 1, 41);
            }

            //发消息通知护士站
            if (this.chk_hsz.Checked)
            {
                long warddept = (this.DeptID);
                myQuery.InformHS(warddept, " 请为 " + this.lblBedNo.Text.Trim() + "床 " + this.lblName.Text.Trim() + " 办理转科手续");
            }
            Ts_zyys_main.frmMain.outflag = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void cmbWard_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.cmbWard.SelectedValue == null)
                {
                    return;
                }
                string wardid = this.cmbWard.SelectedValue.ToString();

                //下面SQL语句中的c.type_code = '008'为临床科室(临床科室可以包含门诊、住院、挂号相关科室)
                //			DataTable tb=FrmMdiMain.Database.GetDataTable("SELECT a.dept_id, b.name,a.ward_id  FROM JC_WARDRDEPT a INNER JOIN JC_DEPT_PROPERTY b ON a.dept_id = b.dept_id and b.type_code='001' where a.ward_id='"+ wardid+"'");
                //Add by zouchihua 筛选停用了的科室
                DataTable tb = FrmMdiMain.Database.GetDataTable("SELECT a.dept_id, b.name,a.ward_id  FROM JC_DEPT_PROPERTY b INNER JOIN JC_WARDRDEPT a ON b.dept_id = a.dept_id where a.ward_id = '" + wardid + "' and DELETED=0 and a.dept_id not in(select dept_id from jc_ward where ward_id = '" + wardid + "')");
                //			DataTable tb=FrmMdiMain.Database.GetDataTable("SELECT a.dept_id, b.name,a.ward_id  FROM JC_WARDRDEPT a INNER JOIN JC_DEPT_PROPERTY b ON a.dept_id = b.dept_id INNER JOIN jc_dept_type_relation c on b.dept_id = c.dept_id and c.type_code = '008' where a.ward_id='"+ wardid+"'");
                if (tb == null)
                {
                    MessageBox.Show("错误，未能取得科室状况信息！");
                    return;
                }
                cmbDept.Text = "";
                cmbDept.DisplayMember = "name";
                cmbDept.ValueMember = "dept_id";
                cmbDept.DataSource = tb;
                tb = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radBt1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radBt1.Checked == true) this.numUD.Enabled = false;
            else this.numUD.Enabled = true;
        }

        private void lbStop_Click(object sender, System.EventArgs e)
        {
            if (stopflag == 0)
            {
                if (lbStop.Text.Trim() == "×") lbStop.Text = "√";
                else lbStop.Text = "×";
            }
        }

        private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DataTable myTb = FrmMdiMain.Database.GetDataTable("select * from zy_zkgx where s_dept=" + this.DeptID + " and d_dept=" + this.cmbDept.SelectedValue);
            if (myTb.Rows.Count > 0)
            {
                this.lbStop.Text = "×";
                stopflag = 0;
            }
            else
            {
                this.lbStop.Text = "√";
                stopflag = 1;
            }
        }

        private void chk_trantype_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_trantype.Checked == false)
            {
                if (MessageBox.Show(this, "此操作将会使转科不产生转科记录！！，确认不产生转科记录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    this.chk_trantype.Checked = true;
                    return ;
                }
            }
        }
    }
}