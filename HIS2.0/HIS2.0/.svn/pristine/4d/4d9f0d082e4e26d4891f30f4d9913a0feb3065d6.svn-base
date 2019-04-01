using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Data.OleDb;

namespace Ts_zyys_main
{
	/// <summary>
	/// 会诊科室医生权限确认 的摘要说明。
	/// </summary>
	public class tempPW : System.Windows.Forms.Form
	{
		public DataTable myTb=new DataTable();
		public long YS_ID=0;
		public long userID= 0;
		public long ConDept= 0;
		public bool flag=false;
		private int Num=0;
		private System.Windows.Forms.TextBox txtPW;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public tempPW()
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
			this.txtPW = new System.Windows.Forms.TextBox();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.btOK = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtPW
			// 
			this.txtPW.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtPW.Location = new System.Drawing.Point(100, 68);
			this.txtPW.Name = "txtPW";
			this.txtPW.PasswordChar = '☆';
			this.txtPW.Size = new System.Drawing.Size(160, 23);
			this.txtPW.TabIndex = 1;
			this.txtPW.Text = "";
			this.txtPW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPW_KeyPress);
			// 
			// txtCode
			// 
			this.txtCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCode.ForeColor = System.Drawing.Color.Navy;
			this.txtCode.Location = new System.Drawing.Point(100, 24);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(160, 23);
			this.txtCode.TabIndex = 0;
			this.txtCode.Text = "";
			this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button2.Location = new System.Drawing.Point(168, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 24);
			this.button2.TabIndex = 3;
			this.button2.Text = "退出(&C)";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// btOK
			// 
			this.btOK.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btOK.Location = new System.Drawing.Point(56, 112);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(72, 24);
			this.btOK.TabIndex = 2;
			this.btOK.Text = "确定(&O)";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(32, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 22);
			this.label2.TabIndex = 7;
			this.label2.Text = "  密码";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(32, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 22);
			this.label1.TabIndex = 4;
			this.label1.Text = "用户名";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tempPW
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(304, 157);
			this.Controls.Add(this.txtPW);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "tempPW";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "会诊医生登陆";
			this.ResumeLayout(false);

		}
		#endregion	

		#region 判断是否正确
		/// <summary>
		/// 先判断是否是会诊医生，再判断是否密码正确
		/// </summary>
		/// <param name="code">用户名</param>
		/// <param name="pw">密码</param>
		/// <returns></returns>
		private bool isPW(string code,string pw)
		{
			for(int i=0;i<myTb.Rows.Count;i++)
			{
				string code1=myTb.Rows[i]["ys_code"].ToString().Trim().ToUpper();
				string code2 = code.Trim().ToUpper();
				if(code1==code2)
				{
					string aa = TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto(myTb.Rows[i]["pw"].ToString());
					if(txtPW.Text== aa)
					{
						this.YS_ID=Convert.ToInt32(myTb.Rows[i]["ys_id"].ToString());
						this.userID=Convert.ToInt32(myTb.Rows[i]["user_id"].ToString());
						this.ConDept=Convert.ToInt32(myTb.Rows[i]["dept_id"].ToString());
						return true;
					}
					else 
					{
						txtPW.Text="";
						return false;
					}
				}
			}
			txtCode.Text="";
			txtPW.Text="";
			return false;
		}
		#endregion

	    #region 事件
		private void txtCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13 ) return;
			txtPW.Focus();
		}
		private void txtPW_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13 ) return;
			btOK_Click(null,null);
		}
		#region 确定
		private void btOK_Click(object sender, System.EventArgs e)
		{
			if(isPW(txtCode.Text,txtPW.Text)==false)
			{
				Num++;
				if(Num==3) 
				{
					MessageBox.Show("三次错误！退出！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					this.Close();
				}
				else 
				{
					MessageBox.Show("输入错误！请重输。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					if(txtCode.Text!="") txtPW.Focus();
					else txtCode.Focus();
					return;
				}
			}
			else
			{
				flag=true;
				this.Close();
			}
		}
		#endregion

		#region 退出
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}	
		#endregion
		#endregion
		
	}
}
