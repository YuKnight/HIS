using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ts_zyys_public
{
	/// <summary>
	/// 密码输入窗体。
	/// </summary>
	public class FrmPW : System.Windows.Forms.Form
	{
		public string pwStr="";

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bt_OK;
		private System.Windows.Forms.Button bt_Cancel;
		private System.Windows.Forms.TextBox txt_pw;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmPW()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmPW));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_pw = new System.Windows.Forms.TextBox();
			this.bt_OK = new System.Windows.Forms.Button();
			this.bt_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(22, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 32);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.MediumBlue;
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 24);
			this.label1.TabIndex = 6;
			this.label1.Text = "请输入密码，确认你的权限！";
			// 
			// txt_pw
			// 
			this.txt_pw.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txt_pw.ForeColor = System.Drawing.Color.Navy;
			this.txt_pw.Location = new System.Drawing.Point(64, 43);
			this.txt_pw.MaxLength = 50;
			this.txt_pw.Name = "txt_pw";
			this.txt_pw.PasswordChar = '●';
			this.txt_pw.Size = new System.Drawing.Size(172, 23);
			this.txt_pw.TabIndex = 7;
			this.txt_pw.Text = "";
			this.txt_pw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pw_KeyDown);
			// 
			// bt_OK
			// 
			this.bt_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bt_OK.Location = new System.Drawing.Point(61, 80);
			this.bt_OK.Name = "bt_OK";
			this.bt_OK.Size = new System.Drawing.Size(64, 23);
			this.bt_OK.TabIndex = 8;
			this.bt_OK.Text = "确定(&O)";
			this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
			// 
			// bt_Cancel
			// 
			this.bt_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bt_Cancel.Location = new System.Drawing.Point(157, 80);
			this.bt_Cancel.Name = "bt_Cancel";
			this.bt_Cancel.Size = new System.Drawing.Size(64, 23);
			this.bt_Cancel.TabIndex = 9;
			this.bt_Cancel.Text = "取消(&C)";
			this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
			// 
			// FrmPW
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(282, 113);
			this.Controls.Add(this.bt_Cancel);
			this.Controls.Add(this.bt_OK);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.txt_pw);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmPW";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "权限确认：";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPW_KeyUp);
			this.ResumeLayout(false);

		}
		#endregion

		private void bt_OK_Click(object sender, System.EventArgs e)
		{
			pwStr=txt_pw.Text.Trim();
		}

		private void FrmPW_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if( e.KeyData==Keys.Escape) 
			{
				this.Close();
			}
		}
		private void txt_pw_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue==13)	
			{
				pwStr=txt_pw.Text.Trim();
                bt_OK.Focus();
			}
		}

		private void bt_Cancel_Click(object sender, System.EventArgs e)
		{
            this.Close();
		}
	}
	public class DlgPW
	{
		static FrmPW frmpw;

		public static string Show()
		{
			frmpw=new FrmPW();
			frmpw.ShowDialog();
            if (frmpw.DialogResult == DialogResult.Cancel)
            {
                frmpw.pwStr = "密码确认被取消！";
            }
			return frmpw.pwStr;
		}
	}
}
