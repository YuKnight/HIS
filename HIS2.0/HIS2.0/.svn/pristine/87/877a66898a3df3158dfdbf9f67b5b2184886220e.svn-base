using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_yzgl
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmBRFS : System.Windows.Forms.Form
	{
        public int nType=0;  //医嘱类型		
		public int iSelect=2;  // 0所有  1选择 2不发送  
		public int iSelect0=0,iSelect1=0,iSelect2=0,iSelect3=0;
		public bool IsChangeExecDept = false;
        public int newExecDept = 0;
        public DateTime execDateTime;

		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button bt开始发送;
		public System.Windows.Forms.RadioButton rb32;
		public System.Windows.Forms.RadioButton rb31;
		public System.Windows.Forms.RadioButton rb30;
		public System.Windows.Forms.RadioButton rb22;
		public System.Windows.Forms.RadioButton rb21;
		public System.Windows.Forms.RadioButton rb20;
		public System.Windows.Forms.RadioButton rb12;
		public System.Windows.Forms.RadioButton rb11;
		public System.Windows.Forms.RadioButton rb10;
		public System.Windows.Forms.RadioButton rb02;
		public System.Windows.Forms.RadioButton rb01;
		public System.Windows.Forms.RadioButton rb00;
		public System.Windows.Forms.RadioButton rb选择发送;
		public System.Windows.Forms.RadioButton rb全部发送;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.CheckBox chkExecDept;
		private System.Windows.Forms.ComboBox cmbExecDept;
		public System.Windows.Forms.GroupBox grpLSZD;
		public System.Windows.Forms.GroupBox grpCQZD;
		public System.Windows.Forms.GroupBox grpLSYZ;
        public System.Windows.Forms.GroupBox grpCQYZ;
        private DateTimePicker DateExecDate;
        private CheckBox chkDate;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBRFS()
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.bt开始发送 = new System.Windows.Forms.Button();
            this.grpLSZD = new System.Windows.Forms.GroupBox();
            this.rb32 = new System.Windows.Forms.RadioButton();
            this.rb31 = new System.Windows.Forms.RadioButton();
            this.rb30 = new System.Windows.Forms.RadioButton();
            this.grpCQZD = new System.Windows.Forms.GroupBox();
            this.rb22 = new System.Windows.Forms.RadioButton();
            this.rb21 = new System.Windows.Forms.RadioButton();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.grpLSYZ = new System.Windows.Forms.GroupBox();
            this.rb12 = new System.Windows.Forms.RadioButton();
            this.rb11 = new System.Windows.Forms.RadioButton();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.grpCQYZ = new System.Windows.Forms.GroupBox();
            this.rb02 = new System.Windows.Forms.RadioButton();
            this.rb01 = new System.Windows.Forms.RadioButton();
            this.rb00 = new System.Windows.Forms.RadioButton();
            this.rb选择发送 = new System.Windows.Forms.RadioButton();
            this.rb全部发送 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbExecDept = new System.Windows.Forms.ComboBox();
            this.chkExecDept = new System.Windows.Forms.CheckBox();
            this.DateExecDate = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.grpLSZD.SuspendLayout();
            this.grpCQZD.SuspendLayout();
            this.grpLSYZ.SuspendLayout();
            this.grpCQYZ.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(0, 230);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(296, 8);
            this.groupBox6.TabIndex = 84;
            this.groupBox6.TabStop = false;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(152, 246);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(128, 26);
            this.btCancel.TabIndex = 83;
            this.btCancel.Text = "取消(&E)";
            // 
            // bt开始发送
            // 
            this.bt开始发送.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt开始发送.Location = new System.Drawing.Point(8, 246);
            this.bt开始发送.Name = "bt开始发送";
            this.bt开始发送.Size = new System.Drawing.Size(128, 26);
            this.bt开始发送.TabIndex = 82;
            this.bt开始发送.Text = "开始发送(&F)";
            this.bt开始发送.Click += new System.EventHandler(this.bt开始发送_Click);
            // 
            // grpLSZD
            // 
            this.grpLSZD.Controls.Add(this.rb32);
            this.grpLSZD.Controls.Add(this.rb31);
            this.grpLSZD.Controls.Add(this.rb30);
            this.grpLSZD.Enabled = false;
            this.grpLSZD.Location = new System.Drawing.Point(80, 182);
            this.grpLSZD.Name = "grpLSZD";
            this.grpLSZD.Size = new System.Drawing.Size(200, 40);
            this.grpLSZD.TabIndex = 90;
            this.grpLSZD.TabStop = false;
            // 
            // rb32
            // 
            this.rb32.Location = new System.Drawing.Point(128, 16);
            this.rb32.Name = "rb32";
            this.rb32.Size = new System.Drawing.Size(64, 16);
            this.rb32.TabIndex = 14;
            this.rb32.Text = "不发送";
            this.rb32.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb31
            // 
            this.rb31.Location = new System.Drawing.Point(72, 16);
            this.rb31.Name = "rb31";
            this.rb31.Size = new System.Drawing.Size(48, 16);
            this.rb31.TabIndex = 13;
            this.rb31.Text = "选定";
            this.rb31.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb30
            // 
            this.rb30.Enabled = false;
            this.rb30.Location = new System.Drawing.Point(16, 16);
            this.rb30.Name = "rb30";
            this.rb30.Size = new System.Drawing.Size(48, 16);
            this.rb30.TabIndex = 12;
            this.rb30.Text = "所有";
            this.rb30.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // grpCQZD
            // 
            this.grpCQZD.Controls.Add(this.rb22);
            this.grpCQZD.Controls.Add(this.rb21);
            this.grpCQZD.Controls.Add(this.rb20);
            this.grpCQZD.Enabled = false;
            this.grpCQZD.Location = new System.Drawing.Point(80, 142);
            this.grpCQZD.Name = "grpCQZD";
            this.grpCQZD.Size = new System.Drawing.Size(200, 40);
            this.grpCQZD.TabIndex = 89;
            this.grpCQZD.TabStop = false;
            // 
            // rb22
            // 
            this.rb22.Location = new System.Drawing.Point(128, 16);
            this.rb22.Name = "rb22";
            this.rb22.Size = new System.Drawing.Size(64, 16);
            this.rb22.TabIndex = 14;
            this.rb22.Text = "不发送";
            this.rb22.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb21
            // 
            this.rb21.Location = new System.Drawing.Point(72, 16);
            this.rb21.Name = "rb21";
            this.rb21.Size = new System.Drawing.Size(48, 16);
            this.rb21.TabIndex = 13;
            this.rb21.Text = "选定";
            this.rb21.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb20
            // 
            this.rb20.Enabled = false;
            this.rb20.Location = new System.Drawing.Point(16, 16);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(48, 16);
            this.rb20.TabIndex = 12;
            this.rb20.Text = "所有";
            this.rb20.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // grpLSYZ
            // 
            this.grpLSYZ.Controls.Add(this.rb12);
            this.grpLSYZ.Controls.Add(this.rb11);
            this.grpLSYZ.Controls.Add(this.rb10);
            this.grpLSYZ.Enabled = false;
            this.grpLSYZ.Location = new System.Drawing.Point(80, 102);
            this.grpLSYZ.Name = "grpLSYZ";
            this.grpLSYZ.Size = new System.Drawing.Size(200, 40);
            this.grpLSYZ.TabIndex = 88;
            this.grpLSYZ.TabStop = false;
            // 
            // rb12
            // 
            this.rb12.Location = new System.Drawing.Point(128, 16);
            this.rb12.Name = "rb12";
            this.rb12.Size = new System.Drawing.Size(64, 16);
            this.rb12.TabIndex = 14;
            this.rb12.Text = "不发送";
            this.rb12.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb11
            // 
            this.rb11.Location = new System.Drawing.Point(72, 16);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(48, 16);
            this.rb11.TabIndex = 13;
            this.rb11.Text = "选定";
            this.rb11.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb10
            // 
            this.rb10.Enabled = false;
            this.rb10.Location = new System.Drawing.Point(16, 16);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(48, 16);
            this.rb10.TabIndex = 12;
            this.rb10.Text = "所有";
            this.rb10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // grpCQYZ
            // 
            this.grpCQYZ.Controls.Add(this.rb02);
            this.grpCQYZ.Controls.Add(this.rb01);
            this.grpCQYZ.Controls.Add(this.rb00);
            this.grpCQYZ.Enabled = false;
            this.grpCQYZ.Location = new System.Drawing.Point(80, 62);
            this.grpCQYZ.Name = "grpCQYZ";
            this.grpCQYZ.Size = new System.Drawing.Size(200, 40);
            this.grpCQYZ.TabIndex = 87;
            this.grpCQYZ.TabStop = false;
            // 
            // rb02
            // 
            this.rb02.Location = new System.Drawing.Point(128, 16);
            this.rb02.Name = "rb02";
            this.rb02.Size = new System.Drawing.Size(64, 16);
            this.rb02.TabIndex = 14;
            this.rb02.Text = "不发送";
            this.rb02.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb01
            // 
            this.rb01.Location = new System.Drawing.Point(72, 16);
            this.rb01.Name = "rb01";
            this.rb01.Size = new System.Drawing.Size(48, 16);
            this.rb01.TabIndex = 13;
            this.rb01.Text = "选定";
            this.rb01.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb00
            // 
            this.rb00.Enabled = false;
            this.rb00.Location = new System.Drawing.Point(16, 16);
            this.rb00.Name = "rb00";
            this.rb00.Size = new System.Drawing.Size(48, 16);
            this.rb00.TabIndex = 12;
            this.rb00.Text = "所有";
            this.rb00.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb选择发送
            // 
            this.rb选择发送.Checked = true;
            this.rb选择发送.Location = new System.Drawing.Point(184, 8);
            this.rb选择发送.Name = "rb选择发送";
            this.rb选择发送.Size = new System.Drawing.Size(80, 24);
            this.rb选择发送.TabIndex = 86;
            this.rb选择发送.TabStop = true;
            this.rb选择发送.Text = "选择发送";
            this.rb选择发送.Click += new System.EventHandler(this.rb选择发送_Click);
            // 
            // rb全部发送
            // 
            this.rb全部发送.Enabled = false;
            this.rb全部发送.Location = new System.Drawing.Point(80, 8);
            this.rb全部发送.Name = "rb全部发送";
            this.rb全部发送.Size = new System.Drawing.Size(104, 24);
            this.rb全部发送.TabIndex = 85;
            this.rb全部发送.Text = "全部发送";
            this.rb全部发送.Click += new System.EventHandler(this.rb全部发送_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 91;
            this.label1.Text = "长期医嘱：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 92;
            this.label2.Text = "临时医嘱：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 93;
            this.label3.Text = "临时账单：";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 94;
            this.label4.Text = "长期账单：";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 95;
            this.label5.Text = "执行科室：";
            this.label5.Visible = false;
            // 
            // cmbExecDept
            // 
            this.cmbExecDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExecDept.Enabled = false;
            this.cmbExecDept.Location = new System.Drawing.Point(96, 8);
            this.cmbExecDept.Name = "cmbExecDept";
            this.cmbExecDept.Size = new System.Drawing.Size(184, 20);
            this.cmbExecDept.TabIndex = 96;
            this.cmbExecDept.Visible = false;
            // 
            // chkExecDept
            // 
            this.chkExecDept.Enabled = false;
            this.chkExecDept.Location = new System.Drawing.Point(80, 6);
            this.chkExecDept.Name = "chkExecDept";
            this.chkExecDept.Size = new System.Drawing.Size(16, 24);
            this.chkExecDept.TabIndex = 97;
            this.chkExecDept.Visible = false;
            this.chkExecDept.CheckedChanged += new System.EventHandler(this.chkExecDept_CheckedChanged);
            // 
            // DateExecDate
            // 
            this.DateExecDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateExecDate.CustomFormat = "yyyy-MM-dd";
            this.DateExecDate.Enabled = false;
            this.DateExecDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateExecDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateExecDate.Location = new System.Drawing.Point(96, 38);
            this.DateExecDate.Name = "DateExecDate";
            this.DateExecDate.Size = new System.Drawing.Size(120, 23);
            this.DateExecDate.TabIndex = 11;
            this.DateExecDate.Value = new System.DateTime(2003, 9, 20, 0, 0, 0, 0);
            // 
            // chkDate
            // 
            this.chkDate.Location = new System.Drawing.Point(18, 42);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(80, 16);
            this.chkDate.TabIndex = 10;
            this.chkDate.Text = "选择日期";
            this.chkDate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // frmBRFS
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(280, 276);
            this.Controls.Add(this.DateExecDate);
            this.Controls.Add(this.chkDate);
            this.Controls.Add(this.grpCQYZ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpLSZD);
            this.Controls.Add(this.grpCQZD);
            this.Controls.Add(this.grpLSYZ);
            this.Controls.Add(this.rb选择发送);
            this.Controls.Add(this.rb全部发送);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.bt开始发送);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkExecDept);
            this.Controls.Add(this.cmbExecDept);
            this.Controls.Add(this.label5);
            this.Location = new System.Drawing.Point(296, 304);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(296, 314);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(296, 314);
            this.Name = "frmBRFS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单个病人医嘱发送";
            this.Load += new System.EventHandler(this.frmBRFS_Load);
            this.grpLSZD.ResumeLayout(false);
            this.grpCQZD.ResumeLayout(false);
            this.grpLSYZ.ResumeLayout(false);
            this.grpCQYZ.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rb全部发送_Click(object sender, System.EventArgs e)
		{
			this.rb00.Checked=true;
			this.rb10.Checked=true;
			this.rb20.Checked=true;
			this.rb30.Checked=true;

			this.grpCQYZ.Enabled=false;
			this.grpLSYZ.Enabled=false;
			this.grpCQZD.Enabled=false;
			this.grpLSZD.Enabled=false;

			this.chkExecDept.Checked=false;
			this.chkExecDept.Enabled=false;
		}

		private void rb选择发送_Click(object sender, System.EventArgs e)
		{
			this.grpCQYZ.Enabled=true;
			this.grpLSYZ.Enabled=true;
			this.grpCQZD.Enabled=true;
			this.grpLSZD.Enabled=true;

            this.rb01.Enabled=this.nType==0?true:false;
			this.rb11.Enabled=this.nType==1?true:false;
			this.rb21.Enabled=this.nType==2?true:false;
			this.rb31.Enabled=this.nType==3?true:false;

			this.rb01.Checked=this.nType==0?true:false;
			this.rb11.Checked=this.nType==1?true:false;
			this.rb21.Checked=this.nType==2?true:false;
			this.rb31.Checked=this.nType==3?true:false;

			this.rb02.Checked=this.nType==0?false:true;
			this.rb12.Checked=this.nType==1?false:true;
			this.rb22.Checked=this.nType==2?false:true;
			this.rb32.Checked=this.nType==3?false:true;

			if(nType==1)
				chkExecDept.Enabled=true;
			else
				chkExecDept.Enabled=false;
		}

		private void bt开始发送_Click(object sender, System.EventArgs e)
		{	

			this.iSelect=this.rb全部发送.Checked?0:1;
			this.iSelect0=this.rb00.Checked?0:(this.rb01.Checked?1:2);
			this.iSelect1=this.rb10.Checked?0:(this.rb11.Checked?1:2);
			this.iSelect2=this.rb20.Checked?0:(this.rb21.Checked?1:2);
			this.iSelect3=this.rb30.Checked?0:(this.rb31.Checked?1:2);

			if(cmbExecDept.Enabled && cmbExecDept.Text.Trim()!="")
			{
				if(MessageBox.Show("是否需要将所选定的临时医嘱中药品的执行科室改为 "+cmbExecDept.Text.Substring(5).Trim()+" ？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					IsChangeExecDept = true;
					newExecDept = Convert.ToInt32(cmbExecDept.Text.Substring(0,2).Trim());
				}
				else
				{
					cmbExecDept.SelectedIndex=-1;
					cmbExecDept.Text="";
					return;
				}
			}

            if (chkDate.Checked)
            {
                execDateTime = DateExecDate.Value;
            }

			this.Close();
		}

		private void frmBRFS_Load(object sender, System.EventArgs e)
		{
			if(nType==1)
				chkExecDept.Enabled=true;
			else
				chkExecDept.Enabled=false;

			AddExecDept();

            execDateTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            this.DateExecDate.Value = execDateTime;//服务器当前系统日期
            this.DateExecDate.MaxDate = Convert.ToDateTime(execDateTime.Date.AddDays(Convert.ToInt32((new SystemCfg(7006)).Config)).ToShortDateString() + " 23:59:59");					//系统日期    -最小
            System.TimeSpan diff = new System.TimeSpan(Convert.ToInt32((new SystemCfg(7007)).Config), 0, 0, 0);
            this.DateExecDate.MinDate = Convert.ToDateTime(execDateTime.Subtract(diff).ToShortDateString() + " 23:59:59");	    //系统日期-Static_Exec_MaxDays -最大

			rb选择发送_Click(sender, e);
		}

		private void chkExecDept_CheckedChanged(object sender, System.EventArgs e)
		{
			cmbExecDept.Enabled=chkExecDept.Checked;
		}

		private void AddExecDept()
		{
//			cmbExecDept.Items.Add("88 | 急诊药房");
//			cmbExecDept.Items.Add("42 | 病室中药房");
//			cmbExecDept.Items.Add("43 | 病室西药房");
//			cmbExecDept.Items.Add("44 | 病室成药房");
		}

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            DateExecDate.Enabled = chkDate.Checked;
        }
	}
}
