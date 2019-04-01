using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_mz_class;
using Ts_Visit_Class;
using ts_mzys_class;

namespace ts_mz_gh
{
	/// <summary>
	/// FrmTfq 的摘要说明。
	/// </summary>
	public class FrmTfq : System.Windows.Forms.Form
	{
		//自定义局部变量
        private DataTable  TbFp =null;//发票记录
        private DataTable TbGhxx = null;//挂号信息
        private ReadCard readcard;//读卡类

        private ts_yb_mzgl.JSXX jsxx = new ts_yb_mzgl.JSXX();
        private ts_yb_mzgl.BRXX brxx = new ts_yb_mzgl.BRXX();

        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnQd;
		private System.Windows.Forms.Button btnGb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
		private BindingManagerBase myBind ;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label lblFph;
		private System.Windows.Forms.Label lblHzxm;
		private System.Windows.Forms.Label lblKsmc;
		private System.Windows.Forms.Label lblYsxm;
        private System.Windows.Forms.Label lblJe;
		private System.Windows.Forms.Label lblGhrq;
		private System.Windows.Forms.Label lblYsjb;
		private System.Windows.Forms.Label lblCzy;
		private System.Windows.Forms.Label label13;
        private Label label3;
        private Label lbltje;
        private Panel panel2;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private TextBox txtinput;
        private Label lblcwjz;
        private Label label20;
        private Label lblqfgz;
        private Label label18;
        private Label lblybzf;
        private Label label16;
        private Label lblsrje;
        private Label label14;
        private Label lblyhje;
        private Label label5;
        private Label label21;
        private Label lblylzf;
        private Label lblxjzf;
        private Label label23;
        private string YLKKTF = "";
        private string YLKTXJ = "";
        private string CWJZKTF = "";
        private string CWJZTXJ = "";
        private decimal zje = 0;
        private decimal yhje = 0;
        private decimal srje = 0;
        private decimal ybjjzf = 0;
        private decimal ybzhzf = 0;
        private decimal ybbzzf = 0;
        private decimal qfgz = 0;
        private decimal cwjz = 0;
        private decimal ylkzf = 0;
        private decimal xjzf = 0;
        private Label lblklx;
        private Label label12;
        private Label lblkh;
        private Label label17;
        private Label lblybkye;
        private Button butreadcard;
        private Label label1;
        private ComboBox cmbyblx;
        private Label label27;
        private Button butxtk;
        private Label lbltk;
        private Label lblyhlx;
        private Label label19;
        private DataGridView dgvDetail;
        private Label lblMxzje;
        private Label label15;
        private Label label22;
        private DataGridViewTextBoxColumn COL_ITEM_NAME;
        private DataGridViewTextBoxColumn COL_COST;
        private TextBox txtDnlsh;
        private Label label24;
        private Label label26;
        private Label label25;
        private TextBox txtKh;
        private ComboBox cboKlx;
        public SystemCfg _cfg1099 = new SystemCfg(1099);//门诊是否启用分时段挂号 0不启用 1启用 默认为0 Add by zp 2013-11-08
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        public FrmTfq(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();


            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQd = new System.Windows.Forms.Button();
            this.btnGb = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblyhlx = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lbltk = new System.Windows.Forms.Label();
            this.lblkh = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblklx = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblxjzf = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblylzf = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblcwjz = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblqfgz = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblybzf = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblsrje = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblyhje = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCzy = new System.Windows.Forms.Label();
            this.lbltje = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblYsjb = new System.Windows.Forms.Label();
            this.lblJe = new System.Windows.Forms.Label();
            this.lblGhrq = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblYsxm = new System.Windows.Forms.Label();
            this.lblKsmc = new System.Windows.Forms.Label();
            this.lblHzxm = new System.Windows.Forms.Label();
            this.lblFph = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKh = new System.Windows.Forms.TextBox();
            this.cboKlx = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtDnlsh = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.butxtk = new System.Windows.Forms.Button();
            this.lblybkye = new System.Windows.Forms.Label();
            this.butreadcard = new System.Windows.Forms.Button();
            this.txtinput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbyblx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.lblMxzje = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.COL_ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_COST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnQd);
            this.panel1.Controls.Add(this.btnGb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 45);
            this.panel1.TabIndex = 0;
            // 
            // btnQd
            // 
            this.btnQd.Location = new System.Drawing.Point(266, 6);
            this.btnQd.Name = "btnQd";
            this.btnQd.Size = new System.Drawing.Size(74, 24);
            this.btnQd.TabIndex = 1;
            this.btnQd.Text = "退签(&O)";
            this.btnQd.Click += new System.EventHandler(this.btnQd_Click);
            // 
            // btnGb
            // 
            this.btnGb.Location = new System.Drawing.Point(376, 6);
            this.btnGb.Name = "btnGb";
            this.btnGb.Size = new System.Drawing.Size(74, 24);
            this.btnGb.TabIndex = 2;
            this.btnGb.Text = "关闭(&Q)";
            this.btnGb.Click += new System.EventHandler(this.btnGb_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 381);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(702, 95);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "说明";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(696, 75);
            this.richTextBox1.TabIndex = 155;
            this.richTextBox1.Text = "退签与作废挂号签区别在于：\n    在初诊的情况下，退签通常只退挂号费不退病历和诊疗卡，而作废挂号签则必须同时作废对应的病历和诊疗卡；而在复诊的情况下，两者则是完" +
                "全相同的，系统缺省当退签处理。";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblyhlx);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.lbltk);
            this.groupBox4.Controls.Add(this.lblkh);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.lblklx);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.lblxjzf);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.lblylzf);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.lblcwjz);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.lblqfgz);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.lblybzf);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.lblsrje);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.lblyhje);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.lblCzy);
            this.groupBox4.Controls.Add(this.lbltje);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.lblYsjb);
            this.groupBox4.Controls.Add(this.lblJe);
            this.groupBox4.Controls.Add(this.lblGhrq);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.lblYsxm);
            this.groupBox4.Controls.Add(this.lblKsmc);
            this.groupBox4.Controls.Add(this.lblHzxm);
            this.groupBox4.Controls.Add(this.lblFph);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(406, 300);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发票信息";
            // 
            // lblyhlx
            // 
            this.lblyhlx.BackColor = System.Drawing.Color.LightCyan;
            this.lblyhlx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblyhlx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblyhlx.ForeColor = System.Drawing.Color.Blue;
            this.lblyhlx.Location = new System.Drawing.Point(280, 206);
            this.lblyhlx.Name = "lblyhlx";
            this.lblyhlx.Size = new System.Drawing.Size(118, 22);
            this.lblyhlx.TabIndex = 40;
            this.lblyhlx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(207, 210);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 16);
            this.label19.TabIndex = 39;
            this.label19.Text = "优惠类型";
            // 
            // lbltk
            // 
            this.lbltk.BackColor = System.Drawing.SystemColors.Control;
            this.lbltk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbltk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltk.ForeColor = System.Drawing.Color.Red;
            this.lbltk.Location = new System.Drawing.Point(210, 262);
            this.lbltk.Name = "lbltk";
            this.lbltk.Size = new System.Drawing.Size(187, 22);
            this.lbltk.TabIndex = 38;
            this.lbltk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbltk.Visible = false;
            // 
            // lblkh
            // 
            this.lblkh.BackColor = System.Drawing.Color.LightCyan;
            this.lblkh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblkh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblkh.Location = new System.Drawing.Point(82, 262);
            this.lblkh.Name = "lblkh";
            this.lblkh.Size = new System.Drawing.Size(120, 22);
            this.lblkh.TabIndex = 37;
            this.lblkh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(38, 264);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 16);
            this.label17.TabIndex = 36;
            this.label17.Text = "卡号";
            // 
            // lblklx
            // 
            this.lblklx.BackColor = System.Drawing.Color.LightCyan;
            this.lblklx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblklx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblklx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblklx.Location = new System.Drawing.Point(82, 234);
            this.lblklx.Name = "lblklx";
            this.lblklx.Size = new System.Drawing.Size(120, 22);
            this.lblklx.TabIndex = 35;
            this.lblklx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(22, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "卡类型";
            // 
            // lblxjzf
            // 
            this.lblxjzf.BackColor = System.Drawing.Color.LightCyan;
            this.lblxjzf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxjzf.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxjzf.ForeColor = System.Drawing.Color.Blue;
            this.lblxjzf.Location = new System.Drawing.Point(279, 177);
            this.lblxjzf.Name = "lblxjzf";
            this.lblxjzf.Size = new System.Drawing.Size(118, 22);
            this.lblxjzf.TabIndex = 33;
            this.lblxjzf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(206, 181);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 16);
            this.label23.TabIndex = 32;
            this.label23.Text = "现金支付";
            // 
            // lblylzf
            // 
            this.lblylzf.BackColor = System.Drawing.Color.LightCyan;
            this.lblylzf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblylzf.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblylzf.ForeColor = System.Drawing.Color.Blue;
            this.lblylzf.Location = new System.Drawing.Point(279, 150);
            this.lblylzf.Name = "lblylzf";
            this.lblylzf.Size = new System.Drawing.Size(118, 22);
            this.lblylzf.TabIndex = 31;
            this.lblylzf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(206, 154);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 16);
            this.label21.TabIndex = 30;
            this.label21.Text = "银联支付";
            // 
            // lblcwjz
            // 
            this.lblcwjz.BackColor = System.Drawing.Color.LightCyan;
            this.lblcwjz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcwjz.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcwjz.ForeColor = System.Drawing.Color.Blue;
            this.lblcwjz.Location = new System.Drawing.Point(279, 123);
            this.lblcwjz.Name = "lblcwjz";
            this.lblcwjz.Size = new System.Drawing.Size(118, 22);
            this.lblcwjz.TabIndex = 29;
            this.lblcwjz.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(206, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 16);
            this.label20.TabIndex = 28;
            this.label20.Text = "欠费挂账";
            // 
            // lblqfgz
            // 
            this.lblqfgz.BackColor = System.Drawing.Color.LightCyan;
            this.lblqfgz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblqfgz.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblqfgz.ForeColor = System.Drawing.Color.Blue;
            this.lblqfgz.Location = new System.Drawing.Point(279, 96);
            this.lblqfgz.Name = "lblqfgz";
            this.lblqfgz.Size = new System.Drawing.Size(118, 22);
            this.lblqfgz.TabIndex = 27;
            this.lblqfgz.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(206, 128);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 16);
            this.label18.TabIndex = 26;
            this.label18.Text = "财务记帐";
            // 
            // lblybzf
            // 
            this.lblybzf.BackColor = System.Drawing.Color.LightCyan;
            this.lblybzf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblybzf.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblybzf.ForeColor = System.Drawing.Color.Blue;
            this.lblybzf.Location = new System.Drawing.Point(279, 70);
            this.lblybzf.Name = "lblybzf";
            this.lblybzf.Size = new System.Drawing.Size(118, 22);
            this.lblybzf.TabIndex = 25;
            this.lblybzf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(206, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 24;
            this.label16.Text = "医保支付";
            // 
            // lblsrje
            // 
            this.lblsrje.BackColor = System.Drawing.Color.LightCyan;
            this.lblsrje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsrje.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsrje.ForeColor = System.Drawing.Color.Blue;
            this.lblsrje.Location = new System.Drawing.Point(279, 44);
            this.lblsrje.Name = "lblsrje";
            this.lblsrje.Size = new System.Drawing.Size(118, 22);
            this.lblsrje.TabIndex = 23;
            this.lblsrje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(206, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 22;
            this.label14.Text = "舍入金额";
            // 
            // lblyhje
            // 
            this.lblyhje.BackColor = System.Drawing.Color.LightCyan;
            this.lblyhje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblyhje.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblyhje.ForeColor = System.Drawing.Color.Blue;
            this.lblyhje.Location = new System.Drawing.Point(279, 17);
            this.lblyhje.Name = "lblyhje";
            this.lblyhje.Size = new System.Drawing.Size(118, 22);
            this.lblyhje.TabIndex = 21;
            this.lblyhje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "优惠金额";
            // 
            // lblCzy
            // 
            this.lblCzy.BackColor = System.Drawing.Color.LightCyan;
            this.lblCzy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCzy.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCzy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCzy.Location = new System.Drawing.Point(82, 177);
            this.lblCzy.Name = "lblCzy";
            this.lblCzy.Size = new System.Drawing.Size(120, 22);
            this.lblCzy.TabIndex = 19;
            this.lblCzy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltje
            // 
            this.lbltje.BackColor = System.Drawing.SystemColors.Control;
            this.lbltje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbltje.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltje.ForeColor = System.Drawing.Color.Red;
            this.lbltje.Location = new System.Drawing.Point(279, 236);
            this.lbltje.Name = "lbltje";
            this.lbltje.Size = new System.Drawing.Size(118, 22);
            this.lbltje.TabIndex = 1;
            this.lbltje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(22, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 18;
            this.label13.Text = "操作员";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(206, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "应退现金";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYsjb
            // 
            this.lblYsjb.BackColor = System.Drawing.Color.LightCyan;
            this.lblYsjb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblYsjb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYsjb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblYsjb.Location = new System.Drawing.Point(82, 123);
            this.lblYsjb.Name = "lblYsjb";
            this.lblYsjb.Size = new System.Drawing.Size(120, 22);
            this.lblYsjb.TabIndex = 17;
            this.lblYsjb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJe
            // 
            this.lblJe.BackColor = System.Drawing.Color.LightCyan;
            this.lblJe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblJe.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblJe.Location = new System.Drawing.Point(82, 205);
            this.lblJe.Name = "lblJe";
            this.lblJe.Size = new System.Drawing.Size(120, 22);
            this.lblJe.TabIndex = 14;
            this.lblJe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGhrq
            // 
            this.lblGhrq.BackColor = System.Drawing.Color.LightCyan;
            this.lblGhrq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGhrq.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhrq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblGhrq.Location = new System.Drawing.Point(82, 150);
            this.lblGhrq.Name = "lblGhrq";
            this.lblGhrq.Size = new System.Drawing.Size(120, 22);
            this.lblGhrq.TabIndex = 16;
            this.lblGhrq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "所收金额";
            // 
            // lblYsxm
            // 
            this.lblYsxm.BackColor = System.Drawing.Color.LightCyan;
            this.lblYsxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblYsxm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYsxm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblYsxm.Location = new System.Drawing.Point(82, 96);
            this.lblYsxm.Name = "lblYsxm";
            this.lblYsxm.Size = new System.Drawing.Size(120, 22);
            this.lblYsxm.TabIndex = 13;
            this.lblYsxm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKsmc
            // 
            this.lblKsmc.BackColor = System.Drawing.Color.LightCyan;
            this.lblKsmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKsmc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKsmc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblKsmc.Location = new System.Drawing.Point(82, 70);
            this.lblKsmc.Name = "lblKsmc";
            this.lblKsmc.Size = new System.Drawing.Size(120, 22);
            this.lblKsmc.TabIndex = 12;
            this.lblKsmc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHzxm
            // 
            this.lblHzxm.BackColor = System.Drawing.Color.LightCyan;
            this.lblHzxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHzxm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHzxm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHzxm.Location = new System.Drawing.Point(82, 44);
            this.lblHzxm.Name = "lblHzxm";
            this.lblHzxm.Size = new System.Drawing.Size(120, 22);
            this.lblHzxm.TabIndex = 11;
            this.lblHzxm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFph
            // 
            this.lblFph.BackColor = System.Drawing.Color.LightCyan;
            this.lblFph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFph.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFph.Location = new System.Drawing.Point(82, 17);
            this.lblFph.Name = "lblFph";
            this.lblFph.Size = new System.Drawing.Size(120, 22);
            this.lblFph.TabIndex = 10;
            this.lblFph.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "发票号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "所挂医生";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "病人姓名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "所挂科室";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "所挂级别";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "挂号日期";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtKh);
            this.groupBox2.Controls.Add(this.cboKlx);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txtDnlsh);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.butxtk);
            this.groupBox2.Controls.Add(this.lblybkye);
            this.groupBox2.Controls.Add(this.butreadcard);
            this.groupBox2.Controls.Add(this.txtinput);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbyblx);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 81);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选项";
            // 
            // txtKh
            // 
            this.txtKh.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Bold);
            this.txtKh.Location = new System.Drawing.Point(561, 49);
            this.txtKh.Name = "txtKh";
            this.txtKh.Size = new System.Drawing.Size(131, 25);
            this.txtKh.TabIndex = 106;
            this.txtKh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKh_KeyPress);
            this.txtKh.Enter += new System.EventHandler(this.Language_Off);
            // 
            // cboKlx
            // 
            this.cboKlx.Font = new System.Drawing.Font("宋体", 11.5F);
            this.cboKlx.FormattingEnabled = true;
            this.cboKlx.Location = new System.Drawing.Point(561, 17);
            this.cboKlx.Name = "cboKlx";
            this.cboKlx.Size = new System.Drawing.Size(131, 23);
            this.cboKlx.TabIndex = 105;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(499, 54);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 16);
            this.label26.TabIndex = 104;
            this.label26.Text = "卡  号";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(499, 19);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 103;
            this.label25.Text = "卡类型";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDnlsh
            // 
            this.txtDnlsh.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Bold);
            this.txtDnlsh.Location = new System.Drawing.Point(349, 17);
            this.txtDnlsh.Name = "txtDnlsh";
            this.txtDnlsh.Size = new System.Drawing.Size(144, 25);
            this.txtDnlsh.TabIndex = 102;
            this.txtDnlsh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDnlsh_KeyPress);
            this.txtDnlsh.Enter += new System.EventHandler(this.Language_Off);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(252, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 16);
            this.label24.TabIndex = 101;
            this.label24.Text = "电脑流水号：";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butxtk
            // 
            this.butxtk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butxtk.Location = new System.Drawing.Point(246, 49);
            this.butxtk.Name = "butxtk";
            this.butxtk.Size = new System.Drawing.Size(32, 23);
            this.butxtk.TabIndex = 100;
            this.butxtk.Text = "效";
            this.butxtk.UseVisualStyleBackColor = true;
            this.butxtk.Click += new System.EventHandler(this.butxtk_Click);
            // 
            // lblybkye
            // 
            this.lblybkye.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblybkye.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblybkye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblybkye.Location = new System.Drawing.Point(377, 50);
            this.lblybkye.Name = "lblybkye";
            this.lblybkye.Size = new System.Drawing.Size(116, 22);
            this.lblybkye.TabIndex = 81;
            this.lblybkye.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butreadcard
            // 
            this.butreadcard.BackColor = System.Drawing.SystemColors.Control;
            this.butreadcard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butreadcard.Location = new System.Drawing.Point(198, 49);
            this.butreadcard.Name = "butreadcard";
            this.butreadcard.Size = new System.Drawing.Size(46, 23);
            this.butreadcard.TabIndex = 78;
            this.butreadcard.Text = "读卡";
            this.butreadcard.UseVisualStyleBackColor = false;
            this.butreadcard.Click += new System.EventHandler(this.butreadcard_Click);
            // 
            // txtinput
            // 
            this.txtinput.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Bold);
            this.txtinput.Location = new System.Drawing.Point(115, 17);
            this.txtinput.Name = "txtinput";
            this.txtinput.Size = new System.Drawing.Size(131, 25);
            this.txtinput.TabIndex = 0;
            this.txtinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinput_KeyPress);
            this.txtinput.Enter += new System.EventHandler(this.Language_Off);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(280, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 80;
            this.label1.Text = "医保卡余额：";
            // 
            // cmbyblx
            // 
            this.cmbyblx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyblx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbyblx.ForeColor = System.Drawing.Color.Navy;
            this.cmbyblx.FormattingEnabled = true;
            this.cmbyblx.Location = new System.Drawing.Point(79, 49);
            this.cmbyblx.Name = "cmbyblx";
            this.cmbyblx.Size = new System.Drawing.Size(116, 22);
            this.cmbyblx.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "挂号票(F12)：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(10, 52);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(77, 14);
            this.label27.TabIndex = 79;
            this.label27.Text = "医保类型：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.lblMxzje);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.dgvDetail);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 300);
            this.panel2.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(594, 288);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 2);
            this.label22.TabIndex = 23;
            // 
            // lblMxzje
            // 
            this.lblMxzje.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMxzje.Location = new System.Drawing.Point(597, 270);
            this.lblMxzje.Name = "lblMxzje";
            this.lblMxzje.Size = new System.Drawing.Size(72, 16);
            this.lblMxzje.TabIndex = 22;
            this.lblMxzje.Text = "0.00";
            this.lblMxzje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(509, 269);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 19);
            this.label15.TabIndex = 21;
            this.label15.Text = "合计金额";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ITEM_NAME,
            this.COL_COST});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetail.Location = new System.Drawing.Point(412, 7);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowHeadersWidth = 10;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(280, 255);
            this.dgvDetail.TabIndex = 11;
            // 
            // COL_ITEM_NAME
            // 
            this.COL_ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.COL_ITEM_NAME.DataPropertyName = "项目名称";
            this.COL_ITEM_NAME.HeaderText = "项目名称";
            this.COL_ITEM_NAME.Name = "COL_ITEM_NAME";
            this.COL_ITEM_NAME.ReadOnly = true;
            // 
            // COL_COST
            // 
            this.COL_COST.DataPropertyName = "金额";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.COL_COST.DefaultCellStyle = dataGridViewCellStyle2;
            this.COL_COST.HeaderText = "金额";
            this.COL_COST.Name = "COL_COST";
            this.COL_COST.ReadOnly = true;
            this.COL_COST.Width = 65;
            // 
            // FrmTfq
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(702, 521);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmTfq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "退签";
            this.Load += new System.EventHandler(this.FrmTfq_Load);
            this.Activated += new System.EventHandler(this.FrmTfq_Activated);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void Language_Off(object sender, System.EventArgs e)
        {
            //Control control = (Control)sender;

            //control.ImeMode = ImeMode.KatakanaHalf;
            //Fun.SetInputLanguageOff();
            Control control = (Control)sender;

            control.ImeMode = ImeMode.Close;
            Fun.SetInputLanguageOff();

        }

        private void Language_On(object sender, System.EventArgs e)
        {
            //Control control = (Control)sender;
            //control.ImeMode = ImeMode.KatakanaHalf;
            //Fun.SetInputLanguageOn();
            Control control = (Control)sender;

            control.ImeMode = ImeMode.On;
            //control.ImeMode = ImeMode.KatakanaHalf;
            Fun.SetInputLanguageOn();
        }

        private void ClearControl()
        {
            lblFph.Text="";
            lblHzxm.Text="";
            lblKsmc.Text="";
            lblYsxm.Text="";
            lblYsjb.Text="";
            lblGhrq.Text = "";
            lblCzy.Text="";
            lblJe.Text="";
            lbltje.Text="";
        }

        private void txtinput_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                btnQd.Enabled = false;
                bool bls = false;
                if ((int)e.KeyChar != 13) return;

                txtinput.Text = ToDBC(txtinput.Text);

                if (Convertor.IsNumeric(txtinput.Text.Trim()) == false)
                {
                    MessageBox.Show("请输入正确的发票号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //txtinput.Text = Fun.returnFph(txtinput.Text.Trim());
                string ssql = "select a.*,b.brxm from mz_ghxx A inner join YY_BRXX b on A.BRXXID=B.BRXXID where fph='" + txtinput.Text.Trim() + "'";
                TbGhxx = InstanceForm.BDatabase.GetDataTable(ssql);
                if (TbGhxx.Rows.Count == 0)
                {
                    ssql = "select a.*,b.brxm from mz_ghxx_h A inner join YY_BRXX b on A.BRXXID=B.BRXXID where fph='" + txtinput.Text.Trim() + "'";
                    TbGhxx = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (TbGhxx.Rows.Count > 0) bls = true;
                }
                if (TbGhxx.Rows.Count > 1)
                {
                    MessageBox.Show("找到两张同样的发票号，请和管理员联系", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TbGhxx = null;
                    return;
                }
                if (TbGhxx.Rows.Count == 0)
                {
                    MessageBox.Show("没有找到发票信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TbGhxx = null;
                    return;
                }
                if (Convert.ToInt16(TbGhxx.Rows[0]["bqxghbz"]) == 1)
                {
                    MessageBox.Show("此挂号票已作废", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TbGhxx = null;
                    return;
                }

                //找到原卡信息
                Guid  kdjid = new Guid (Convertor.IsNull(TbGhxx.Rows[0]["kdjid"],Guid.Empty.ToString()));
                readcard = new ReadCard(kdjid, InstanceForm.BDatabase);
                if (kdjid != readcard.kdjid)
                {
                    MessageBox.Show("没有找到原卡信息,原卡编号为" + kdjid.ToString() + ",找到的卡编号为" + readcard.kdjid.ToString() + ",请和管理人员联系", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TbGhxx = null;
                    return;
                }

                lblFph.Text = TbGhxx.Rows[0]["fph"].ToString();
                lblHzxm.Text = TbGhxx.Rows[0]["brxm"].ToString();
                lblKsmc.Text = Fun.SeekDeptName(Convert.ToInt32(TbGhxx.Rows[0]["ghks"]), InstanceForm.BDatabase);
                lblYsxm.Text = Fun.SeekEmpName(Convert.ToInt32(TbGhxx.Rows[0]["ghys"]), InstanceForm.BDatabase);
                lblYsjb.Text = Fun.SeekGhjbName(Convert.ToInt32(TbGhxx.Rows[0]["ghjb"]), InstanceForm.BDatabase);
                lblGhrq.Text = TbGhxx.Rows[0]["GHSJ"].ToString();
                lblCzy.Text = Fun.SeekEmpName(Convert.ToInt32(TbGhxx.Rows[0]["djy"]), InstanceForm.BDatabase);
                lblklx.Text = Fun.SeekKlxmc(readcard.klx, InstanceForm.BDatabase);
                lblkh.Text = readcard.kh;
                txtDnlsh.Text = TbGhxx.Rows[0]["DNLXH"].ToString();//Add by zp 2014-01-23
                lbltk.Visible = false;
                lbltk.Tag = "0";

                btnQd.Enabled = true;

                if (mz_hj.GetHj(new Guid(TbGhxx.Rows[0]["ghxxid"].ToString()), InstanceForm.BDatabase) == true)
                {
                    lbltk.Visible = true;
                    if (new SystemCfg(1033).Config == "1")
                    {
                        lbltk.Text = "请注意！病人已就诊";
                        btnQd.Enabled = true;
                    }
                    else
                    {
                        lbltk.Text = "病人已就诊,不能退签";
                        btnQd.Enabled = false;
                    }
                   
                }

                //退卡的处理
                if (readcard.kdjid !=Guid.Empty && readcard.kdjid!=null )
                {
                    mz_card card = new mz_card(readcard.klx, InstanceForm.BDatabase);
                    DataTable tbcf = mz_cf.SelectCardFee(new Guid(TbGhxx.Rows[0]["ghxxid"].ToString()), txtinput.Text, card.sfxmid, InstanceForm.BDatabase);
                    if (tbcf.Rows.Count > 0)
                    {
                        lbltk.Visible = true;
                        lbltk.Text = "退" + lblklx.Text + "一张";
                        lbltk.Tag = "999";
                    }
                }

                TbFp = mz_sf.SelectFp(new Guid(TbGhxx.Rows[0]["ghxxid"].ToString()), Convert.ToInt64(Convertor.IsNull(txtDnlsh.Text, "0")), txtinput.Text.Trim(), 1, InstanceForm.BDatabase);
                if (TbFp.Rows.Count == 0)
                {
                    MessageBox.Show("没有找到发票信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TbFp = null;
                    return;
                }
                try
                {
                    //Modify By zp 2013-10-14 以前不传输fpid导致会将收费的处方记录调阅出来
                    DataTable tbMx = SelectCf("", Guid.Empty, txtinput.Text, new Guid(TbFp.Rows[0]["fpid"].ToString()));//Guid.Empty
                    dgvDetail.AutoGenerateColumns = false;
                    dgvDetail.DataSource = tbMx;
                    object obj = tbMx.Compute( "SUM(金额)" , "" );
                    if ( obj != null )
                        lblMxzje.Text = obj.ToString();
                }
                catch ( Exception err_mx )
                {
                    MessageBox.Show( "获取明细发生错误！\r\n" + err_mx  , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                }


                zje = Convert.ToDecimal(TbFp.Rows[0]["zje"]);
                yhje = Convert.ToDecimal(TbFp.Rows[0]["YHJE"]);
                srje = Convert.ToDecimal(TbFp.Rows[0]["srje"]);
                ybjjzf = Convert.ToDecimal(TbFp.Rows[0]["ybjjzf"]);
                ybzhzf = Convert.ToDecimal(TbFp.Rows[0]["ybzhzf"]);
                ybbzzf = Convert.ToDecimal(TbFp.Rows[0]["ybbzzf"]);
                qfgz = Convert.ToDecimal(TbFp.Rows[0]["qfgz"]);
                cwjz = Convert.ToDecimal(TbFp.Rows[0]["cwjz"]);
                ylkzf = Convert.ToDecimal(TbFp.Rows[0]["ylkzf"]);
                xjzf = Convert.ToDecimal(TbFp.Rows[0]["xjzf"]);

                cmbyblx.SelectedValue = TbFp.Rows[0]["yblx"].ToString();

                decimal ybzf = ybjjzf + ybzhzf + ybbzzf;
                lblJe.Text = zje.ToString();
                lblyhje.Text = yhje > 0 ? yhje.ToString() : "";
                lblsrje.Text = srje != 0 ? srje.ToString() : "";
                lblybzf.Text = ybzf != 0 ? ybzf.ToString() : "";
                lblqfgz.Text = qfgz != 0 ? qfgz.ToString() : "";
                lblcwjz.Text = cwjz != 0 ? cwjz.ToString() : "";
                lblylzf.Text = ylkzf != 0 ? ylkzf.ToString() : "";
                lblxjzf.Text = xjzf != 0 ? xjzf.ToString() : "";
                lbltje.Text = xjzf.ToString();
                lblyhlx.Tag = Convertor.IsNull(TbFp.Rows[0]["yhlxid"],"0");
                lblyhlx.Text = Convertor.IsNull(TbFp.Rows[0]["yhlxmc"], "");

                if (bls == true)
                {
                    MessageBox.Show(" 数据已转移到历史库,不能办理退费,请咨询管理员！","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    btnQd.Enabled = false;
                    return;
                }
               

                if (ylkzf > 0 && YLKKTF != "true")
                {
                    MessageBox.Show("本张发票银联支付金额为:" + ylkzf.ToString("0.00") + "元,但系统在有银联支付信息的情况下不允许办理退费");
                    return;
                }
                if (cwjz > 0 && CWJZKTF != "true")
                {
                    MessageBox.Show("本张发票财务记帐金额为:" + cwjz.ToString("0.00") + "元,但系统在有财务记帐信息的情况下不允许办理退费");
                    return;
                }

                if (YLKTXJ == "true" && ylkzf > 0)
                {
                    xjzf = xjzf + ylkzf;
                    ylkzf = 0;
                }
                if (CWJZTXJ == "true" && cwjz > 0)
                {
                    xjzf = xjzf + cwjz;
                    cwjz = 0;
                }
                //if (CWJZTXJ == "true" && cwjz > 0)
                //{

                //    xjzf =xjzf + cwjz;
                //    cwjz = 0;
                //}
                #region Modify By Zj 2012-05-25 因为挂号票包含了欠费挂账，导致退费时数据不正确
                //if (qfgz > 0)
                //{
                //    if (qfgz > xjzf)
                //    {

                //        qfgz = qfgz - xjzf;
                //        xjzf = 0;
                //    }
                //    else
                //    {
                //        xjzf = xjzf - qfgz;
                //        qfgz = 0;
                //    }
                //}
                #endregion
                lbltje.Text = xjzf.ToString();

                if (new SystemCfg(1021).Config == "0" && InstanceForm.BCurrentUser.EmployeeId.ToString() != TbFp.Rows[0]["sfy"].ToString())
                {
                    MessageBox.Show("系统控制只能由本发票收费员才能退费", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnQd.Enabled = false;
                    return;
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void btnQd_Click(object sender, EventArgs e)
        {
            if (TbGhxx == null)
            {
                MessageBox.Show("请输入发票号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TbGhxx.Rows.Count==0)
            {
                MessageBox.Show("请输入发票号","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (TbFp.Rows.Count==0)
            {
                MessageBox.Show("请输入发票号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cwjz > 0 && readcard.zfbz == true)
            {
                MessageBox.Show("这张卡已作废,不能再向卡中退钱。请到账务退费", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //医保类型
                int _yblx = Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0"));
                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                Guid _brxxid = new Guid(TbGhxx.Rows[0]["brxxid"].ToString());
                Guid _ghxxid = new Guid(TbGhxx.Rows[0]["ghxxid"].ToString());
                brxx.BRXXID = _brxxid;
                brxx.GHXXID = _ghxxid;
                brxx.BLH = TbFp.Rows[0]["BLH"].ToString();
                
                MZHS_FZJL _fz = new MZHS_FZJL(_ghxxid, InstanceForm.BDatabase);
                DataTable dt_ghxx= mz_ghxx.GetGhxx(_ghxxid,InstanceForm.BDatabase);
                int ghks=Convert.ToInt32( TbGhxx.Rows[0]["ghks"]);
                int ghys=Convert.ToInt32(Convertor.IsNull(TbGhxx.Rows[0]["ghys"],"0"));
                int ghjb=Convert.ToInt32(TbGhxx.Rows[0]["ghjb"]);
                string ghsj=Convert.ToDateTime(TbGhxx.Rows[0]["GHSJ"]).ToString("yyyy-MM-dd");
                Ts_Visit_Class.VisitResource _VisRes = new VisitResource(ghks, ghjb, ghys, ghsj, InstanceForm.BDatabase);
              
                Ts_Visit_Class.FsdClass _Fsd = null;
                if (_cfg1099.Config.Trim() == "1" && _VisRes.Resid > 0)
                {
                    try
                    {
                        _Fsd = new FsdClass(_fz.Sjnc, ghsj, _VisRes.Resid, InstanceForm.BDatabase);
                        // _Fsd = new FsdClass(_fz.Sjnc, Convert.ToDateTime(_fz.Ghrq).ToString("yyyy-MM-dd"), _VisRes.Resid, InstanceForm.BDatabase);
                    }
                    catch
                    {
                        _Fsd = null;
                    }
                }
                string ssql = "";
                try
                {

                    //ts_yb_mzgl.IMZYB mzyb;
                    Yblx yblx = new Yblx(_yblx, InstanceForm.BDatabase);

                    //string ybjssjh = "";
                    //string ss = "";
                    //DataTable tbcx = null;
                    //bool ret = false;
                    //int x = 0;


                    decimal je = Convert.ToDecimal(Convertor.IsNull(lblJe.Text.Trim(), "0"));
                    #region 医保退费
                    if (yblx.isgh == true && je > 0)
                    {
                        try
                        {
                            ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yblx.ybjklx);
                            ComboBox cmbtb = new ComboBox();
                            brxx.BLH = TbFp.Rows[0]["blh"].ToString();
                            bool bok = ybjk.GetPatientInfo(TbFp.Rows[0]["fpid"].ToString(), yblx.yblx.ToString(), yblx.insureCentral.ToString(), yblx.hospid.ToString(), InstanceForm.BCurrentUser.EmployeeId.ToString(), "", "", ref brxx, cmbtb);
                            if (bok == false) return;
                            lblybkye.Text = brxx.KYE;


                            ssql = "select cfid from mz_cfb where fpid='" + TbFp.Rows[0]["fpid"].ToString() + "' ";
                            DataTable tbcf = InstanceForm.BDatabase.GetDataTable(ssql);
                            if (tbcf.Rows.Count != 1) throw new Exception("找到多行处方记录,请和管理员联系");

                            string cfid = "";
                            cfid = "('" + tbcf.Rows[0]["cfid"].ToString() + "')";

                            //全退
                            bok = ybjk.UnCompute(true, yblx.yblx.ToString(), yblx.insureCentral, yblx.hospid, InstanceForm.BCurrentUser.EmployeeId.ToString(),
                            TbFp.Rows[0]["fpid"].ToString(), TbFp.Rows[0]["YBJYDJH"].ToString(), _sDate, cfid, brxx, ref jsxx);
                            if (bok == false) throw new Exception("医保退费没有成功");

                        }
                        catch (System.Exception err)
                        {
                            MessageBox.Show("医保退费失败!原因:" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                        yblx.isgh = false; //Modify By zp 2013-10-14 避免金额为0也调医保函数 只有所收金额大于0 医保类型 isgh才打开
                    #endregion

                    InstanceForm.BDatabase.BeginTransaction();
                    string _sfck = "";

                    int _NRows = 0;
                    int _err_code = -1;
                    string _err_text = "";
                    //取消挂号记录
                    mz_ghxx.CancelGh(_ghxxid, _sDate, InstanceForm.BCurrentUser.EmployeeId, out _NRows, out _err_code, out _err_text, InstanceForm.BDatabase);
                    if (_NRows == 0 || _err_code != 0) throw new Exception("数据已转移到历史库,不能办理退费,请咨询管理员！");
                    //产生结算记录
                    Guid NewJsid = Guid.Empty;
                    mz_sf.SaveJs(Guid.Empty, _brxxid, _ghxxid, _sDate, InstanceForm.BCurrentUser.EmployeeId, (-1) * zje, (-1) * ybzhzf, (-1) * ybjjzf, (-1) * ybbzzf, (-1) * ylkzf, (-1) * yhje, (-1) * cwjz, (-1) * qfgz, (-1) * xjzf, 0, (-1) * srje, 0, 0, 0, 1, TrasenFrame.Forms.FrmMdiMain.Jgbm, out NewJsid, out _err_code, out _err_text, InstanceForm.BDatabase);
                    if (NewJsid == Guid.Empty || _err_code != 0) throw new Exception("产生结算记录出现异常!" + _err_text);
                    //更新卡余额和累计消息金额
                    if (cwjz > 0)
                        readcard.UpdateKye((-1) * cwjz, InstanceForm.BDatabase);

                    //退卡 add by zouchihua  收过卡钱就退卡
                    if (Convertor.IsNull(lbltk.Tag, "") == "999")
                    {
                        mz_kdj.CancelCard(readcard.kdjid, readcard.kh, InstanceForm.BCurrentUser.EmployeeId, "病人退挂号签", _brxxid, out _err_code, out _err_text, InstanceForm.BDatabase);
                        if (_err_code != 0) throw new Exception("退卡出现异常!" + _err_text);
                    }

                    #region 作废原发票
                    Guid NewFpid = Guid.Empty;
                    //此处电脑流水号写死为0  需要将电脑流水号改为源挂号发票记录的电脑流水号 否则交账的作废票会有重复记录 Modify By zp 2014-01-20
                    long _dnlsh = long.Parse(TbGhxx.Rows[0]["DNLXH"].ToString());//(txtDnlsh.Text.Trim());
                    mz_sf.SaveFp(Guid.Empty, _brxxid, _ghxxid, TbFp.Rows[0]["BLH"].ToString(), TbFp.Rows[0]["BRXM"].ToString(),
                        _sDate, InstanceForm.BCurrentUser.EmployeeId, _sfck, _dnlsh, TbFp.Rows[0]["fph"].ToString(),
                        (-1) * zje, (-1) * ybzhzf, (-1) * ybjjzf,
                        (-1) * ybbzzf, (-1) * ylkzf, (-1) * yhje,
                        (-1) * cwjz, (-1) * qfgz, (-1) * xjzf, 0,
                        (-1) * srje, new Guid(TbFp.Rows[0]["FPID"].ToString()), "", NewJsid, 1, Convert.ToInt32(TbFp.Rows[0]["ksdm"]),
                        Convert.ToInt32(TbFp.Rows[0]["ysdm"]), Convert.ToInt32(TbFp.Rows[0]["zyksdm"]), Convert.ToInt32(TbFp.Rows[0]["zxks"]),
                        Convert.ToInt32(TbFp.Rows[0]["yblx"]), Convert.ToString(TbFp.Rows[0]["ybjydjh"]), 2, new Guid(Convertor.IsNull(TbFp.Rows[0]["kdjid"], Guid.Empty.ToString())),
                        Convert.ToInt64(TbFp.Rows[0]["jgbm"]), new Guid(Convertor.IsNull(TbFp.Rows[0]["yhlxid"], Guid.Empty.ToString())), Convertor.IsNull(TbFp.Rows[0]["yhlxmc"], ""), out NewFpid, out _err_code, out _err_text, InstanceForm.BDatabase);
                    if (NewFpid == Guid.Empty || _err_code != 0) throw new Exception("作废原发票出现异常!" + _err_text);

                    //更新医保结算表的收费信息
                    if (yblx.isgh == true)
                    {
                        ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yblx.ybjklx);
                        bool bok = ybjk.UpdateJsmx(_brxxid, _ghxxid, jsxx.HisJsid_Old, jsxx.HisJsdid, new Guid(TbFp.Rows[0]["FPID"].ToString()), TbFp.Rows[0]["fph"].ToString(), _sDate, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                        if (bok == false) throw new Exception("更新本地医保结算表时没有成功");
                    }
                    //处理发票
                    DataTable tb_fpmx = mz_sf.SelectFp_mx(new Guid(TbFp.Rows[0]["fpid"].ToString()), InstanceForm.BDatabase);
                    for (int i = 0; i <= tb_fpmx.Rows.Count - 1; i++)
                    {
                        mz_sf.SaveFpmx(NewFpid, Convertor.IsNull(tb_fpmx.Rows[i]["xmdm"], "0"), Convertor.IsNull(tb_fpmx.Rows[i]["xmmc"], "0"), (-1) * Convert.ToDecimal(tb_fpmx.Rows[i]["je"]), 0, out _err_code, out _err_text, InstanceForm.BDatabase);
                        if (_err_code != 0) throw new Exception("处理发票出现异常!" + _err_text);
                    }
                    //处理发票明细
                    DataTable tb_fpdxmmx = mz_sf.SelectFp_dxmmx(new Guid(TbFp.Rows[0]["fpid"].ToString()), InstanceForm.BDatabase);
                    for (int i = 0; i <= tb_fpdxmmx.Rows.Count - 1; i++)
                    {
                        mz_sf.SaveFpdxmmx(NewFpid, Convertor.IsNull(tb_fpdxmmx.Rows[i]["xmdm"], "0"), Convertor.IsNull(tb_fpdxmmx.Rows[i]["xmmc"], "0"), (-1) * Convert.ToDecimal(tb_fpdxmmx.Rows[i]["je"]), 0, out _err_code, out _err_text, InstanceForm.BDatabase);
                        if (_err_code != 0) throw new Exception("处理发票明细!" + _err_text);
                    }
                    //处理发票状态
                    int Nrows = 0;
                    mz_sf.UpdateFpjlzt(new Guid(TbFp.Rows[0]["fpid"].ToString()), out Nrows, InstanceForm.BDatabase);
                    if (Nrows != 1) throw new Exception("更新原发票记录状态时出错,没有更新到行");

                    #endregion
                    if (Convert.ToDecimal(Convertor.IsNull(lblJe.Text, "0")) > 0)
                    {
                        mz_cf.Tghp(_ghxxid, txtinput.Text.Trim(), _sfck, _sDate, NewFpid, out _err_code, out _err_text, InstanceForm.BDatabase);
                        if (_err_code != 0) throw new Exception(_err_text);
                    }
                    if (_Fsd!=null && _Fsd.FsdId > 0)
                        _Fsd.Save(ref _Fsd, true, InstanceForm.BDatabase); //回收挂号资源 Add by zp 2013-10-31
                    InstanceForm.BDatabase.CommitTransaction();
                    MessageBox.Show("退签成功!");
                    this.Close();
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:"+ea.Message,"提示");
            }
        }

        private void btnGb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTfq_Load(object sender, EventArgs e)
        {
            YLKKTF = new SystemCfg(1013).Config == "1" ? "true" : "false";
            YLKTXJ = new SystemCfg(1014).Config == "1" ? "true" : "false";
            CWJZKTF = new SystemCfg(1015).Config == "1" ? "true" : "false";
            CWJZTXJ = new SystemCfg(1120).Config == "1" ? "true" : "false";

            FunAddComboBox.AddYblx(false, 0, cmbyblx, InstanceForm.BDatabase);
             cmbyblx.SelectedIndex = -1;

             FunAddComboBox.AddKlx(false, 0, cboKlx, InstanceForm.BDatabase);

             //自动读射频卡
             string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
             ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
             if (ReadCard != null)
                 ReadCard.AutoReadCard(_menuTag.Function_Name, cboKlx, txtKh);
        }

        private void FrmTfq_Activated(object sender, EventArgs e)
        {
            txtinput.Focus();
        }

        private void butreadcard_Click(object sender, EventArgs e)
        {


            //读卡的话默认第一个医保类型 
            if (Convert.ToInt32(cmbyblx.SelectedValue) <= 0)
            {
                if (cmbyblx.Items.Count > 0) cmbyblx.SelectedIndex = 0;
            }

            if (cmbyblx.SelectedIndex == -1)
            {
                MessageBox.Show("没有选择医保类型！");
                return;
            }

            try
            {
                Cursor = PubStaticFun.WaitCursor();
                int _yblx = Convert.ToInt32(cmbyblx.SelectedValue);
                Yblx yblx = new Yblx(_yblx, InstanceForm.BDatabase);

                brxx.BRXXID = new Guid(TbGhxx.Rows[0]["brxxid"].ToString());
                brxx.GHXXID = new Guid(TbGhxx.Rows[0]["ghxxid"].ToString());
                brxx.BLH = TbGhxx.Rows[0]["blh"].ToString();

                ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yblx.ybjklx);
                ComboBox cmbtb = new ComboBox();
                bool bok = ybjk.GetPatientInfo("", yblx.yblx.ToString(), yblx.insureCentral, yblx.hospid, InstanceForm.BCurrentUser.EmployeeId.ToString(), "", "", ref brxx, cmbtb);

                lblybkye.Text = brxx.KYE;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                butreadcard.Enabled = false;
                Cursor = Cursors.Default;
            }
            finally
            {
                butreadcard.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void butxtk_Click(object sender, EventArgs e)
        {
            try
            {
                //默认第一个医保类型
                if (Convert.ToInt32(cmbyblx.SelectedValue) <= 0)
                {
                    DataTable yblxTb = (DataTable)cmbyblx.DataSource;
                    DataRow[] yblxDr = yblxTb.Select("ID>0");

                    if (yblxDr.Length > 0)
                    {
                        cmbyblx.SelectedValue = Convert.ToInt32(Convertor.IsNull(yblxDr[0]["id"], "-1"));
                    }
                }

                Cursor = PubStaticFun.WaitCursor();
                int _yblx = Convert.ToInt32(cmbyblx.SelectedValue);
                Yblx yblx = new Yblx(_yblx, InstanceForm.BDatabase);

                ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yblx.ybjklx);
                bool bok = ybjk.Xtk(yblx.yblx.ToString(), yblx.insureCentral, yblx.hospid);

                butreadcard.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


        private DataTable SelectCf( string brxm , Guid ghxxid , string _fph ,Guid Fpid )
        {
            try
            {
                string fph = _fph;
                
                ParameterEx[] parameters = new ParameterEx[11];
                parameters[0].Text = "@rq1";
                parameters[0].Value = "";

                parameters[1].Text = "@rq2";
                parameters[1].Value = "";

                parameters[2].Text = "@SFBZ";
                parameters[2].Value = 1;

                parameters[3].Text = "@bak";
                parameters[3].Value = 0;

                parameters[4].Text = "@FPH";
                parameters[4].Value = fph;

                parameters[5].Text = "@ghxxid";
                parameters[5].Value = ghxxid;

                parameters[6].Text = "@fpid";
                parameters[6].Value = Fpid;

                parameters[7].Text = "@brxm";
                parameters[7].Value = brxm;

                parameters[8].Text = "@JGBM";
                parameters[8].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                parameters[9].Text = "@KDYS";                  
                parameters[9].Value = "";
 
                parameters[10].Text = "@XDCF";
                parameters[10].Value = 0;

                DataTable tb = InstanceForm.BDatabase.GetDataTable( "SP_MZSF_CX_CFCX" , parameters , 30 );
                return tb;

            }
            catch ( System.Exception err )
            {
                throw new System.Exception(err.Message);
            }
        }

        private void ReadGhxx( Guid Ghxxid )
        {
            try
            {
                btnQd.Enabled = false;
                bool bls = false;
                
                string ssql = "select a.*,b.brxm from mz_ghxx A inner join YY_BRXX b on A.BRXXID=B.BRXXID where a.ghxxid='" + Ghxxid.ToString() + "'";
                TbGhxx = InstanceForm.BDatabase.GetDataTable( ssql );
                if ( TbGhxx.Rows.Count == 0 )
                {
                    ssql = "select a.*,b.brxm from mz_ghxx_h A inner join YY_BRXX b on A.BRXXID=B.BRXXID where a.ghxxid='" + Ghxxid.ToString() + "'";
                    TbGhxx = InstanceForm.BDatabase.GetDataTable( ssql );
                    if ( TbGhxx.Rows.Count > 0 )
                        bls = true;
                }
                if ( TbGhxx.Rows.Count == 0 )
                {
                    MessageBox.Show( "没有找到发票信息" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    TbGhxx = null;
                    return;
                }
                if ( Convert.ToInt16( TbGhxx.Rows[0]["bqxghbz"] ) == 1 )
                {
                    MessageBox.Show( "此挂号票已作废" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    TbGhxx = null;
                    return;
                }

                //找到原卡信息
                Guid kdjid = new Guid( Convertor.IsNull( TbGhxx.Rows[0]["kdjid"] , Guid.Empty.ToString() ) );
                readcard = new ReadCard(kdjid, InstanceForm.BDatabase);
                if ( kdjid != readcard.kdjid )
                {
                    MessageBox.Show( "没有找到原卡信息,原卡编号为" + kdjid.ToString() + ",找到的卡编号为" + readcard.kdjid.ToString() + ",请和管理人员联系" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    TbGhxx = null;
                    return;
                }
                
                lblFph.Text = TbGhxx.Rows[0]["fph"].ToString();
                txtinput.Text = lblFph.Text;
                txtDnlsh.Text = TbGhxx.Rows[0]["dnlxh"].ToString();
                lblHzxm.Text = TbGhxx.Rows[0]["brxm"].ToString();
                lblKsmc.Text = Fun.SeekDeptName(Convert.ToInt32(TbGhxx.Rows[0]["ghks"]), InstanceForm.BDatabase);
                lblYsxm.Text = Fun.SeekEmpName(Convert.ToInt32(TbGhxx.Rows[0]["ghys"]), InstanceForm.BDatabase);
                lblYsjb.Text = Fun.SeekGhjbName(Convert.ToInt32(TbGhxx.Rows[0]["ghjb"]), InstanceForm.BDatabase);
                lblGhrq.Text = TbGhxx.Rows[0]["GHSJ"].ToString();
                lblCzy.Text = Fun.SeekEmpName(Convert.ToInt32(TbGhxx.Rows[0]["djy"]), InstanceForm.BDatabase);
                lblklx.Text = Fun.SeekKlxmc(readcard.klx, InstanceForm.BDatabase);
                lblkh.Text = readcard.kh;

                lbltk.Visible = false;
                lbltk.Tag = "0";

                btnQd.Enabled = true;

                if (mz_hj.GetHj(new Guid(TbGhxx.Rows[0]["ghxxid"].ToString()), InstanceForm.BDatabase) == true)
                {
                    lbltk.Visible = true;
                    if ( new SystemCfg( 1033 ).Config == "1" )
                    {
                        lbltk.Text = "请注意！病人已就诊";
                        btnQd.Enabled = true;
                    }
                    else
                    {
                        lbltk.Text = "病人已就诊,不能退签";
                        btnQd.Enabled = false;
                    }

                }

                //退卡的处理
                if ( readcard.kdjid != Guid.Empty && readcard.kdjid != null )
                {
                    mz_card card = new mz_card(readcard.klx, InstanceForm.BDatabase);
                    DataTable tbcf = mz_cf.SelectCardFee(new Guid(TbGhxx.Rows[0]["ghxxid"].ToString()), lblFph.Text, card.sfxmid, InstanceForm.BDatabase);
                    if ( tbcf.Rows.Count > 0 )
                    {
                        lbltk.Visible = true;
                        lbltk.Text = "退" + lblklx.Text + "一张";
                        lbltk.Tag = "999";
                    }
                }

                TbFp = mz_sf.SelectFp(new Guid(TbGhxx.Rows[0]["ghxxid"].ToString()),0, "", 1, InstanceForm.BDatabase);
                if ( TbFp.Rows.Count == 0 )
                {
                    MessageBox.Show( "没有找到发票信息" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    TbFp = null;
                    return;
                }
                try
                {
                    string fph="";
                    if ( txtinput.Text != "0" )
                        fph = txtinput.Text;

                    DataTable tbMx = SelectCf( "" , Guid.Empty ,fph, new Guid(TbFp.Rows[0]["fpid"].ToString()) );
                    dgvDetail.AutoGenerateColumns = false;
                    dgvDetail.DataSource = tbMx;
                    object obj = tbMx.Compute( "SUM(金额)" , "" );
                    if ( obj != null )
                        lblMxzje.Text = obj.ToString();
                }
                catch ( Exception err_mx )
                {
                    MessageBox.Show( "获取明细发生错误！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                }


                zje = Convert.ToDecimal( TbFp.Rows[0]["zje"] );
                yhje = Convert.ToDecimal( TbFp.Rows[0]["YHJE"] );
                srje = Convert.ToDecimal( TbFp.Rows[0]["srje"] );
                ybjjzf = Convert.ToDecimal( TbFp.Rows[0]["ybjjzf"] );
                ybzhzf = Convert.ToDecimal( TbFp.Rows[0]["ybzhzf"] );
                ybbzzf = Convert.ToDecimal( TbFp.Rows[0]["ybbzzf"] );
                qfgz = Convert.ToDecimal( TbFp.Rows[0]["qfgz"] );
                cwjz = Convert.ToDecimal( TbFp.Rows[0]["cwjz"] );
                ylkzf = Convert.ToDecimal( TbFp.Rows[0]["ylkzf"] );
                xjzf = Convert.ToDecimal( TbFp.Rows[0]["xjzf"] );

                cmbyblx.SelectedValue = TbFp.Rows[0]["yblx"].ToString();

                decimal ybzf = ybjjzf + ybzhzf + ybbzzf;
                lblJe.Text = zje.ToString();
                lblyhje.Text = yhje > 0 ? yhje.ToString() : "";
                lblsrje.Text = srje != 0 ? srje.ToString() : "";
                lblybzf.Text = ybzf != 0 ? ybzf.ToString() : "";
                lblqfgz.Text = qfgz != 0 ? qfgz.ToString() : "";
                lblcwjz.Text = cwjz != 0 ? cwjz.ToString() : "";
                lblylzf.Text = ylkzf != 0 ? ylkzf.ToString() : "";
                lblxjzf.Text = xjzf != 0 ? xjzf.ToString() : "";
                lbltje.Text = xjzf.ToString();
                lblyhlx.Tag = Convertor.IsNull( TbFp.Rows[0]["yhlxid"] , "0" );
                lblyhlx.Text = Convertor.IsNull( TbFp.Rows[0]["yhlxmc"] , "" );

                if ( bls == true )
                {
                    MessageBox.Show( " 数据已转移到历史库,不能办理退费,请咨询管理员！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    btnQd.Enabled = false;
                    return;
                }


                if ( ylkzf > 0 && YLKKTF != "true" )
                {
                    MessageBox.Show( "本张发票银联支付金额为:" + ylkzf.ToString( "0.00" ) + "元,但系统在有银联支付信息的情况下不允许办理退费" );
                    return;
                }
                if ( cwjz > 0 && CWJZKTF != "true" )
                {
                    MessageBox.Show( "本张发票财务记帐金额为:" + cwjz.ToString( "0.00" ) + "元,但系统在有财务记帐信息的情况下不允许办理退费" );
                    return;
                }

                if ( YLKTXJ == "true" && ylkzf > 0 )
                {
                    xjzf = xjzf + ylkzf;
                    ylkzf = 0;
                }
                if (CWJZTXJ == "true" && cwjz > 0)
                {

                    xjzf = xjzf + cwjz;
                    cwjz = 0;
                }

                if ( qfgz > 0 )
                {
                    if ( qfgz > xjzf )
                    {

                        qfgz = qfgz - xjzf;
                        xjzf = 0;
                    }
                    else
                    {
                        xjzf = xjzf - qfgz;
                        qfgz = 0;
                    }
                }

                lbltje.Text = xjzf.ToString();

                int sfy = Convert.ToInt32( TbFp.Rows[0]["sfy"].ToString() );
                Employee employee = new Employee( sfy , InstanceForm.BDatabase );

                if ( new SystemCfg( 1021 ).Config == "0" && InstanceForm.BCurrentUser.EmployeeId.ToString() != TbFp.Rows[0]["sfy"].ToString()
                    && employee.Rylx != EmployeeType.自助终端 )
                {
                    MessageBox.Show( "系统控制只能由本发票收费员才能退费" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    btnQd.Enabled = false;
                    return;
                }
                 

            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }

        private void txtDnlsh_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 && !string.IsNullOrEmpty( txtDnlsh.Text.Trim() ) )
            {
                if ( Convertor.IsNumeric( txtDnlsh.Text ) && Convert.ToInt64( txtDnlsh.Text ) != 0 )
                {
                    txtDnlsh.Text = ToDBC(txtDnlsh.Text);
                    txtDnlsh.Text = Fun.returnDnlsh(txtDnlsh.Text, InstanceForm.BDatabase);
                    
                    string sql = "select ghxxid from mz_ghxx where dnlxh=" + txtDnlsh.Text;
                    object obj = InstanceForm.BDatabase.GetDataResult( sql );
                    if ( obj != null )
                    {
                        ReadGhxx( new Guid( obj.ToString() ) );
                    }
                    else
                    {
                        MessageBox.Show( "该流水号找不到挂号记录" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    }
                }
            }
        }

        private void txtKh_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 && !string.IsNullOrEmpty( txtKh.Text.Trim() ) )
            {
                int klx = cboKlx.SelectedValue == null ? 0 : Convert.ToInt32( cboKlx.SelectedValue);
                txtKh.Text = Fun.returnKh(klx, txtKh.Text, InstanceForm.BDatabase);
                txtKh.Text = ToDBC(txtKh.Text);
                string kh =   txtKh.Text ;
                FrmSelectGHJL frmGhjl = new FrmSelectGHJL( klx , kh );
                if ( frmGhjl.ShowDialog() == DialogResult.OK )
                {
                    ReadGhxx( frmGhjl.SelectedGhxxid );
                }
            }
        }

        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

	}
}
