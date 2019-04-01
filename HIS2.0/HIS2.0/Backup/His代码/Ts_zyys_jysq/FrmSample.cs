using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace Ts_zyys_jysq
{
	/// <summary>
	/// FrmSample 的摘要说明。
	/// </summary>
	public class FrmSample : System.Windows.Forms.Form
	{
		public string item="";
		public string sample="";
		public int sampleCode=0;
		public DataTable sampleTb=new DataTable();
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbSample;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmSample()
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbSample = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button1.Location = new System.Drawing.Point(208, 64);
			this.button1.Name = "button1";
			this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.button1.TabIndex = 0;
			this.button1.Text = "确定";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(272, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "请给";
			// 
			// cmbSample
			// 
			this.cmbSample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSample.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbSample.Location = new System.Drawing.Point(32, 64);
			this.cmbSample.Name = "cmbSample";
			this.cmbSample.Size = new System.Drawing.Size(120, 22);
			this.cmbSample.TabIndex = 2;
			// 
			// FrmSample
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(320, 117);
			this.Controls.Add(this.cmbSample);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmSample";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "指定送检标本";
			this.Load += new System.EventHandler(this.FrmSample_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmSample_Load(object sender, System.EventArgs e)
		{
			this.label1.Text="请为项目“"+this.item+"”指定送检标本：";

			this.cmbSample.Items.Clear();
			this.cmbSample.DataSource=this.sampleTb;
			this.cmbSample.DisplayMember="NAME";
			this.cmbSample.ValueMember="CODE";			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.sampleCode=Convert.ToInt32(this.cmbSample.SelectedValue);
			this.Close();
		}
	}
}
