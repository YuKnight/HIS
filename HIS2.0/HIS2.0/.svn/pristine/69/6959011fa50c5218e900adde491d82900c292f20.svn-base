using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ts_zyys_public;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using Ts_zyys_main;
using TrasenHIS.BLL;

namespace Ts_zyys_yzgl
{
    /// <summary>
    /// 死亡医嘱 的摘要说明。
    /// </summary>
    public class FrmDeath : System.Windows.Forms.Form
    {
        private DbQuery myQuery = new DbQuery();
        public User YS = null;
        public long YS_ID = 0;
        public long DeptID = 0;
        public string WardID = "";
        public Guid BinID = Guid.Empty;
        public long BabyID = 0;
        public bool outType = false; //是否完成了死亡医嘱
        private DataTable dt;
        private DataTable diseaseTb = null;
        private TextBox TBox = new TextBox();
        private int ybjklx = 0;
        private int yblx = 0;//Add By Tany 2015-04-28

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
        private System.Windows.Forms.NumericUpDown numUD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtXY;
        private System.Windows.Forms.DateTimePicker dTimePicker1;
        private System.Windows.Forms.RadioButton radBt2;
        private System.Windows.Forms.RadioButton radBt1;
        private DataGrid GrdSel;
        private DataGridTableStyle dataGridTableStyle1;
        private DataGridTextBoxColumn dataGridTextBoxColumn1;
        private DataGridTextBoxColumn dataGridTextBoxColumn2;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private DataGridTextBoxColumn dataGridTextBoxColumn4;
        private Button btManyZD;
        private Label lblYbjbbm;
        private DataGridTextBoxColumn dataGridTextBoxColumn5;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmDeath()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeath));
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
            this.GrdSel = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.numUD = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtXY = new System.Windows.Forms.TextBox();
            this.dTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radBt2 = new System.Windows.Forms.RadioButton();
            this.radBt1 = new System.Windows.Forms.RadioButton();
            this.btManyZD = new System.Windows.Forms.Button();
            this.lblYbjbbm = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblDiag
            // 
            this.lblDiag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiag.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDiag.ForeColor = System.Drawing.Color.Navy;
            this.lblDiag.Location = new System.Drawing.Point(208, 48);
            this.lblDiag.Name = "lblDiag";
            this.lblDiag.Size = new System.Drawing.Size(224, 23);
            this.lblDiag.TabIndex = 20;
            this.lblDiag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(168, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "诊断：";
            // 
            // lblWard
            // 
            this.lblWard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWard.ForeColor = System.Drawing.Color.Navy;
            this.lblWard.Location = new System.Drawing.Point(208, 16);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(128, 23);
            this.lblWard.TabIndex = 18;
            this.lblWard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(168, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "病室：";
            // 
            // lblBedNo
            // 
            this.lblBedNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBedNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBedNo.ForeColor = System.Drawing.Color.Navy;
            this.lblBedNo.Location = new System.Drawing.Point(384, 16);
            this.lblBedNo.Name = "lblBedNo";
            this.lblBedNo.Size = new System.Drawing.Size(48, 23);
            this.lblBedNo.TabIndex = 16;
            this.lblBedNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZyh
            // 
            this.lblZyh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZyh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZyh.ForeColor = System.Drawing.Color.Navy;
            this.lblZyh.Location = new System.Drawing.Point(64, 48);
            this.lblZyh.Name = "lblZyh";
            this.lblZyh.Size = new System.Drawing.Size(96, 23);
            this.lblZyh.TabIndex = 15;
            this.lblZyh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.Navy;
            this.lblName.Location = new System.Drawing.Point(64, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(96, 23);
            this.lblName.TabIndex = 14;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "住院号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(344, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "床号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "姓名：";
            // 
            // GrdSel
            // 
            this.GrdSel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GrdSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrdSel.CaptionBackColor = System.Drawing.SystemColors.Window;
            this.GrdSel.CaptionVisible = false;
            this.GrdSel.DataMember = "";
            this.GrdSel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdSel.Location = new System.Drawing.Point(80, 127);
            this.GrdSel.Name = "GrdSel";
            this.GrdSel.RowHeaderWidth = 20;
            this.GrdSel.Size = new System.Drawing.Size(368, 104);
            this.GrdSel.TabIndex = 47;
            this.GrdSel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.GrdSel.Visible = false;
            this.GrdSel.DoubleClick += new System.EventHandler(this.GrdSel_DoubleClick);
            this.GrdSel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GrdSel_KeyUp);
            this.GrdSel.Click += new System.EventHandler(this.GrdSel_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.GrdSel;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn3});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "名称";
            this.dataGridTextBoxColumn1.MappingName = "name";
            this.dataGridTextBoxColumn1.Width = 150;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "icd";
            this.dataGridTextBoxColumn2.MappingName = "icd";
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "医保诊断";
            this.dataGridTextBoxColumn5.MappingName = "YBJBMC";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 220;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "医保编码";
            this.dataGridTextBoxColumn4.MappingName = "YBJBBM";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "拼音码";
            this.dataGridTextBoxColumn3.MappingName = "拼音码";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // numUD
            // 
            this.numUD.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numUD.Location = new System.Drawing.Point(204, 177);
            this.numUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD.Name = "numUD";
            this.numUD.Size = new System.Drawing.Size(40, 24);
            this.numUD.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(16, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 14);
            this.label6.TabIndex = 34;
            this.label6.Text = "医嘱末日执行次数：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 35;
            this.label4.Text = "死亡诊断";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(219, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 37;
            this.label7.Text = "死亡时间";
            // 
            // txtXY
            // 
            this.txtXY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXY.Location = new System.Drawing.Point(72, 24);
            this.txtXY.Name = "txtXY";
            this.txtXY.Size = new System.Drawing.Size(136, 23);
            this.txtXY.TabIndex = 38;
            this.txtXY.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.txtXY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // dTimePicker1
            // 
            this.dTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dTimePicker1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTimePicker1.Location = new System.Drawing.Point(288, 24);
            this.dTimePicker1.Name = "dTimePicker1";
            this.dTimePicker1.ShowUpDown = true;
            this.dTimePicker1.Size = new System.Drawing.Size(144, 23);
            this.dTimePicker1.TabIndex = 40;
            this.dTimePicker1.Value = new System.DateTime(2004, 9, 26, 0, 0, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(361, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(276, 232);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 41;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtXY);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(8, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 64);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // radBt2
            // 
            this.radBt2.Checked = true;
            this.radBt2.Location = new System.Drawing.Point(142, 177);
            this.radBt2.Name = "radBt2";
            this.radBt2.Size = new System.Drawing.Size(64, 24);
            this.radBt2.TabIndex = 46;
            this.radBt2.TabStop = true;
            this.radBt2.Text = "修改值";
            // 
            // radBt1
            // 
            this.radBt1.Location = new System.Drawing.Point(142, 156);
            this.radBt1.Name = "radBt1";
            this.radBt1.Size = new System.Drawing.Size(64, 24);
            this.radBt1.TabIndex = 45;
            this.radBt1.Text = "默认值";
            this.radBt1.CheckedChanged += new System.EventHandler(this.radBt1_CheckedChanged);
            // 
            // btManyZD
            // 
            this.btManyZD.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btManyZD.Location = new System.Drawing.Point(164, 232);
            this.btManyZD.Name = "btManyZD";
            this.btManyZD.Size = new System.Drawing.Size(102, 28);
            this.btManyZD.TabIndex = 48;
            this.btManyZD.Text = "多诊断录入";
            this.btManyZD.UseVisualStyleBackColor = true;
            this.btManyZD.Click += new System.EventHandler(this.btManyZD_Click);
            // 
            // lblYbjbbm
            // 
            this.lblYbjbbm.AutoSize = true;
            this.lblYbjbbm.Location = new System.Drawing.Point(19, 200);
            this.lblYbjbbm.Name = "lblYbjbbm";
            this.lblYbjbbm.Size = new System.Drawing.Size(0, 12);
            this.lblYbjbbm.TabIndex = 49;
            this.lblYbjbbm.Visible = false;
            // 
            // FrmDeath
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(456, 261);
            this.Controls.Add(this.lblYbjbbm);
            this.Controls.Add(this.btManyZD);
            this.Controls.Add(this.GrdSel);
            this.Controls.Add(this.numUD);
            this.Controls.Add(this.radBt2);
            this.Controls.Add(this.radBt1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "死亡医嘱";
            this.Load += new System.EventHandler(this.FrmDeath_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void FrmDeath_Load(object sender, System.EventArgs e)
        {
            //loadData();
            DateTime dt = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            this.dTimePicker1.Value = dt;
            this.dTimePicker1.MaxDate = dt;
            string config = (new SystemCfg(6008)).Config;
            this.dTimePicker1.MinDate = dt.AddDays(-Convert.ToDouble(config != "" ? config : "3"));

            //Modify By Tany 2010-09-29 将loadData放下面，里面还要验证病人入院日期，保证死亡日期不能小于入院日期
            loadData();

            //武汉中心医院出院需要的代码 Modify By Tany 2014-12-09
            bool isOk = false;
            try
            {
                isOk = TrasenHIS.BLL.OutHosp.Cycl(lblZyh.Text, FrmMdiMain.Database);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isOk = false;
            }
            finally
            {
                if (!isOk)
                {
                    Close();
                }
            }

            txtXY.Focus();
        }
        private void loadData()
        {
            string sSql = "select a.name,a.inpatient_no,a.bed_no,c.name in_diagnosis,a.ward_id,b.ward_name,a.yblx,isnull(a.ybjklx,'0') ybjklx,in_date  from dbo.VI_ZY_VINPATIENT_ALL a left join jc_ward b on a.ward_id=b.ward_id left join jc_disease c on a.in_diagnosis=c.coding and isnull(a.ybjklx,0)=c.ybjklx where inpatient_id='" + this.BinID + "' and baby_id=" + this.BabyID;
            DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql);
            if (myTb.Rows.Count == 0) return;
            lblName.Text = myTb.Rows[0]["name"].ToString().Trim();
            lblZyh.Text = myTb.Rows[0]["inpatient_no"].ToString().Trim();
            lblBedNo.Text = myTb.Rows[0]["bed_no"].ToString();
            lblDiag.Text = myTb.Rows[0]["in_diagnosis"].ToString().Trim();
            lblWard.Tag = myTb.Rows[0]["ward_id"];
            lblWard.Text = myTb.Rows[0]["ward_name"].ToString();
            ybjklx = Convert.ToInt32(myTb.Rows[0]["ybjklx"]);
            yblx = Convert.ToInt32(myTb.Rows[0]["yblx"]);//Add By Tany 2015-04-28
            //			Inpatient Inpt=new Inpatient(this.BinID);
            //			Patient pt=new Patient (Inpt.PatientID );
            //			lblName.Text=pt.Name.Trim();
            //			lblZyh.Text =pt.Inpatient_No .Trim ();
            //			lblBedNo.Text =myQuery.GetBedNO(Inpt.Bed_ID);
            //			lblDiag.Text =Inpt.In_Diagnosis;
            //			lblWard.Tag  =WardID;
            //			lblWard.Text  =WardID;

            //Modify by Tany 2010-09-29 验证病人入院日期，保证死亡日期不能小于入院日期
            if (this.dTimePicker1.MinDate < Convert.ToDateTime(myTb.Rows[0]["in_date"].ToString()))
            {
                this.dTimePicker1.MinDate = Convert.ToDateTime(myTb.Rows[0]["in_date"].ToString());
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (this.BabyID == 0 && (txtXY.Text.Trim() == "" || Convertor.IsNull(txtXY.Tag, "") == ""))
            {
                MessageBox.Show("出院诊断不完整！");
                return;
            }
            #region//Add by Zouchihua 2011-11-18 判断病人的当前科室是不是属于本院区，获得病人所在科室机构编码
            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(BinID);


            //Modify by zouchihfua 2011-11-16  病人所在科室机构编码
            //string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(BinID);
            int BrJgbm = Convert.ToInt32(rtnSql[1]);
            #endregion
            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(6023).Config == "0")
            {
                string dlgvalue = DlgPW.Show();
                string pwStr = dlgvalue; //YS.Password;
                bool bOk = InstanceForm._currentUser.CheckPassword(pwStr);
                if (!bOk)
                {
                    FrmMessageBox.Show("你没有通过权限确认，不能提交该医嘱！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (this.BabyID == 0 && ybjklx == 40 && yblx >= 0)
            {
                //医保病人必须有医保诊断
                if (string.IsNullOrEmpty(Convertor.IsNull(lblYbjbbm.Tag, "")))
                {
                    MessageBox.Show("医保病人：未找到西医诊断的医保编码,请重新选择西医诊断！");
                    return;
                }
            }


            //出院医嘱提醒  modify by jchl   2015-09-30
            OutHosp.isZg(lblZyh.Text.Trim(), FrmMdiMain.Database);

            string er = "";
            long Order_Num = myQuery.GetYzNum(this.BinID, this.DeptID);
            long OrderNumCount = Order_Num + 1;
            int num = 0;//末日次数
            FrmMdiMain.Database.BeginTransaction();
            try
            {
                //构成SQL语句,并执行,默认婴儿ID为0，医嘱录入人为医生本人，默认病人科室为医生科室,中草药剂量默认为1,操作员为医生本人
                //武汉中心医院转科、出院、死亡医嘱存储到临时医嘱 Moidify by jchl
                string sSql = "INSERT INTO ZY_ORDERRECORD(" +
                    "order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc," +
                    "HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date," +
                    "Order_bDate,First_times,Order_Usage,frequency," +
                    "Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,serial_no,jgbm)" +
                    " VALUES('" + PubStaticFun.NewGuid() + "'," + OrderNumCount.ToString() + ",'" + BinID.ToString() + "'," + this.DeptID.ToString() + ",'" + this.WardID + "',1,0," + this.YS_ID.ToString() + "," +
                    "-1,2,'病人死亡',0,1,'',GetDate(),'" + this.dTimePicker1.Value.ToString() + "',1,'','1'," +
                    "" + this.YS_ID.ToString() + ",0,1," + "0" + "," + this.DeptID.ToString() + "," + this.DeptID.ToString() + ",0," + BrJgbm + ") ";

                FrmMdiMain.Database.DoCommand(sSql);

                string sSql0 = "update zy_inpatient set out_mode=4,out_date='" + this.dTimePicker1.Value.ToString() + "',out_diagnosis='" + Convertor.IsNull(txtXY.Tag, "") + "'," +
                    "flag=4 where inpatient_id='" + this.BinID.ToString() + "'";
                FrmMdiMain.Database.DoCommand(sSql0);

                if (this.BabyID == 0)
                {
                    //Modify by jchl 优先删除该病人的废的第1诊断
                    string sqlDelZd = string.Format(@"delete from ZY_DISEASE_MANY where INPATIENT_ID='{0}' and DISEASE_MARK='第1诊断'", this.BinID.ToString());
                    FrmMdiMain.Database.DoCommand(sqlDelZd);

                    //Modify by jchl 新增第一诊断
                    sSql = String.Format(@" INSERT INTO ZY_DISEASE_MANY (INPATIENT_ID ,INPATIENT_NO ,BABY_ID ,DISEASE_MARK ,DISEASE_CODE ,DISEASE_NAME ,JGBM,YBJBBM,YBJBMC) 
                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}')",
                    this.BinID.ToString(), lblZyh.Text.Trim(), "0", "第1诊断", Convertor.IsNull(txtXY.Tag, ""), txtXY.Text, BrJgbm, Convertor.IsNull(lblYbjbbm.Tag, ""), lblYbjbbm.Text);
                    FrmMdiMain.Database.DoCommand(sSql);
                }

                if (this.radBt1.Checked == true) num = -1;
                else num = Convert.ToInt16(this.numUD.Value);
                //
                //停医嘱			
                myQuery.StopOrders(FrmMdiMain.Database, this.dTimePicker1.Value.ToString(), this.YS_ID, this.BinID, this.BabyID, num);
                //停账单
                myQuery.StopOrders_ZD(FrmMdiMain.Database, this.dTimePicker1.Value.ToString(), this.YS_ID, this.BinID, this.BabyID, num, 0);

                FrmMdiMain.Database.CommitTransaction();
                outType = true;

                string msg_wardid = InstanceForm._currentDept.WardId;
                long msg_deptid = 0;
                long msg_empid = 0;
                string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                string msg_msg = lblBedNo.Text + " 床 " + lblName.Text + " 有死亡医嘱，请处理！";
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.住院护士站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
            }
            catch (Exception err)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show("生成死亡医嘱错误！请重试！\n" + err.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                er = err.ToString();
                this.Close();
            }
            finally
            {
                //				_Database.Close();
                if (er.Trim() == "") myQuery.SaveLog(this.DeptID, this.YS_ID, "开死亡医嘱", this.BinID.ToString() + "： " + txtXY.Text.Trim() + "，死亡时间" + this.dTimePicker1.Value.ToString() + "，末日次数：" + num.ToString(), 0, 41);
                else myQuery.SaveLog(this.DeptID, this.YS_ID, "死亡医嘱失败", this.BinID.ToString() + "：" + er.Trim() + " ⊙" + txtXY.Text.Trim() + "，死亡时间" + this.dTimePicker1.Value.ToString() + "，末日次数：" + num.ToString(), 1, 41);
            }

            //FrmYZGL.outType=true;
            Ts_zyys_main.frmMain.outflag = true;
            this.Close();
        }
        private void radBt1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radBt1.Checked == true) this.numUD.Enabled = false;
            else this.numUD.Enabled = true;
        }

        private void textBox_TextChanged(object sender, System.EventArgs e)
        {
            string Sort = "";
            TBox = (TextBox)sender;
            this.GrdSel.Visible = true;
            if (TBox == this.txtXY)
            {
                this.GrdSel.Top = 128;
                Sort = "D";
            }

            string str = TBox.Text.Trim().Replace("'", ".").ToUpper();
            str = str == "" ? "" : " and (拼音码 like '" + str + "%' )";
            //			string sSql="select name NAME,coding ICD,py_code 拼音码 from base_disease where sort='"+Sort+"' and py_code like '"+str+"%'";
            //			if (diseaseTb==null)
            //			{
            //string sSql = "select top 20 name NAME,coding ICD,py_code 拼音码,sort from jc_disease where py_code like '" + TBox.Text.Trim() + "%' order by len(py_code)";
            //string sSql = "select top 20 name NAME,coding ICD,py_code 拼音码,sort from jc_disease where 1=1 " + (ybjklx <= 0 ? "" : " and ybjklx =" + ybjklx) + " and py_code like '" + TBox.Text.Trim() + "%' order by len(py_code)";


            //Modify By Tany 2015-05-26 医保接口类型=0的时候也要过滤
            //Modify by jchl 2015-08-22 加入ybjbbm
            string sSql = "select top 20 name NAME,coding ICD,'' as YBJBBM,'' as YBJBMC,py_code 拼音码,sort from jc_disease where 1=1 " + (ybjklx < 0 ? "" : " and ybjklx =" + ybjklx) + " and py_code like '" + TBox.Text.Trim() + "%' order by len(py_code)";
            if (ybjklx == 40 && yblx >= 0)
            {
                //医保诊断带出医保编码
                sSql = @"select top 20 a.name NAME,a.coding ICD,b.YBJBBM,b.YBJBMC,a.py_code 拼音码,a.wb_code 五笔码,a.sort 
                            from jc_disease a
                            inner join JC_DISEASE_YYYBDZ b on a.CODING=b.YYJBBM 
                            where 1=1 and a.ybjklx =" + ybjklx + " and (py_code like '" + TBox.Text.Trim() + "%'  or wb_code like '%" + TBox.Text.Trim() + "%' ) order by len(py_code)";
            }


            diseaseTb = FrmMdiMain.Database.GetDataTable(sSql);
            dt = null;
            dt = diseaseTb.Clone();
            //			}
            DataRow[] diseaseDR = diseaseTb.Select();//("sort='"+Sort+"'","拼音码");    //暂时屏蔽
            GrdSel.DataSource = null;
            dt.Clear();
            foreach (DataRow dr in diseaseDR)
            {
                dt.Rows.Add(dr.ItemArray);
            }
            //			dt=DatabaseAccess.GetDataTable(DatabaseType.IbmDb2ZY,sSql);

            GrdSel.DataSource = dt;
            PubStaticFun.ModifyDataGridStyle(GrdSel, 0);
        }

        private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            TBox = (TextBox)sender;
            int keyInt = Convert.ToInt32(e.KeyCode);
            //			if(keyInt>=65 && keyInt<=90)
            //			{
            //				char Keychar=Convert.ToChar(keyInt);
            //				TBox.Text="";
            //				str+=Keychar.ToString();
            //				TBox.Text=str;
            //			}
            //			else if(keyInt==127)
            //			{
            //				str=TBox.Text.Trim();
            //			}
            if (dt == null)
            {
                this.GrdSel.Visible = false;
                return;
            }
            if (dt.Rows.Count == 0)
            {
                GrdSel.Visible = false;
                return;
            }
            else if (keyInt == 27 && GrdSel.Visible == true)
            {
                lblYbjbbm.Text = "";//Modify by jchl
                lblYbjbbm.Tag = "";//Modify by jchl
                TBox.Text = "";
                GrdSel.Visible = false;
            }
            else if (keyInt == 40 && this.GrdSel.CurrentRowIndex < dt.Rows.Count - 1)
            {
                GrdSel.UnSelect(GrdSel.CurrentCell.RowNumber);
                GrdSel.CurrentRowIndex += 1;
                GrdSel.Select(GrdSel.CurrentCell.RowNumber);
            }
            else if (keyInt == 38 && this.GrdSel.CurrentRowIndex > 0)
            {
                GrdSel.UnSelect(GrdSel.CurrentCell.RowNumber);
                GrdSel.CurrentRowIndex -= 1;
                GrdSel.Select(GrdSel.CurrentCell.RowNumber);
            }
            else if (keyInt == 13)
            {
                lblYbjbbm.Text = dt.Rows[GrdSel.CurrentCell.RowNumber]["YBJBMC"].ToString().Trim();
                lblYbjbbm.Tag = dt.Rows[GrdSel.CurrentCell.RowNumber]["YBJBBM"].ToString().Trim();
                TBox.Tag = dt.Rows[GrdSel.CurrentCell.RowNumber]["ICD"].ToString();
                TBox.Text = dt.Rows[GrdSel.CurrentCell.RowNumber]["NAME"].ToString();
                GrdSel.Visible = false;

                dTimePicker1.Focus();
            }
        }

        private void GrdSel_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int keyInt = Convert.ToInt32(e.KeyCode);
            if (keyInt == 13)
            {
                lblYbjbbm.Text = dt.Rows[GrdSel.CurrentCell.RowNumber]["YBJBMC"].ToString().Trim();
                lblYbjbbm.Tag = dt.Rows[GrdSel.CurrentCell.RowNumber]["YBJBBM"].ToString().Trim();
                TBox.Tag = dt.Rows[GrdSel.CurrentCell.RowNumber]["ICD"].ToString();
                TBox.Text = dt.Rows[GrdSel.CurrentCell.RowNumber]["NAME"].ToString();

                GrdSel.Visible = false;
            }
        }

        private void GrdSel_Click(object sender, System.EventArgs e)
        {
            GrdSel.Select(GrdSel.CurrentCell.RowNumber);
        }

        private void GrdSel_DoubleClick(object sender, System.EventArgs e)
        {
            GrdSel_KeyUp(GrdSel, new KeyEventArgs(Keys.Enter));
        }

        //Add By Tany 2015-04-28 增加多诊断录入
        private void btManyZD_Click(object sender, EventArgs e)
        {
            Cursor = PubStaticFun.WaitCursor();
            try
            {
                ArrayList arrList = new ArrayList();
                arrList.Add(BinID);
                arrList.Add(lblZyh.Text.ToString());
                arrList.Add(BabyID);
                arrList.Add(ybjklx);
                arrList.Add(yblx);
                arrList.Add("");

                FrmMultipleDiagnostic frmMD = new FrmMultipleDiagnostic(arrList);
                frmMD.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }
    }
}