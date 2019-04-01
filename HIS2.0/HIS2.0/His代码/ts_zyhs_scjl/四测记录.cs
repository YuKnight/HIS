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
using TszyHIS;

namespace ts_zyhs_scjl
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class frmSCJL : System.Windows.Forms.Form
    {
        //自定义变量
        private BaseFunc myFunc;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button bt保存;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DtpbeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt打印;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb体温;
        private System.Windows.Forms.TextBox tb脉搏;
        private System.Windows.Forms.TextBox tb呼吸;
        private System.Windows.Forms.TextBox tb血压;
        private System.Windows.Forms.TextBox tb备注;
        private System.Windows.Forms.Button bt删除;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label lblBed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblZyh;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtInpatNo;
        private System.Windows.Forms.Button btnSeek;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.TextBox tbSPO2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bt新建;
        private System.Windows.Forms.Panel panel总;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmSCJL(string _formText)
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bt新建 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtInpatNo = new System.Windows.Forms.TextBox();
            this.btnSeek = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblWard = new System.Windows.Forms.Label();
            this.lblBed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblZyh = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bt删除 = new System.Windows.Forms.Button();
            this.bt打印 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSPO2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb备注 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb血压 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb呼吸 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb脉搏 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb体温 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.bt保存 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel总 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel总.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(168, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 621);
            this.panel1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 370);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(760, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bt新建);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblDept);
            this.panel3.Controls.Add(this.lblWard);
            this.panel3.Controls.Add(this.lblBed);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblName);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.lblZyh);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.bt删除);
            this.panel3.Controls.Add(this.bt打印);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.bt保存);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 373);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 248);
            this.panel3.TabIndex = 2;
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
            this.bt新建.Location = new System.Drawing.Point(392, 200);
            this.bt新建.Name = "bt新建";
            this.bt新建.Size = new System.Drawing.Size(64, 32);
            this.bt新建.TabIndex = 28;
            this.bt新建.Text = "新建(&N)";
            this.bt新建.UseVisualStyleBackColor = false;
            this.bt新建.Click += new System.EventHandler(this.bt新建_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.txtInpatNo);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.btnSeek);
            this.groupBox4.Location = new System.Drawing.Point(8, 181);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 61);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "住院号查询";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBox1.Location = new System.Drawing.Point(4, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 20);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtInpatNo
            // 
            this.txtInpatNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtInpatNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInpatNo.Location = new System.Drawing.Point(4, 23);
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
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(136, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "科室:";
            // 
            // lblDept
            // 
            this.lblDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDept.Location = new System.Drawing.Point(192, 8);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(80, 16);
            this.lblDept.TabIndex = 13;
            // 
            // lblWard
            // 
            this.lblWard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWard.Location = new System.Drawing.Point(336, 8);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(72, 16);
            this.lblWard.TabIndex = 15;
            // 
            // lblBed
            // 
            this.lblBed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBed.Location = new System.Drawing.Point(472, 8);
            this.lblBed.Name = "lblBed";
            this.lblBed.Size = new System.Drawing.Size(64, 16);
            this.lblBed.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(416, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "床号:";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(64, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 16);
            this.lblName.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "姓名:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(280, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "病区:";
            // 
            // lblZyh
            // 
            this.lblZyh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZyh.Location = new System.Drawing.Point(600, 8);
            this.lblZyh.Name = "lblZyh";
            this.lblZyh.Size = new System.Drawing.Size(72, 16);
            this.lblZyh.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(544, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "住院号:";
            // 
            // bt删除
            // 
            this.bt删除.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt删除.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt删除.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt删除.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt删除.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt删除.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt删除.ImageIndex = 0;
            this.bt删除.Location = new System.Drawing.Point(536, 200);
            this.bt删除.Name = "bt删除";
            this.bt删除.Size = new System.Drawing.Size(64, 32);
            this.bt删除.TabIndex = 1;
            this.bt删除.Text = "删除(&D)";
            this.bt删除.UseVisualStyleBackColor = false;
            this.bt删除.Click += new System.EventHandler(this.bt删除_Click);
            // 
            // bt打印
            // 
            this.bt打印.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt打印.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt打印.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt打印.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt打印.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt打印.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt打印.ImageIndex = 0;
            this.bt打印.Location = new System.Drawing.Point(608, 200);
            this.bt打印.Name = "bt打印";
            this.bt打印.Size = new System.Drawing.Size(64, 32);
            this.bt打印.TabIndex = 2;
            this.bt打印.Text = "打印(&P)";
            this.bt打印.UseVisualStyleBackColor = false;
            this.bt打印.Click += new System.EventHandler(this.bt打印_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbSPO2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tb备注);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb血压);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb呼吸);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb脉搏);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb体温);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DtpbeginDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbSPO2
            // 
            this.tbSPO2.Location = new System.Drawing.Point(584, 48);
            this.tbSPO2.MaxLength = 10;
            this.tbSPO2.Name = "tbSPO2";
            this.tbSPO2.Size = new System.Drawing.Size(88, 21);
            this.tbSPO2.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(528, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 82;
            this.label12.Text = "SpO2(%)：";
            // 
            // tb备注
            // 
            this.tb备注.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb备注.Location = new System.Drawing.Point(48, 80);
            this.tb备注.MaxLength = 1024;
            this.tb备注.Multiline = true;
            this.tb备注.Name = "tb备注";
            this.tb备注.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb备注.Size = new System.Drawing.Size(688, 64);
            this.tb备注.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 80;
            this.label6.Text = "备注：";
            // 
            // tb血压
            // 
            this.tb血压.Location = new System.Drawing.Point(178, 48);
            this.tb血压.MaxLength = 10;
            this.tb血压.Name = "tb血压";
            this.tb血压.Size = new System.Drawing.Size(88, 21);
            this.tb血压.TabIndex = 2;
            this.tb血压.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtpbeginDate_KeyUp);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(138, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 78;
            this.label5.Text = "血压：";
            // 
            // tb呼吸
            // 
            this.tb呼吸.Location = new System.Drawing.Point(48, 48);
            this.tb呼吸.MaxLength = 10;
            this.tb呼吸.Name = "tb呼吸";
            this.tb呼吸.Size = new System.Drawing.Size(88, 21);
            this.tb呼吸.TabIndex = 1;
            this.tb呼吸.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtpbeginDate_KeyUp);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 76;
            this.label4.Text = "呼吸：";
            // 
            // tb脉搏
            // 
            this.tb脉搏.Location = new System.Drawing.Point(438, 48);
            this.tb脉搏.MaxLength = 10;
            this.tb脉搏.Name = "tb脉搏";
            this.tb脉搏.Size = new System.Drawing.Size(88, 21);
            this.tb脉搏.TabIndex = 4;
            this.tb脉搏.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtpbeginDate_KeyUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(398, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 74;
            this.label3.Text = "脉搏：";
            // 
            // tb体温
            // 
            this.tb体温.Location = new System.Drawing.Point(308, 48);
            this.tb体温.MaxLength = 10;
            this.tb体温.Name = "tb体温";
            this.tb体温.Size = new System.Drawing.Size(88, 21);
            this.tb体温.TabIndex = 3;
            this.tb体温.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtpbeginDate_KeyUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(268, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 72;
            this.label2.Text = "体温：";
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(48, 16);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(152, 23);
            this.DtpbeginDate.TabIndex = 0;
            this.DtpbeginDate.Value = new System.DateTime(2003, 9, 20, 19, 22, 0, 0);
            this.DtpbeginDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtpbeginDate_KeyUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 70;
            this.label1.Text = "日期：";
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
            this.btCancel.Location = new System.Drawing.Point(680, 200);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 32);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
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
            this.bt保存.Location = new System.Drawing.Point(464, 200);
            this.bt保存.Name = "bt保存";
            this.bt保存.Size = new System.Drawing.Size(64, 32);
            this.bt保存.TabIndex = 0;
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
            this.button3.Location = new System.Drawing.Point(384, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(368, 48);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 621);
            this.panel2.TabIndex = 0;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "四测记录";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(760, 621);
            this.myDataGrid1.TabIndex = 58;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Tag = "";
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid2.CaptionText = "病人信息";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size(168, 621);
            this.myDataGrid2.TabIndex = 23;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.myDataGrid2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(168, 621);
            this.panel5.TabIndex = 56;
            // 
            // panel总
            // 
            this.panel总.Controls.Add(this.splitter2);
            this.panel总.Controls.Add(this.panel1);
            this.panel总.Controls.Add(this.panel5);
            this.panel总.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel总.Location = new System.Drawing.Point(0, 0);
            this.panel总.Name = "panel总";
            this.panel总.Size = new System.Drawing.Size(928, 621);
            this.panel总.TabIndex = 57;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(168, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 621);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // frmSCJL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(928, 621);
            this.Controls.Add(this.panel总);
            this.Name = "frmSCJL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "四测记录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSCD_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel总.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        private void frmSCD_Load(object sender, System.EventArgs e)
        {
            //查出本科室的病人信息
            string strSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_Bed " +
                "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY dbo.Fun_GetBedToOrder( (case when left( bed_no,1)='+' then '999'+ bed_no else  bed_no end) ),Baby_ID";
            string[] GrdMappingName2 ={ "床号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
            int[] GrdWidth2 ={ 6, 12, 0, 0, 0, 0 };
            int[] Alignment2 ={ 1, 0, 0, 0, 0, 0 };
            myFunc.InitGridSQL(strSql, GrdMappingName2, GrdWidth2, Alignment2, this.myDataGrid2);
            myFunc.SelectBin(true, this.myDataGrid2, 2, 3, 4, 5);

            this.Show_Date();

            string[] GrdMappingName1 ={ "日期", "时间", "体温", "脉搏", "呼吸", "血压", "SPO2", "备注", "护士", "date", "operator", "id" };
            int[] GrdWidth1 ={ 6, 6, 6, 6, 6, 10, 6, 30, 8, 0, 0, 0 };
            int[] Alignment1 ={ 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);
            PubStaticFun.ModifyDataGridStyle(this.myDataGrid1, 0);

            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            this.DtpbeginDate.Focus();
        }

        private void Show_Date()
        {
            string sSql = "select   case when len(rtrim(convert(varchar,datepart(dd,date))))=2 then  rtrim(convert(varchar,datepart(mm,date)))+'-'+rtrim(convert(varchar,datepart(dd,date)))  else rtrim(convert(varchar,datepart(mm,date)))+'-0'+rtrim(convert(varchar,datepart(dd,date))) end 日期, " +
                        "case when len(rtrim(convert(varchar,datepart(mi,date))))=2 then rtrim(convert(varchar,datepart(hh,date)))+':'+rtrim(convert(varchar,datepart(mi,date))) else  rtrim(convert(varchar,datepart(hh,date)))+':0'+rtrim(convert(varchar,datepart(mi,date))) end 时间," +
                        "tw 体温 ,mb 脉搏 ,hx 呼吸 ,xy 血压 ,spo2 SPO2 ,bz 备注 , dbo.fun_zy_SeekEmployeeName(OPERATOR) 护士,date, operator,id" +
                        " from zy_scjl" +
                        " where inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                        " order by date";
            myFunc.ShowGrid(0, sSql, this.myDataGrid1);
            PubStaticFun.ModifyDataGridStyle(this.myDataGrid1, 0);

            int iDay = 0;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb.Rows.Count != 0)
            {
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (i != 0)
                    {
                        if (myTb.Rows[i]["日期"].ToString().Trim() == myTb.Rows[iDay]["日期"].ToString().Trim())
                        {
                            myTb.Rows[i]["日期"] = System.DBNull.Value;
                        }
                        else
                        {
                            iDay = i;
                        }
                    }
                }
                myFunc.SelRow(this.myDataGrid1);
            }

            DataTable binTb = GetPatInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
            if (binTb.Rows.Count == 0)
            {
                return;
            }

            lblName.Text = binTb.Rows[0]["name"].ToString();
            lblDept.Text = binTb.Rows[0]["cur_dept_name"].ToString();
            lblWard.Text = binTb.Rows[0]["ward_name"].ToString();
            lblBed.Text = binTb.Rows[0]["bed_no"].ToString();
            lblZyh.Text = binTb.Rows[0]["inpatient_no"].ToString();
        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }

        private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = this.myDataGrid1.CurrentCell.RowNumber;

            //Add By Tany 2005-07-04
            //护士长和组长护士可以操作
            if (myFunc.IsHSZ(InstanceForm.BCurrentUser.EmployeeId) == false
                && myFunc.IsZZHS(InstanceForm.BCurrentUser.EmployeeId) == false)
            {
                //不是当前护士不能修改
                if (myTb.Rows[nrow]["operator"].ToString().Trim() != InstanceForm.BCurrentUser.EmployeeId.ToString().Trim())
                {
                    MessageBox.Show(this, "对不起，您无权利修改！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            this.DtpbeginDate.Value = Convert.ToDateTime(myTb.Rows[nrow]["date"]);
            this.tb体温.Text = myTb.Rows[nrow]["体温"].ToString().Trim();
            this.tb脉搏.Text = myTb.Rows[nrow]["脉搏"].ToString().Trim();
            this.tb呼吸.Text = myTb.Rows[nrow]["呼吸"].ToString().Trim();
            this.tb血压.Text = myTb.Rows[nrow]["血压"].ToString().Trim();
            this.tbSPO2.Text = myTb.Rows[nrow]["SPO2"].ToString().Trim();
            this.tb备注.Text = myTb.Rows[nrow]["备注"].ToString().Trim();
        }


        private void bt保存_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.tb体温.Text.Trim() == "" && this.tb脉搏.Text.Trim() == "" && this.tb呼吸.Text.Trim() == "" && this.tb血压.Text.Trim() == "" && this.tb备注.Text.Trim() == "")
            {
                MessageBox.Show(this, "对不起，没有数据！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DtpbeginDate.Value = Convert.ToDateTime(this.DtpbeginDate.Value.ToShortDateString() + " " + this.DtpbeginDate.Value.Hour.ToString() + ":" + this.DtpbeginDate.Value.Minute.ToString() + ":00");

            string sSql = "select id from zy_scjl " +
                " where inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                "       and date='" + this.DtpbeginDate.Value + "'";
            DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
            if (tempTab.Rows.Count > 0)
            {
                if (MessageBox.Show(this, "确认覆盖" + this.DtpbeginDate.Value.ToString() + "的记录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                sSql = "update zy_scjl " +
                    "   set  tw='" + this.tb体温.Text.Trim() + "'," +
                    "        mb='" + this.tb脉搏.Text.Trim() + "'," +
                    "        hx='" + this.tb呼吸.Text.Trim() + "'," +
                    "        xy='" + this.tb血压.Text.Trim() + "'," +
                    "        spo2='" + this.tbSPO2.Text.Trim() + "'," +
                    "        bz='  " + this.tb备注.Text.Trim() + "'" +
                    " where id='" + tempTab.Rows[0]["id"].ToString().Trim() + "'";
            }
            else
            {
                if (MessageBox.Show(this, "确认增加" + this.DtpbeginDate.Value.ToString() + "的记录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                sSql = "insert into zy_scjl (id,inpatient_id,baby_id,date,tw,mb,hx,xy,spo2,bz,operator,jgbm)" +
                      " values('" + PubStaticFun.NewGuid() + "','" + ClassStatic.Current_BinID + "'," + ClassStatic.Current_BabyID + ",'" + this.DtpbeginDate.Value.ToString() + "'," +
                      "'" + this.tb体温.Text.Trim() + "'," +
                      "'" + this.tb脉搏.Text.Trim() + "'," +
                      "'" + this.tb呼吸.Text.Trim() + "'," +
                      "'" + this.tb血压.Text.Trim() + "'," +
                      "'" + this.tbSPO2.Text.Trim() + "'," +
                      "'  " + this.tb备注.Text.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";
            }
            InstanceForm.BDatabase.DoCommand(sSql);

            bt新建_Click(sender, e);
        }


        private void bt删除_Click(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = this.myDataGrid1.CurrentCell.RowNumber;

            //不是当前护士不能删除
            //			if  (myTb.Rows[nrow]["operator"].ToString().Trim()!=InstanceForm.BCurrentUser.EmployeeId) 
            //			{
            //				MessageBox.Show(this,"对不起，您无权利删除！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //				return;
            //			}		

            if (MessageBox.Show(this, "确认删除" + myTb.Rows[nrow]["date"].ToString().Trim() + "的记录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            string sSql = "delete from zy_scjl where id='" + myTb.Rows[nrow]["id"].ToString().Trim() + "'";
            InstanceForm.BDatabase.DoCommand(sSql);

            bt新建_Click(sender, e);
        }


        private void bt打印_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            DataTable prtTb = myTb.Copy();
            prtTb.TableName = "tabscjl";
            DataSet rs = new DataSet();
            rs.Tables.Add(prtTb);

            string sSql = "SELECT BED_NO,NAME,INPATIENT_NO,CUR_DEPT_NAME" +
                        "  from vi_zy_vInpatient_All" +
                        " where inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
            DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);

            FrmReportView frmRptView = null;
            ParameterEx[] _parameters = new ParameterEx[7];

            _parameters[0].Text = "Title";
            _parameters[0].Value = (new SystemCfg(0002)).Config;
            _parameters[1].Text = "病区";
            _parameters[1].Value = InstanceForm.BCurrentDept.WardName;
            _parameters[2].Text = "姓名";
            _parameters[2].Value = tempTab.Rows[0]["NAME"];
            _parameters[3].Text = "住院号";
            _parameters[3].Value = tempTab.Rows[0]["INPATIENT_NO"];
            _parameters[4].Text = "科别";
            _parameters[4].Value = tempTab.Rows[0]["CUR_DEPT_NAME"];
            _parameters[5].Text = "床号";
            _parameters[5].Value = tempTab.Rows[0]["BED_NO"];
            _parameters[6].Text = "打印护士";
            _parameters[6].Value = InstanceForm.BCurrentUser.Name;

            frmRptView = new FrmReportView(rs, Constant.ApplicationDirectory + "\\report\\ZYHS_四测记录.rpt", _parameters);
            frmRptView.Show();
        }

        private void DtpbeginDate_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private DataTable GetPatInfo(Guid inpatient_id, long baby_id)
        {
            //获取病人的基本信息
            string sqlStr = "";
            DataTable dbTb = new DataTable();
            sqlStr = @"select a.name,a.cur_dept_name,a.bed_no,a.inpatient_no,b.ward_name from vi_zy_vINPATIENT_ALL a,jc_WARD b where a.ward_id=b.ward_id and a.inpatient_id='" + inpatient_id + "' and a.baby_id=" + baby_id;
            dbTb = InstanceForm.BDatabase.GetDataTable(sqlStr);
            return dbTb;
        }

        private void btnSeek_Click(object sender, System.EventArgs e)
        {
            //Modify by tany 2011-05-12
            //if (txtInpatNo.Text.Trim() == "")
            //    txtInpatNo.Text = "0";

            //string sSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
            //    "   FROM vi_zy_vInpatient_All " +
            //    "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and inpatient_no='" + txtInpatNo.Text.Trim() + "'" +
            //    "  order by baby_id";
            //DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            //if (myTb == null || myTb.Rows.Count == 0)
            //{
            //    MessageBox.Show("没有找到该病人信息，请核对住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //comboBox1.Items.Clear();

            //for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            //{
            //    ClassStatic.MYTS_Name[i] = myTb.Rows[i]["姓名"].ToString().Trim();
            //    ClassStatic.MYTS_BabyID[i] = myTb.Rows[i]["BABY_ID"].ToString().Trim();
            //    ClassStatic.MYTS_BinID[i] = new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString().Trim());
            //    comboBox1.Items.Add(ClassStatic.MYTS_Name[i]);
            //    if (Convert.ToInt64(ClassStatic.MYTS_BabyID[i]) == ClassStatic.Current_BabyID)
            //    {
            //        comboBox1.Text = ClassStatic.MYTS_Name[i];
            //    }
            //}

            //comboBox1.SelectedIndex = 0;

            //ClassStatic.Current_BinID = new Guid(myTb.Rows[0]["INPATIENT_ID"].ToString().Trim());
            //ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);
            //ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[0]["DEPT_ID"].ToString().Trim());
            //ClassStatic.Current_isMY = Convert.ToInt32(myTb.Rows[0]["isMY"].ToString().Trim());

            string inpatientNo = "";
            Guid inpatientId = Guid.Empty;
            int babyId = 0;

            DlgInpatients dlgInpatients = new DlgInpatients();
            dlgInpatients = new DlgInpatients(InstanceForm.BCurrentDept.WardId);

            if (txtInpatNo.Text.Trim() != "" && txtInpatNo.Text != InpatientNo.GetEmptyZyh())
            {
                dlgInpatients.txtZyh.Text = txtInpatNo.Text.Trim();
                dlgInpatients.tabControl1.SelectedTab = dlgInpatients.tpZyh;
                dlgInpatients.cmbDept.SelectedIndex = -1;
                DlgInpatients.SelectedDeptID = -1;
                dlgInpatients.rbAll.Enabled = true;
                dlgInpatients.rbAll.Checked = true;
                dlgInpatients.txtZyh_KeyPress(null, new KeyPressEventArgs((char)13));
            }
            dlgInpatients.ShowDialog();

            inpatientNo = DlgInpatients.SelectedInpatientNO;
            inpatientId = DlgInpatients.SelectedInpatientID;
            babyId = DlgInpatients.SelectedBabyID;
            if (inpatientNo != "" && inpatientId != Guid.Empty)
            {
                ClassStatic.Current_BinID = inpatientId;
                ClassStatic.Current_BabyID = babyId;
            }
            else
            {
                return;
            }

            myDataGrid2.UnSelect(myDataGrid2.CurrentCell.RowNumber);

            Show_Date();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ClassStatic.Current_BinID = ClassStatic.MYTS_BinID[comboBox1.SelectedIndex];
            ClassStatic.Current_BabyID = Convert.ToInt64(ClassStatic.MYTS_BabyID[comboBox1.SelectedIndex]);

            Show_Date();
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

        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);
            ClassStatic.Current_BinID = new Guid(this.myDataGrid2[nrow, 2].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(this.myDataGrid2[nrow, 3]);
            ClassStatic.Current_DeptID = Convert.ToInt64(this.myDataGrid2[nrow, 4]);
            ClassStatic.Current_isMY = Convert.ToInt16(this.myDataGrid2[nrow, 5]);

            Show_Date();
        }

        private void bt新建_Click(object sender, System.EventArgs e)
        {
            tbSPO2.Text = "";
            tb体温.Text = "";
            tb备注.Text = "";
            tb脉搏.Text = "";
            tb血压.Text = "";
            tb呼吸.Text = "";

            this.Show_Date();

            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            this.DtpbeginDate.Focus();
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}