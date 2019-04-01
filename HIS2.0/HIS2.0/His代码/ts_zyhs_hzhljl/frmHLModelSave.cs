using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ts_zyhs_hzhljl
{
	/// <summary>
	/// frmHLModelSave 的摘要说明。
	/// </summary>
	public class frmHLModelSave : System.Windows.Forms.Form
	{
		public string ModelName="";
		public int mng_type=0;
		public int model_type=0;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdoBoth;
		private System.Windows.Forms.RadioButton rdoYBHLJL;
		private System.Windows.Forms.RadioButton rdoWZHLJL;
		private System.Windows.Forms.RadioButton rdoAll;
		private System.Windows.Forms.RadioButton rdoWard;
		private System.Windows.Forms.RadioButton rdoDept;
		private System.Windows.Forms.RadioButton rdoUser;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHLModelSave()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdoWZHLJL = new System.Windows.Forms.RadioButton();
			this.rdoYBHLJL = new System.Windows.Forms.RadioButton();
			this.rdoBoth = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdoUser = new System.Windows.Forms.RadioButton();
			this.rdoDept = new System.Windows.Forms.RadioButton();
			this.rdoWard = new System.Windows.Forms.RadioButton();
			this.rdoAll = new System.Windows.Forms.RadioButton();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdoWZHLJL);
			this.groupBox1.Controls.Add(this.rdoYBHLJL);
			this.groupBox1.Controls.Add(this.rdoBoth);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(416, 56);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "模版使用对象";
			// 
			// rdoWZHLJL
			// 
			this.rdoWZHLJL.Location = new System.Drawing.Point(264, 24);
			this.rdoWZHLJL.Name = "rdoWZHLJL";
			this.rdoWZHLJL.Size = new System.Drawing.Size(144, 24);
			this.rdoWZHLJL.TabIndex = 4;
			this.rdoWZHLJL.Tag = "2";
			this.rdoWZHLJL.Text = "危重护理记录(&H)";
			// 
			// rdoYBHLJL
			// 
			this.rdoYBHLJL.Location = new System.Drawing.Point(112, 24);
			this.rdoYBHLJL.Name = "rdoYBHLJL";
			this.rdoYBHLJL.Size = new System.Drawing.Size(144, 24);
			this.rdoYBHLJL.TabIndex = 3;
			this.rdoYBHLJL.Tag = "1";
			this.rdoYBHLJL.Text = "一般护理记录(&N)";
			// 
			// rdoBoth
			// 
			this.rdoBoth.Checked = true;
			this.rdoBoth.Location = new System.Drawing.Point(16, 24);
			this.rdoBoth.Name = "rdoBoth";
			this.rdoBoth.Size = new System.Drawing.Size(88, 24);
			this.rdoBoth.TabIndex = 2;
			this.rdoBoth.TabStop = true;
			this.rdoBoth.Tag = "0";
			this.rdoBoth.Text = "公共(&B)";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdoUser);
			this.groupBox2.Controls.Add(this.rdoDept);
			this.groupBox2.Controls.Add(this.rdoWard);
			this.groupBox2.Controls.Add(this.rdoAll);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox2.Location = new System.Drawing.Point(8, 80);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(416, 56);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "模版类型";
			// 
			// rdoUser
			// 
			this.rdoUser.Location = new System.Drawing.Point(319, 24);
			this.rdoUser.Name = "rdoUser";
			this.rdoUser.Size = new System.Drawing.Size(87, 24);
			this.rdoUser.TabIndex = 3;
			this.rdoUser.Tag = "3";
			this.rdoUser.Text = "个人(&U)";
			// 
			// rdoDept
			// 
			this.rdoDept.Location = new System.Drawing.Point(218, 24);
			this.rdoDept.Name = "rdoDept";
			this.rdoDept.Size = new System.Drawing.Size(87, 24);
			this.rdoDept.TabIndex = 2;
			this.rdoDept.Tag = "2";
			this.rdoDept.Text = "科室(&D)";
			// 
			// rdoWard
			// 
			this.rdoWard.Location = new System.Drawing.Point(117, 24);
			this.rdoWard.Name = "rdoWard";
			this.rdoWard.Size = new System.Drawing.Size(87, 24);
			this.rdoWard.TabIndex = 1;
			this.rdoWard.Tag = "1";
			this.rdoWard.Text = "病区(&W)";
			// 
			// rdoAll
			// 
			this.rdoAll.Checked = true;
			this.rdoAll.Location = new System.Drawing.Point(16, 24);
			this.rdoAll.Name = "rdoAll";
			this.rdoAll.Size = new System.Drawing.Size(87, 24);
			this.rdoAll.TabIndex = 0;
			this.rdoAll.TabStop = true;
			this.rdoAll.Tag = "0";
			this.rdoAll.Text = "全院(&A)";
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtName.Location = new System.Drawing.Point(88, 160);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(336, 26);
			this.txtName.TabIndex = 0;
			this.txtName.Text = "";
			this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(9, 165);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "模版名称";
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnOk.Location = new System.Drawing.Point(200, 208);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(72, 32);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "&OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnCancel.Location = new System.Drawing.Point(304, 208);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 32);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			// 
			// frmHLModelSave
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(432, 261);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(440, 288);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(440, 288);
			this.Name = "frmHLModelSave";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "护理模版保存";
			this.Load += new System.EventHandler(this.frmHLModelSave_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmHLModelSave_Load(object sender, System.EventArgs e)
		{
			txtName.Focus();
		}

		private void txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				btnOk_Click(sender,e);
				DialogResult = DialogResult.OK;
			}
			else if (e.KeyChar == 27)
			{
				this.Close();
			}
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			if (txtName.Text.Trim()=="")
			{
				MessageBox.Show(this,"请输入模版名称！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtName.Focus();
				return;
			}
			else
				ModelName=txtName.Text;
			if (rdoBoth.Checked)
				mng_type=0;
			else if (rdoYBHLJL.Checked)
				mng_type=1;
			else
				mng_type=2;
			if (rdoAll.Checked)
				model_type=0;
			else if (rdoWard.Checked)
				model_type=1;
			else if (rdoDept.Checked)
				model_type=2;
			else
				model_type=3;
		}
	}
}
